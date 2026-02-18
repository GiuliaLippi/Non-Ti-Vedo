using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Interazione")]
    [Tooltip("Messaggio mostrato quando puoi interagire")]
    public string promptMessage = "Premi E per interagire";

    [Tooltip("Distanza massima a cui il player può interagire")]
    public float interactionDistance = 2f;

    private Transform player;

    private void Awake()
    {
        // Trova automaticamente il player tramite tag
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
                player = foundPlayer.transform;
            else
                Debug.LogWarning("Player non trovato nella scena. Assicurati che abbia il tag 'Player'.");
        }
    }

    private void Update()
    {
        if (IsPlayerInRange() && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public virtual void Interact(){
        Debug.Log("Interazione con: " + gameObject.name);

        // Controlla se l'oggetto ha un handler personalizzato
        IInteractableHandler handler = GetComponent<IInteractableHandler>();
        if (handler != null)
        {
            handler.HandleInteraction();
        }
        else
        {
            Debug.Log("Oggetto interagibile ma senza handler: " + gameObject.name);
        }
    }
    private bool IsPlayerInRange()
    {
        if (player == null) return false;
        float distance = Vector3.Distance(player.position, transform.position);
        return distance <= interactionDistance;
    }
}

public interface IInteractableHandler
{
    void HandleInteraction();
}
