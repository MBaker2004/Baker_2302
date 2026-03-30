using UnityEngine;

public class Parabola4 : DrawableObject
{
    public override void Initalize()
    {
        for (int i = -10; i < 10; i++)
        {
            AddLineToObject(GetPointAt(i), GetPointAt(i + 1), Color.cyan);
        }
    }
    public float GetYPointatXof(float yValue)
    {
        float xValue;

        xValue = Mathf.Pow(-yValue, 3);
        return xValue;
    }

    public Vector3 GetPointAt(float yValue)
    {
        return new Vector3(yValue, GetYPointatXof(yValue), 0);
    }
}
