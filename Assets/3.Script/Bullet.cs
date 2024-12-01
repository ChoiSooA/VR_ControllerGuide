using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 1000f;
    private void OnEnable()
    {
        gameObject.transform.SetParent(null);

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Force);

        StartCoroutine(ObjFalse(gameObject, 4f));
    }
    private void OnDisable()
    {
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;

    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.SetParent(GameObject.Find("Bullet_Start_Pos").transform);
        gameObject.SetActive(false);
        
    }

    IEnumerator ObjFalse(GameObject target ,float sec)
    {
        yield return new WaitForSeconds(sec);
        target.SetActive(false);

    }
}
