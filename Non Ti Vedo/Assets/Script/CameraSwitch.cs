using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour

{
    public GameObject cameraLei;
    public GameObject cameraLui;

    private bool isLeiActive = true;

    void Start()
    {
        ActivateLei();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isLeiActive)
                ActivateLui();
            else
                ActivateLei();
        }
    }

    void ActivateLei()
    {
        cameraLei.SetActive(true);
        cameraLui.SetActive(false);
        isLeiActive = true;
    }

    void ActivateLui()
    {
        cameraLei.SetActive(false);
        cameraLui.SetActive(true);
        isLeiActive = false;
    }
}