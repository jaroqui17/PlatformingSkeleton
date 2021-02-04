using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")) {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
