using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Interactable
{
    public override void Interact(GameObject subject)
    {
        Player.Instance.PickUp();
        StartCoroutine(ShowSword());
        print(gameObject.name);
    }
    IEnumerator ShowSword()
    {
        yield return new WaitForSeconds(1f);
        Player.Instance.ActivateSword();
        Destroy(gameObject);
    }
}