using UnityEngine;
using TMPro;

public class gameDecider : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = SceneSwitcher.whoWon;

        if (SceneSwitcher.whoWon == "Player 1 Won")
        {
            textMesh.color = Color.blue;
        }

        if (SceneSwitcher.whoWon == "Player 2 Won")
        {
            textMesh.color = Color.red;
        }
    }
}
