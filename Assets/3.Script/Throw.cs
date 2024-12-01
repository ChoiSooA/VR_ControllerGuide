using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Throw : MonoBehaviour
{
    int enterCount=0;
    [SerializeField] GameObject[] throwThing;
    [SerializeField] GameObject throwPrefab;

    [SerializeField] TMP_Text score;
    [SerializeField] AudioSource finish;

    private void Start()
    {
        score.text = enterCount.ToString() + " / " + throwThing.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throw"))
        {
            enterCount++;
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.tag = "Wait";

            if (enterCount >= throwThing.Length)
            {
                StartCoroutine(AllIn());
                enterCount = 0;
                finish.Play();
            }
            else
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.CompareTag("Untagged"))
        {
            other.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = other.gameObject.transform.parent.transform.position;
            other.transform.rotation = other.gameObject.transform.parent.transform.rotation;
            other.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
        score.text = enterCount.ToString()+" / "+throwThing.Length;
    }

    IEnumerator AllIn()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < throwThing.Length; i++)
        {
            throwThing[i].transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            throwThing[i].transform.position = throwThing[i].gameObject.transform.parent.transform.position;
            throwThing[i].transform.rotation = throwThing[i].gameObject.transform.parent.transform.rotation;
            throwThing[i].transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
