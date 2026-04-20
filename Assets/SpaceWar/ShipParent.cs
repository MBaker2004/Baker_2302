using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipParent : MovingObject
{
    public DrawableObject ship;
    public DrawableObject thrust;
    public float ShipMaxVelocity = 250f;
    public float ShipThrust = 20f;
    public float shipRotation = 120f;
    public void SetupA(DrawableGrid grid, int sceneIndex)
    {
        ship = new ShipA();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipAThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity; 
    }

    public void SetupB(DrawableGrid grid, int sceneIndex)
    {
        ship = new ShipB();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipBThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity;
    }

    public override void Tick()
    {
        base.Tick();
        UpdateSubObjects();
    }

    public void UpdateSubObjects()
    {
        ship.Position = this.Position;
        thrust.Position = this.Position;

        ship.Roation = this.Roation;
        thrust.Roation = this.Roation;

        ship.Scale = this.Scale;
        thrust.Scale = this.Scale;
    }
     

    public void AddThrust()
    {
        thrust.PerformDraw = true;
        Velocity += DrawingTools.CircleRadiusPoint(Vector3.zero, this.GetRotationinDegrees(), 1) * ShipThrust * Time.deltaTime;
    }

    public void NoThrust()
    {
        thrust.PerformDraw = false; 
    }

    public void RotateShip(float value)
    {
        this.Roation += value * shipRotation * Time.deltaTime * Mathf.Deg2Rad;
    }

    public void FireMissle(DrawableGrid grid, int sceneIndex)
    {
        Missle missleObject = new Missle();
        missleObject.Position = this.Position;
        missleObject.Position += DrawingTools.CircleRadiusPoint(Vector3.zero, this.GetRotationinDegrees(), 13);
        missleObject.CreateCollision(2, grid, sceneIndex);
        missleObject.LaunchMissle(this.GetRotationinDegrees());
        grid.AddObjectToScene(sceneIndex, missleObject);
        SpaceWarGrid.self.MovingObjectlist.Add(missleObject);
    }

    public void FireLaser(DrawableGrid grid, int sceneIndex)
    {

    }
}
