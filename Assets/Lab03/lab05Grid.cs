using UnityEngine;

using Rect = System.Drawing.Rectangle; 

public class lab05Grid : DrawableGrid
{
    
    Rect box;
    Rect boxOnGrid;


    public override void SetupScenes()
    {

        int sceneIndex;
        // DrawableObject newGraph;

        sceneIndex = AddScene("Drawing Tools Test");

        box = new Rect(100, 100, 100, 100);
        boxOnGrid = new Rect(25, 50, 25, 10);



    }

    public override void Tick()
    {


        DrawingTools.DrawRectangle(box, Color.red);
        DrawingTools.DrawRectangle(boxOnGrid, Color.green);
    }
}
