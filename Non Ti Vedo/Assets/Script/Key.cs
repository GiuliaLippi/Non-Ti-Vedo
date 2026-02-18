using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyName = "Chiave";

    private bool collected = false;
    public bool IsCollected => collected;

    public void PickUp()
    {
        if (collected) return;

        collected = true;
        Debug.Log(keyName + " raccolta!");

        // Nascondi oggetto
        gameObject.SetActive(false);

        // In futuro: aggiungi logica per botola/capitolo random
    }
}