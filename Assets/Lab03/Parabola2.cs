using UnityEngine;

public class Parabola2 : DrawableObject
{
    public override void Initalize()
    {
        for (int i = -10; i < 10; i++)
        {
            AddLineToObject(GetPointAt(i), GetPointAt(i + 1), Color.cyan);
        }
    }
    public float GetYPointatXof(float xValue)
    {
        float yValue;
        //y = x^2 + 2x+ 1
        yValue = Mathf.Pow(xValue, 2) + (2 * xValue) + 1;

        return yValue;
    }

    public Vector3 GetPointAt(float xValue)
    {
        return new Vector3(xValue, GetYPointatXof(xValue), 0);
    }
}
