using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Down : MonoBehaviour
{
    public bool isSit=false;
    public InputActionProperty menu;

    [SerializeField] float height=10f;
    [SerializeField] float speed = 0.5f;

    void Update()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        if (menu.action.triggered)     //triggered는 단발성 IsPressed()는 연속성
        {
            Debug.Log("Primary BT Clicked");
            if (isSit == false)
            {
                isSit = true;
                gameObject.transform.position = Vector3.Lerp(
                    gameObject.transform.position, 
                    new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - height, gameObject.transform.position.z), 
                    speed*Time.deltaTime);
            }
            else if (isSit == true)
            {
                isSit = false;
                gameObject.transform.position = Vector3.Lerp(
                       gameObject.transform.position,
                       new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + height, gameObject.transform.position.z),
                       speed * Time.deltaTime);
            }
            yield return new WaitForSeconds(3f);
        }
        
        yield return new WaitForSeconds(Random.Range(0, 0.1f));
    }
}
