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
            //다이나믹무브를 on하는 식으로 짜면 작동을 할까요?
        }

        return null;
    }

    private void Update()
    {
        StartCoroutine(Update_Co());
    }


}
