using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayAgain");       
    }

    public void Quit()
    {
        Application.Quit();
    }
}

