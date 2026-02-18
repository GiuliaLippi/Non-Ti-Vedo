using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Botola : MonoBehaviour
{
    [Header("Keys")]
    public Key redKey;
    public Key blueKey;

    [Header("Scenes - Lei")]
    public List<string> leiScenes;

    [Header("Scenes - Lui")]
    public List<string> luiScenes;

    private bool opened = false;

    /// <summary>
    /// Questo metodo viene chiamato dallo script Interactable quando il player preme E.
    /// </summary>
    public void HandleInteraction()
    {
        if (opened) return;

        if (redKey != null && redKey.IsCollected)
        {
            OpenWithRedKey();
            return;
        }

        if (blueKey != null && blueKey.IsCollected)
        {
            OpenWithBlueKey();
            return;
        }

        Debug.Log("Serve una chiave per aprire la botola.");
    }

    private void OpenWithRedKey()
    {
        opened = true;
        Debug.Log("Botola aperta con Chiave Rossa.");
        LoadRandomScene(leiScenes);
    }

    private void OpenWithBlueKey()
    {
        opened = true;
        Debug.Log("Botola aperta con Chiave Blu.");
        LoadRandomScene(luiScenes);
    }

    private void LoadRandomScene(List<string> scenes)
    {
        if (scenes == null || scenes.Count == 0)
        {
            Debug.LogError("Lista scene vuota o non assegnata.");
            return;
        }

        int index = Random.Range(0, scenes.Count);
        SceneManager.LoadScene(scenes[index]);
    }
}