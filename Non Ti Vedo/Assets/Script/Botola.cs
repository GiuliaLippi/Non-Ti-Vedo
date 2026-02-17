using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Trapdoor : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private Transform player;

    [Header("Keys")]
    [SerializeField] private Key redKey;
    [SerializeField] private Key blueKey;

    [Header("Scenes - Lei")]
    [SerializeField] private List<string> leiScenes;

    [Header("Scenes - Lui")]
    [SerializeField] private List<string> luiScenes;

    private bool opened = false;

    private void Awake()
    {
        InitializeReferences();
    }

    private void Update()
    {
        if (opened) return;

        if (IsPlayerInRange() && Input.GetKeyDown(KeyCode.E))
        {
            TryOpenTrapdoor();
        }
    }

    private void TryOpenTrapdoor()
    {
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
        string sceneName = scenes[index];

        SceneManager.LoadScene(sceneName);
    }

    private bool IsPlayerInRange()
    {
        if (player == null) return false;

        float distance = Vector3.Distance(player.position, transform.position);
        return distance <= interactionDistance;
    }

    private void InitializeReferences()
    {
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
                player = foundPlayer.transform;
        }
    }
}
