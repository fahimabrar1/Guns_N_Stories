using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    /*
    ............................................................................................
    ............................................................................................
     
        This Follower class helps enemy to find Player,lookat and follow Player in Game.
        When he comes in range, EnemyController does it's Job ;) .
    
    ............................................................................................
    ............................................................................................
    */

    public GameObject target;
    Transform transform;

    public bool MoveTowardsTarget;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
        transform = GetComponent<Transform>();
        MoveTowardsTarget = true;
    }

    void Update()
    {
        transform.LookAt(target.transform);
        if(MoveTowardsTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,10*Time.deltaTime);
        }
    }


    /*
............................................................................................
............................................................................................

  OnTriggerEnter() method is responsible enemy to look at the player and set plaerfound true.
        
        if allows enemy to cast ray at the enemy, then shoot and reload.

............................................................................................
............................................................................................
*/
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {
            MoveTowardsTarget = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            MoveTowardsTarget = false;
        }
    }
    /*
............................................................................................
............................................................................................

OnTriggerExit() method is responsible to stop shooting as enemy got out of range.

............................................................................................
............................................................................................
*/
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {
            MoveTowardsTarget = true;
        }
    }
}
