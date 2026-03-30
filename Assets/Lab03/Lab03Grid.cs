using UnityEngine;

public class Lab03Grid : DrawableGrid
{
    public override void SetupScenes()
    {
        int sceneIndex; 
        DrawableArrow newArrow;
        DrawableObject newGraph;

        AddScene("Empty Scene, Use Tab To Switch Scenes");


        sceneIndex = AddScene("Arrow, As is");
        newArrow = new DrawableArrow();
        AddObjectToScene(sceneIndex, newArrow);


        sceneIndex = AddScene("Arrow, Moved Forward");
        newArrow = new DrawableArrow();
        newArrow.Position = new Vector2(30, 0);
        AddObjectToScene(sceneIndex, newArrow);


        sceneIndex = AddScene("Arrow, 50% size");
        newArrow = new DrawableArrow();
        newArrow.Scale = (Vector3.one * .5f); 
        AddObjectToScene(sceneIndex, newArrow);


        sceneIndex = AddScene("Arrow, Moved Forward at 25% size");
        newArrow = new DrawableArrow();
        newArrow.Position = new Vector2(30, 0);
        newArrow.Scale = (Vector3.one * .25f);
        AddObjectToScene(sceneIndex, newArrow);

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
        newGraph.Roation = 45 * Mathf.Deg2Rad; //for next lecture
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola1: y = x^2");
        newGraph = new Parabola1();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola2: y = x^2 + 2x+ 1");
        newGraph = new Parabola2();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola3: y = -2x^2 + 10x + 12");
        newGraph = new Parabola3();
        AddObjectToScene(sceneIndex, newGraph);

        sceneIndex = AddScene("Parabola4: x = -y^3");
        newGraph = new Parabola4();
        AddObjectToScene(sceneIndex, newGraph);
    }
}
