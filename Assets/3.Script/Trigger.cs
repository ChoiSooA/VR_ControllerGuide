using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Button[] bt_Point;
    [SerializeField] GameObject startPannel;
    [SerializeField] GameObject playPannel;
    [SerializeField] GameObject successPannel;

    int click_Count=0;
    int bt_num;
    private void Start()
    {
        bt_num = bt_Point.Length;
    }

    public void Click_BT(int n)
    {
        click_Count++;
        Success();
        bt_Point[n].gameObject.SetActive(false);
    }

    void Success()
    {
        if (click_Count == bt_num)
        {
            playPannel.SetActive(false);
            successPannel.SetActive(true);
        }
    }
    public void Play()
    {
        click_Count = 0;
        for (int i = 0; i < bt_Point.Length; i++)
        {
            bt_Point[i].gameObject.SetActive(true);
        }
        playPannel.SetActive(true);
        startPannel.SetActive(false);
        successPannel.SetActive(false);

    }
}
