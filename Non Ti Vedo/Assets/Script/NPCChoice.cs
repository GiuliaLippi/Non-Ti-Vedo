using UnityEngine;
using System;

public class NPCChoice : Interactable
{
    [Header("Testi Scelte")]
    [SerializeField] private string choiceA = "Prendere la chiave rossa";
    [SerializeField] private string choiceB = "Prendere la chiave blu";

    [Header("Dialogo")]
    [SerializeField] private string dialogoNPC = "Hai bisogno di una chiave...";

    [Header("Chiavi")]
    [SerializeField] private Chiave keyA;
    [SerializeField] private Chiave keyB;
    private bool interacted = false;
    public void InteractKey()
    {
        if (interacted) return;
        interacted = true;
        GestoreDialogoUI.Instance.MostraDialogo(
            dialogoNPC,
            choiceA,
            choiceB,
            SelezioneChiaveA,
            SelezioneChiaveB
        );
    }
    private void SelezioneChiaveA()
    {
        DaiChiave(keyA);
        TerminaInterazione();
    }
    private void SelezioneChiaveB()
    {
        DaiChiave(keyB);
        TerminaInterazione();
    }
    private void DaiChiave(Chiave chiave)
    {
        if (chiave != null)
            chiave.Raccogli();
    }
    private void TerminaInterazione()
    {
        interacted = false;
        GestoreDialogoUI.Instance.NascondiDialogo();
    }
}
