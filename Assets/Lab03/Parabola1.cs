using UnityEngine;

public class Parabola1 : DrawableObject
{
    public override void Initalize()
    {
        for (int i = -10; i < 10; i++)
        {
            AddLineToObject(GetPointAt(i), GetPointAt(i+1), Color.cyan);
        }
    }

    public float GetYPointatXof(float xValue)
    {
        float yValue;

        yValue = Mathf.Pow(xValue, 2);
        return yValue;
    }

    public Vector3 GetPointAt(float xValue)
    {
        return new Vector3(xValue, GetYPointatXof(xValue), 0);
    }
}
