using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move_Controller : MonoBehaviour
{
    public InputActionProperty padOn;
    public InputActionProperty padClick;


    IEnumerator Update_Co()
    {
        if(padOn.action.IsInProgress()&&padClick.action.IsPressed())
        {
            //���̳��͹��긦 on�ϴ� ������ ¥�� �۵��� �ұ��?
        }

        return null;
    }

    private void Update()
    {
        StartCoroutine(Update_Co());
    }


}
