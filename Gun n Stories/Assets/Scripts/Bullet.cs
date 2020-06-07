using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*
        ............................................................................................
        ............................................................................................

            This Bullet is Responsible for the Bullet to move forward.

        ............................................................................................
        ............................................................................................
        */
    public static float firehole;
    Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * firehole * Time.deltaTime);
    }
}
