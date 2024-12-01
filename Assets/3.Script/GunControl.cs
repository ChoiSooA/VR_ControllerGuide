using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GunControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletStartPos;

    [SerializeField] List<GameObject> bullet = new List<GameObject>();
    [SerializeField] int bulletCount = 50;
    int pivot = 0;

    /*Vector3 bulletPos = new Vector3();
    Quaternion bulletRot = new Quaternion();*/
    
    bool isgrab=false;

    public InputActionProperty[] Trigger;       //0 : L / 1 : R
    [SerializeField] GameObject[] hand;
    [SerializeField]  int handside;   
    bool canTirgger = true;

    [SerializeField] GameObject target;
    [SerializeField] GameObject[] targets;
    public static int hitCount=0;
    [SerializeField] GameObject particle;

    private void Start()
    {
        target.SetActive(false);
        /*bulletPos = bulletStartPos.transform.position;
        bulletRot = bulletStartPos.transform.rotation;*/
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.parent = this.transform.GetChild(5);
            obj.transform.position = obj.transform.parent.transform.position;
            obj.transform.rotation = obj.transform.parent.transform.rotation;
            obj.SetActive(false);
            bullet.Add(obj);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (canTirgger == true)
        {
            if (other.CompareTag("LeftHand"))
            {
                handside = 0;
                hand[1].GetComponent<XRDirectInteractor>().enabled = false;
            }
            else if (other.CompareTag("RightHand"))
            {
                handside = 1;
                hand[0].GetComponent<XRDirectInteractor>().enabled = false;
            }
            canTirgger = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            hand[1].GetComponent<XRDirectInteractor>().enabled = true;
        }
        else if (other.CompareTag("RightHand"))
        {
            hand[0].GetComponent<XRDirectInteractor>().enabled = true;
        }
        canTirgger = true;
    }

    public void Enter_Grab()
    {
        isgrab = true;
        hitCount = 0;
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            targets[i].SetActive(true);
        }
        //Debug.Log("enter");

        Debug.Log(targets.Length);
    }
    public void Exit_Grab()
    {
        isgrab = false; 
        canTirgger = true;
        //Debug.Log("exit");
        particle.SetActive(false);
    }
    IEnumerator Shoot()
    {
        if (isgrab)
        {
            //Debug.Log("shoot");
            if (Trigger[handside].action.triggered)     //triggered는 단발성 IsPressed()는 연속성
            {
                bullet[pivot].transform.SetParent(null);
                bullet[pivot++].SetActive(true);
                gameObject.GetComponent<AudioSource>().Play();
                if (pivot >= bullet.Count)
                {
                    pivot = 0;
                }
                Debug.Log(hitCount);
                if (hitCount >= targets.Length)
                {
                    //particle.SetActive(true);
                    Debug.Log("Success");
                }
                yield return null;
            }
        }
        yield return new WaitForSeconds(Random.Range(0, 0.1f));
    }
    private void Update()
    {
        StartCoroutine(Shoot());
    }

}
