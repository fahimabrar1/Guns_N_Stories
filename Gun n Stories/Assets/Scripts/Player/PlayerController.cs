using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerController : Shootable
{

    /*
        ............................................................................................
        ............................................................................................

            This EnemyController Extends Shootable class.
            This class allows enemy to detect enemy when Player comes in range.
            And Shoots enemy or reload.

        ............................................................................................
        ............................................................................................
        */

    public NavMeshAgent trailer;
    public Transform start,end;
    CharacterController controller;
    [Range(10,100)]
    public float Speed =10f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        if(trailer!=null)
        {
            trailer.transform.position = start.position;
            trailer.SetDestination(end.position);
        }
    }
    private void FixedUpdate()
    {

        float moveX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * Speed * Time.deltaTime);

        /*
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.forward))
                {
                    Debug.DrawLine(transform.position,Vector3.forward, Color.red);
                }*/

    }

    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }
}
