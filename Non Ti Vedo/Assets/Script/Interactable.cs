using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string promptMessage = "Premi E per interagire";

    // Questo metodo verrà chiamato quando il player interagisce
    public virtual void Interact()
    {
        Debug.Log("Interazione con: " + gameObject.name);
    }
}
