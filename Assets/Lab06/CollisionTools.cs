using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Rect = System.Drawing.Rectangle;
public static class CollisionTools 
{
    public static void DrawTriangle(TriangleData data, Color color, DrawableGrid grid = null)
    {
        Line lineA = new Line(data.PointA, data.PointB, color);
        Line lineB = new Line(data.PointB, data.PointC, color);
        Line lineC = new Line(data.PointC, data.PointA, color);

        if (grid == null)
        {
            // Info is in Screen Space 
            Glint.AddCommand(lineA);
            Glint.AddCommand(lineB);
            Glint.AddCommand(lineC); 
        }
        else
        {
            grid.DrawLine(lineA);
            grid.DrawLine(lineB);
            grid.DrawLine(lineC);
        }
    }

    public static void SetColor(DrawableObject thing,  Color color)
    {
        for (int i = 0; i < thing.LineList.Count; i++)
        {
            Line item = thing.LineList[i];
            item.color = color;
            thing.LineList[i] = item;

            // C# is acting weird... 
            // won't let me use foreach
            // wont' let me do LineList[i].color = color; 
        }
    }

    public static bool IsPointInCircle(Vector3 Point, Vector3 Center, float Radius)
    {
        bool result = false;

        Vector3 DistanceVector = Point - Center;
        if (DistanceVector.magnitude < Radius)
        {
            result = true;
        }
        return result; 
    }

    public static bool IsPointInRectangle(Vector3 Point, Rect Box)
    {
        return (Point.x > Box.X) && (Point.x < (Box.X + Box.Width))
            && (Point.y > Box.Y) && (Point.y < (Box.Y + Box.Height));
    }
    public static bool SameSide(Vector3 P1, Vector3 P2, Vector3 A, Vector3 B)
    {
        Vector3 cp1 = Vector3.Cross(B - A, P1 - A);
        Vector3 cp2 = Vector3.Cross(B - A, P2 - A);
        if(Vector3.Dot(cp1, cp2) >= 0)
        {
            return true;
        }
        return false;
    }

    public static bool IsPointInTriangle(Vector3 Point, TriangleData Triangle)
    {
        if (  SameSide(Point, Triangle.PointA, Triangle.PointB, Triangle.PointC ) &&
              SameSide(Point, Triangle.PointB, Triangle.PointA, Triangle.PointC ) &&
              SameSide(Point, Triangle.PointC, Triangle.PointA, Triangle.PointB )    )
        {
            return true; 
        }
        return false; 
    }
}
