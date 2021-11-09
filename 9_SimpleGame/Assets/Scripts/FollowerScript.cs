using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    public Transform objToFollow;

    private Vector3 deltaPos;
    // Start is called before the first frame update
    void Start()
    {
        // transform - shortcut для текущего объекта
        deltaPos = transform.position - objToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objToFollow.position + deltaPos;
    }
}
