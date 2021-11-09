using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.VersionControl;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class ObjectSwitcher : MonoBehaviour
{
    public Transform ObjToSwitch;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        var gameObject = ObjToSwitch.gameObject;
        var isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);
        Debug.WriteLine($"GameObject active status => {!isActive}");
    }
}
