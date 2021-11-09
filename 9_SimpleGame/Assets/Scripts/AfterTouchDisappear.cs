using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterTouchDisappear : MonoBehaviour
{
    private void OnTriggerExit(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.2f); // небольшая задержка и исчезаем
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
