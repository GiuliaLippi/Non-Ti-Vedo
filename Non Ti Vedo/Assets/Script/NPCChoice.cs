using UnityEngine;

public class NPCChoice : Interactable
{
    [Header("Scelte")]
    public string choiceA = "Prendere la chiave rossa";
    public string choiceB = "Prendere la chiave blu";

    [Header("Chiavi")]
    public Chiave keyA;
    public Chiave keyB;

    private bool interacted = false;

    /// <summary>
    /// Questo metodo viene chiamato dallo script Interactable quando il player preme E.
    /// </summary>
    public void HandleInteraction()
    {
        if (interacted) return;

        interacted = true;

        Debug.Log("NPC: Hai bisogno di una chiave...");
        Debug.Log("Premi 1 → " + choiceA);
        Debug.Log("Premi 2 → " + choiceB);
    }

    private void Update()
    {
        if (!interacted) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Hai scelto: " + choiceA);
            DaiChiave(keyA);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Hai scelto: " + choiceB);
            DaiChiave(keyB);
        }
    }

    private void DaiChiave(Chiave chiave)
    {
        if (chiave != null)
        {
            chiave.Raccogli();
            Debug.Log("Chiave ottenuta!");
        }
        else
        {
            Debug.LogWarning("Chiave non assegnata nell'Inspector.");
        }

        interacted = false;
    }
}
