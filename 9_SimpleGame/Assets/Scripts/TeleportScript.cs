using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public TeleportScript ToTeleport;   // Объект-телепорт КУДА будет перемещение из текущего телепорта
    public bool isEnabled;

    private Transform objToMove;
    
    // Start is called before the first frame update
    void Start()
    {
        isEnabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!isEnabled) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(moveToTeleport(collision.gameObject.transform));
        }
    }
 
 
    IEnumerator moveToTeleport(Transform targetObject)
    {
        yield return new WaitForSeconds(0.5f); // ждём пол секунды
 
        ToTeleport.isEnabled = false; // выключает телепорт в который переместиться объект (чтобы тот телепорт не отправил его тут же обратно)
        
        targetObject.position = ToTeleport.transform.position; // телепортируем сам объект
 
        yield return new WaitForSeconds(0.1f); // ждём немного
        ToTeleport.isEnabled = true; //и включаем телепорт, который принял объект
 
    }
}
