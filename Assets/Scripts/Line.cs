using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class Line : MonoBehaviour
{
    [SerializeField] Transform headList;
    [SerializeField] private float padding = .1f;

    LineRenderer linerenderer = new LineRenderer();
    EdgeCollider2D edgecollider = new EdgeCollider2D();
    List<Vector2> pointsList = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        edgecollider = GetComponent<EdgeCollider2D>();
        SpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!headList.Equals(null))
        {
            if (Vector3.Distance(pointsList.Last(), headList.position) > padding)
            {
                SpawnPoint();
            }
        }
    }

    void SpawnPoint()
    {      
        edgecollider.points = pointsList.ToArray<Vector2>();
        pointsList.Add(headList.position);
        linerenderer.positionCount = pointsList.Count;
        linerenderer.SetPosition(pointsList.Count - 1, headList.position);
    }
}
