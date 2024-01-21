using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler()
    {
        gm.StartGame();
    }

    public void ActivateGameOverUI()
    {
        startMenuUI.SetActive(true);
    }

    public void QuitButtonHandler()
    {
        // Appelé lorsqu'on appuie sur le bouton "Quitter"
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
