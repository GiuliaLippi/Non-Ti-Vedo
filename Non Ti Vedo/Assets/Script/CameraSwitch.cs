using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraLei;
    public GameObject cameraLui;

    public GameObject playerLei;
    public GameObject playerLui;

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

        playerLei.SetActive(true);
        playerLui.SetActive(false);

        isLeiActive = true;
    }

    void ActivateLui()
    {
        cameraLei.SetActive(false);
        cameraLui.SetActive(true);

        playerLei.SetActive(false);
        playerLui.SetActive(true);

        isLeiActive = false;
    }
}