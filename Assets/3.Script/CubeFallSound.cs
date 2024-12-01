using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFallSound : MonoBehaviour
{
    bool isGrab=false;
    [SerializeField] AudioSource fallSound;
    private void OnCollisionEnter(Collision collision)
    {
        if (isGrab == false)
        {
            fallSound.Play();
        }
    }
    public void enterGrab()
    {
        isGrab = true;
    }
    public void exitGrab()
    {
        isGrab = false;
    }
}
