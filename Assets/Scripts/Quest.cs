using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public int id;
    new public string name = "Test Quest";
    [Multiline] public string description = "Do something!";
    public int coinsReward = 10;
    public List<GameObject> enemies;
    private int enemyCount;
    public bool isDone = false;
    private bool isActive = false;
    public Text questName, questDescription, questReward, questCompletedText;
    public WaveSpawner waveSpawner;
    private void Start()
    {
        enemyCount = enemies.Count;
        questName.text += name;
        questDescription.text += description;
        questReward.text += coinsReward;
    }
    public void StartQuest()
    {
        if (!isActive)
        {
            waveSpawner.gameObject.SetActive(true);
            questName.gameObject.SetActive(true);
            questDescription.gameObject.SetActive(true);
            questReward.gameObject.SetActive(true);

            QuestsSystem.Instance.activeQuests.Add(this);
            float areaLength = 5f;
            foreach (var enemy in enemies)
            {
                float posX = transform.position.x + (areaLength / 2) * Random.Range(-1, 1);
                float posZ = transform.position.x + (areaLength / 2) * Random.Range(-1, 1);
                var newEnemy = Instantiate(enemy, new Vector3(posX, transform.position.y, posZ), Quaternion.identity);
                newEnemy.GetComponent<Enemy>().quest = this;
            }
            isActive = true;
            print($"Start quest - {name}");
            print($"Desciption - {description}");
            print($"Money for quest - {coinsReward}");
        }
    }
    public void OnEnemyDead()
    {
        enemyCount--;
        //if (enemyCount <= 0)
        //{
        //    QuestDone();
        //}
    }
    public void QuestDone()
    {
        QuestsSystem.Instance.activeQuests.Remove(this);
        QuestsSystem.Instance.doneQuests.Add(this);
        isDone = true;
        isActive = false;
        Player.Instance.AddCoins(coinsReward);
        print("Quest Done!");
        questName.gameObject.SetActive(false);
        questDescription.gameObject.SetActive(false);
        questReward.gameObject.SetActive(false);
        questCompletedText.gameObject.SetActive(true);
        StartCoroutine(EndOfTheGame());
    }
    public IEnumerator EndOfTheGame()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Credits Scene");
    }
}