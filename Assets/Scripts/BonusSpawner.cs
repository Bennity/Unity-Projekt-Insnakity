using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] float padding = .5f;
    [SerializeField] List<GameObject> bonusList = new List<GameObject>();


    private float xMin, xMax, yMin, yMax;
    private int Index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

        foreach (var gameObject in bonusList)
        {
            Vector3 randomPosition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
            Instantiate(bonusList[Index], randomPosition, Quaternion.identity);
            Index++;
        }
    }
}
