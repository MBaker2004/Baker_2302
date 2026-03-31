using UnityEngine;

public class Lab04Grid : DrawableGrid
{

    public override void SetupScenes()
    {
        int sceneIndex;
        DrawableObject newGraph;

        AddScene("Empty Scene, Use Tab To Switch Scenes");

        sceneIndex = AddScene("Diamond");
        newGraph = new DrawDiamond();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond at scale of 20");
        newGraph = new DrawDiamond();
        newGraph.Scale = (Vector3.one * 20);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond: 20, 10");
        newGraph = new DrawDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond: 20, 10, Rotate: 45 degs");
        newGraph = new DrawDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        newGraph.SetRotationinDegrees(45);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Diamond: 20, 10, Rotate: 90 degs");
        newGraph = new DrawDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        newGraph.SetRotationinDegrees(90);
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Rotating Diamond");
        newGraph = new RotatingDiamond();
        newGraph.Scale = new Vector3(20, 10, 1);
        AddObjectToScene(sceneIndex, newGraph);
    }

}
