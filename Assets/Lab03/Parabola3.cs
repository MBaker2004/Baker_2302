using UnityEngine;

public class Parabola3 : DrawableObject
{
    public float step = .25f;

    public override void Initalize()
    {
        for (float i = -10; i < 10; i+= step)
        {
            AddLineToObject(GetPointAt(i), GetPointAt(i + step), Color.cyan);
        }
    }
    public float GetYPointatXof(float xValue)
    {
        float yValue;
        //-2x^2 + 10x + 12
        yValue = -2 * Mathf.Pow(xValue, 2) + (10 * xValue) + 12;

        return yValue;
    }

    public Vector3 GetPointAt(float xValue)
    {
        return new Vector3(xValue, GetYPointatXof(xValue), 0);
    }
}
