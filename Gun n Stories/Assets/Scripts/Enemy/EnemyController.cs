using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Shootable
{
    /*
    ............................................................................................
    ............................................................................................
     
        This EnemyController Extends Shootable class.
        This class allows enemy to detect enemy when Player comes in range.
        And Shoots Player Untill he is visible in Range and reload.
    
    ............................................................................................
    ............................................................................................
    */
    public static bool playerfound,shot;
    GameObject player;
    
    public Transform muzzle;

    private void Start()
    {
        playerfound = false;
        shot = false;
    }

    /*
    ............................................................................................
    ............................................................................................
           
        FixedUpdate() method is responsible to look at player when it hits the collider
                then he casts ray at the player and shoots/Reloads untill the rat can hit.

    ............................................................................................
    ............................................................................................
    */

    private void FixedUpdate()
    {
        if(playerfound)
        {
            transform.LookAt(player.transform);
            
            RaycastHit hit;
            Physics.Raycast(muzzle.transform.position, muzzle.TransformDirection(Vector3.forward), out hit);
            Debug.DrawLine(muzzle.transform.position, hit.transform.position,Color.green);
            Debug.Log("Player Magnitude" +hit.transform.position.magnitude);
            Debug.Log("Muzzel Magnitude" +muzzle.transform.position.magnitude);

            if (hit.collider.gameObject.tag.Equals("Player"))
            {
                if (!shot)
                {
                    StartCoroutine(Fire(hit.transform));
                }
            }
        }
    }


    /*
  ............................................................................................
  ............................................................................................

      FixFire(Transform PlayerMagnitude) method is responsible to shoot enemy and call Reload().

  ............................................................................................
  ............................................................................................
  */
    IEnumerator Fire(Transform PlayerMagnitude)
    {
        shot = true;
        int ammo = 0;
        float aim = Mathf.Sqrt((PlayerMagnitude.position.magnitude * PlayerMagnitude.position.magnitude) + (muzzle.transform.position.magnitude * muzzle.transform.position.magnitude));
        while (magsize > ammo)
        {
            if (playerfound)
            {
                GameObject obj = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
                yield return new WaitForSeconds(0.3f);
            }
            ammo++;
        }
        StartCoroutine(Relaod());
    }

    /*
............................................................................................
............................................................................................

  Relaod() method is responsible For delay in reload

............................................................................................
............................................................................................
*/
    IEnumerator Relaod()
    {

        yield return new WaitForSeconds(WaitForReloud);
        shot = false;
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
            Debug.Log(other.gameObject.tag + "Entered");

            playerfound = true;
            player = other.gameObject;
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
            Debug.Log(other.gameObject.tag + "Exited");

            playerfound = false;
            player = null;
        }
    }

    /*
............................................................................................
............................................................................................

 Abstract implementations.

............................................................................................
............................................................................................
*/
    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }
}
