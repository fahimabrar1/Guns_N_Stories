using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    /*
    ............................................................................................
    ............................................................................................
     
        This Shootable class stores the information for a character to shoot.
    
    ............................................................................................
    ............................................................................................
    */
    public GameObject bullet;
    public int magsize;
    public int WaitForReloud;
    public float FireRate;

    public abstract void Shoot();
    

    public abstract void Reload();



}
