using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class RectCreater : MonoBehaviour
{
    public float Xmin = 0;
    public float Ymin = 0;
    public float XSize = 2;
    public float YSize = 2;
    public int Rotation = 0;
    public Vector2 Direction = Vector2.up;
    public float Distance = 3;

    public Rect Rect;
    public Rect RectTo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var gridCreater = GameObject.Find("GridCreater");
        if (gridCreater != null)
        {
            gridCreater.GetComponent<GridController>().UpdateGrid(Color.cyan);
        }
        // all grid colored white
        Rect = new Rect(Xmin, Ymin, XSize, YSize);//Quaternion.Euler(0, 0, Rotation) *
        var to =  (Rect.center + Direction * Distance);
        RectTo = CreateRectFromCenter(to, Rect.size.x, Rect.size.y);

        var hits = Physics2D.BoxCastAll(Rect.center, Rect.size, Rotation, Direction, Distance);
        if (hits.Length > 0)
        {
            foreach (var h in hits)
            {
                h.transform.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                h.transform.gameObject.tag = "Colored";
                //Debug.Log($"hit: {h.transform.gameObject.name}");
            }
            //Rect.position = hitLeft[0].point;
        }
    }
    public Rect CreateRectFromCenter(Vector2 center, float width, float height)
    {
        float halfWidth = width / 2;
        float halfHeight = height / 2;

        float xMin = center.x - halfWidth;
        float yMin = center.y - halfHeight;

        return new Rect(xMin, yMin, width, height);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        var thickness = 10;

        Handles.DrawBezier(Rect.center, RectTo.center, Rect.center, RectTo.center, Color.blue, null, thickness);
        Gizmos.DrawLine(Rect.center, RectTo.center);

        //Gizmos.DrawSphere(nextRect.center, 0.03f);
        ////////////////////
        DrawRect(Rect,Color.yellow);
        DrawRect(RectTo, Color.green);
    }

    void DrawRect(Rect rect, Color color)
    {
        Gizmos.color = color;
        Gizmos.matrix = Matrix4x4.TRS(rect.center, Quaternion.Euler(0, 0, Rotation), Vector3.one);
        Gizmos.DrawWireCube(Vector2.zero, rect.size);



        Gizmos.matrix = Matrix4x4.TRS(Vector2.zero, Quaternion.identity, Vector3.one);
        Gizmos.DrawSphere(rect.center, 0.03f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rect.position, 0.03f);
        //Debug.Log($"center rect: {rect.center}");
        //Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
        //Gizmos.DrawSphere(new Vector3(rect.center.x, rect.center.y, 0.01f), 0.03f);
    }

}
