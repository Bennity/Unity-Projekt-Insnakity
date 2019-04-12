using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] Head player1;
    [SerializeField] Head player2;
    [SerializeField] ButtonManager buttonManager;

    static public string whoWon;

    private void Start()
    {
        player1 = player1.GetComponent<Head>();
        player2 = player2.GetComponent<Head>();
    }

    private void Update()
    {
        if (player1.isDead)
        {
            whoWon = "Player 2 Won";
            buttonManager.PlayAgain();
        }

        if (player2.isDead)
        {
            whoWon = "Player 1 Won";
            buttonManager.PlayAgain();
        }
    }
}
