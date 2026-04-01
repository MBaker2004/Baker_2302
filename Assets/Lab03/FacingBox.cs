using UnityEngine;

public class FacingBox : DrawableObject
{
    public override void Initalize()
    {
        AddLineToObject(new Vector3(1, 1, 0), new Vector3(-1, 1, 0), Color.cyan);
        AddLineToObject(new Vector3(-1, 1, 0), new Vector3(-1, -1, 0), Color.cyan);
        AddLineToObject(new Vector3(-1, -1, 0), new Vector3(1, -1, 0), Color.cyan);
        AddLineToObject(new Vector3(1, -1, 0), new Vector3(1, 1, 0), Color.cyan);
        AddLineToObject(new Vector3(0, 0, 0), new Vector3(1, 0, 0), Color.cyan);
    }

    public override void Tick()
    {
        //Vector3 FacingVector = DrawableGrid.Instance.MousePosition - DrawableGrid.Instance.origin;
        Roation = V3ToAngle(DrawableGrid.Instance.origin, DrawableGrid.Instance.MousePosition);
    }
}
