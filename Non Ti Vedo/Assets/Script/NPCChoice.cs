using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cambia da MonoBehaviour a Interactable
public class NPCChoice : Interactable 
{
    public string choiceA = "Prendere la chiave rossa";
    public string choiceB = "Prendere la chiave blu";
    public Key keyA;
    public Key keyB;

    private bool interacted = false;

    // Aggiungi 'override' per sostituire il metodo base
    public void InteractKey() 
    {
        if (interacted) return;
        interacted = true;
        Debug.Log("NPC: Scegli 1 o 2");
    }

    void Update()
    {
        if (!interacted) return;

        if (Input.GetKeyDown(KeyCode.Alpha1)) { GiveKey(keyA); interacted = false; }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { GiveKey(keyB); interacted = false; }
    }

    void GiveKey(Key key)
    {
        if(key != null) key.PickUp();
    }
}