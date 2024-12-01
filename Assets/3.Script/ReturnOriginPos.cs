using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnOriginPos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit"+other.name);
        StartCoroutine(Delay_Co(other));
    }
    
    IEnumerator Delay_Co(Collider col)
    {
        yield return new WaitForSeconds(1f);
        if (col.CompareTag("Object")|| col.CompareTag("Throw"))
        {
            if (col.transform.parent != null)
            {
                col.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                col.transform.position = col.gameObject.transform.parent.transform.position;
                col.transform.rotation = col.gameObject.transform.parent.transform.rotation;
                col.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        
        StopCoroutine(Delay_Co(col));
    }

}