using System.Collections;
using UnityEngine;

public class DisappearingScript : MonoBehaviour
{
    public float timeToDisappear;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(timeToDisappear); // ждём и исчезаем
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}