using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator shake (float durationShake, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;     
        float x = Random.Range(-1f, 1f) * magnitude;
        float y = Random.Range(-1f, 1f) * magnitude;

        yield return new WaitForSeconds(durationShake);

        transform.localPosition = new Vector3(x, y, originalPos.z);        
    }
}
