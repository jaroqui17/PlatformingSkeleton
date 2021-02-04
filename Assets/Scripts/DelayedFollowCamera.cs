using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFollowCamera : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.transform.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}
