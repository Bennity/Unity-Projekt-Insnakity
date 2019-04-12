using System.Collections;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    [SerializeField] GameObject countDown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay ()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;

        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return null;
        }

        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
