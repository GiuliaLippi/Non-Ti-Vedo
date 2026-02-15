using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChoice : MonoBehaviour
{
    public string choiceA = "Prendere la chiave rossa";
    public string choiceB = "Prendere la chiave blu";

    public Key keyA;
    public Key keyB;

    private bool interacted = false;

    public override void Interact()
    {
        if (interacted) return;

        interacted = true;

        Debug.Log("NPC interagito! Scegli A o B:");

        Debug.Log("A: " + choiceA);
        Debug.Log("B: " + choiceB);

        // In prototipo useremo input tastiera per scelta
        Debug.Log("Premi 1 per scelta A, 2 per scelta B");
    }

    void Update()
    {
        if (!interacted) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GiveKey(keyA);
            interacted = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GiveKey(keyB);
            interacted = false;
        }
    }

    void GiveKey(Key key)
    {
        Debug.Log("Hai ricevuto: " + key.keyName);
        key.PickUp();
    }
}