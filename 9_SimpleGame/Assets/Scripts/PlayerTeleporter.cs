using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public Transform ToTeleport;   // Объект КУДА будет перемещение из текущего телепорта

    private Transform objToMove;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) // работает для других объектов, кроме игрока
        {
            StartCoroutine(Teleport(collision.gameObject.transform));
        }
    }
 
 
    IEnumerator Teleport(Transform targetObject)
    {
        yield return new WaitForSeconds(0.5f); // ждём пол секунды

        targetObject.position = ToTeleport.transform.position; // телепортируем сам объект
 
        yield return new WaitForSeconds(0.1f); // ждём немного

    }
}
