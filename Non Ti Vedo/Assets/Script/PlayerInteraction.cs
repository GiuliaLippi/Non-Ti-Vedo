using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2f;
    public Camera playerCamera;
    public bool CloseNpc = false;
    public GameObject Sasso;

    private void Update()
    {
        CheckInteraction();
    }

    void CheckInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && CloseNpc)
        {
          Sasso.GetComponent<Interactable>().Interact();
        }
    }
    void OnTriggerStay (Collider NPC)
    {
       if (NPC.tag == "NPC"){CloseNpc = true; Sasso = NPC.gameObject;}
    }

} 

