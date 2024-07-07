using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Interactable
{
    public override void Interact(GameObject subject)
    {
        Player.Instance.PickUp();
        StartCoroutine(ShowAxe());
        print(gameObject.name);
    }
    IEnumerator ShowAxe()
    {
        yield return new WaitForSeconds(1f);
        Player.Instance.ActivateAxe();
        Destroy(gameObject);
    }
}