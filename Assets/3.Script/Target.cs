using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    AudioSource score;

    private void Start()
    {
        score = gameObject.transform.parent.transform.parent.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            ++(GunControl.hitCount);
            score.Play();

            //Debug.Log(GunControl.hitCount);
            StartCoroutine(DelayFalse());
        }
        else
        {

        }
    }

    IEnumerator DelayFalse()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
