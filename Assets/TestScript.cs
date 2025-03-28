using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello Unity!");

        //1. 변수
        int level = 5;
        float strength = 15.5f;
        string playerName = "sdrftr";
        bool isFullLevel = false;

        //2. 그룹형 변수
        string[] sdrs = { "sdr", "ftr", "ftq" };

        Debug.Log("sdrs: ");
        Debug.Log(sdrs[0]);
        Debug.Log(sdrs[1]);
        Debug.Log(sdrs[2]);
    }
}
