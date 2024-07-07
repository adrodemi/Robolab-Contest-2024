using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(LoadMenu());
        transform.Translate(Vector3.up * Time.deltaTime * 20f);
    }
    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Menu");
    }

}