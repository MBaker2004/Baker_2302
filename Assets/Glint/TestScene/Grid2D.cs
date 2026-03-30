using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grid2D : MonoBehaviour
{
    public Vector3 screenSize;
    public Vector3 origin;


    public float gridSize = 2f;
    float minGridSize = 0.6f;
    public float originSize = .6f;

     int divisionCount = 5;
     int minDivisionCount = 2;

    public Color axisColor = Color.white;
    public Color lineColor = Color.gray;
    public Color divisionColor = Color.yellow;

    public bool isDrawingOrigin = false;
    public bool isDrawingAxis = true;
    public bool isDrawingDivisions = true;
    public bool isDrawingObjects = true;

    //public List<DrawingObject> lineObjects;

    public int SceneIndex = 0;
    public List< List<DrawableObject> > SceneList;
    public List<string> SceneNameList;

    private void Start()
    {
        screenSize = new Vector3(Screen.width, Screen.height);
     
        origin = new Vector3(Screen.width / 2, Screen.height / 2);

        //lineObjects = new List<DrawingObject>();
        //lineObjects.Add(new Arrow());

        SceneList = new List<List<DrawableObject>>();
        SceneNameList = new List<string>();
        SetupScenes();
    }

    public virtual void SetupScenes()
    {

    }
    void Update()
    {
        GetInput();
        DrawGrid();

    }

    /// Grabs Input
    void GetInput()
    {
        Mouse mouse = Mouse.current;
        Keyboard keyboard = Keyboard.current;

        // checking if mouse and keyboard references are valid
        if (( mouse == null) || (keyboard == null))
        {
            Debug.LogError("Missing keyboard or mouse input");
            return; 
        }

        if ( mouse.middleButton.isPressed)
        {
            origin = mouse.position.ReadValue(); 
        }

      /*  if  (mouse.scroll.value.y)
        {

        }*/
    }

    /// Draws the grid
    void DrawGrid()
    {
        Vector3 posPoint = Vector3.zero;
        Vector3 negPoint = Vector3.zero;
        Vector3 pointOffset = Vector3.zero;



        int lineIndex = 0;
        bool stillDrawing = true;
        Color drawColor = lineColor;

        while (stillDrawing)
        {
            // Figureout what color to draw. 

            // Normal lines 
            drawColor = lineColor;
            
            // Division Lines 
            if ( (lineIndex%divisionCount) == 0)
            {
                drawColor = divisionColor; 
            }
            
            // Axis Lines 
            if (lineIndex == 0)
            {
                drawColor = axisColor; 
            }

            pointOffset = new Vector3(gridSize, gridSize, 0) * lineIndex;

            posPoint = origin + pointOffset;
            negPoint = origin - pointOffset;



            DrawGridLines(posPoint, drawColor);
            DrawGridLines(negPoint, drawColor);


            lineIndex++;

            if (IsOffScreen(negPoint) && IsOffScreen(posPoint))
            {
                stillDrawing = false;
            }
            //There's a logic to the puzzle, but I don't know what the pieces are.

            
            
        }


        
        
        DrawOrigin(); 



    }

    public bool IsOffScreen(Vector3 point)
    {
        /// Can you tell me how to get to Seaseme Street
        /// I am Seaseme Street
        bool vertical = ((point.y < 0) || (point.y > screenSize.y));
        bool horirzonal = ((point.x < 0) || (point.x > screenSize.x));

        return (vertical && horirzonal);
    }
    void DrawOriginAxis()
    {
        Vector3 xStart = new Vector3(0 , origin.y , 0);
        Vector3 xEnd = new Vector3(Screen.width, origin.y, 0 );
        Vector3 yStart = new Vector3(origin.x, 0, 0 );
        Vector3 yEnd = new Vector3(origin.x, Screen.height, 0 );

        DrawLine(xStart, xEnd, axisColor, false); 
        DrawLine(yStart, yEnd, axisColor, false);


    }

    void DrawGridLines(Vector3 point, Color drawColor  )
    {
        Vector3 xStart = new Vector3(0, point.y, 0);
        Vector3 xEnd = new Vector3(Screen.width, point.y, 0);
        Vector3 yStart = new Vector3(point.x, 0, 0);
        Vector3 yEnd = new Vector3(point.x, Screen.height, 0);

        DrawLine(xStart, xEnd, drawColor, false);
        DrawLine(yStart, yEnd, drawColor, false);


    }


    /// Draws the Diamond symbol at the Origin
    public void DrawOrigin()
    {
        if (!isDrawingOrigin)
        {
            return; 
        }

        Vector3 top     = origin + new Vector3(0,  (gridSize * originSize), 0);
        Vector3 bottom  = origin + new Vector3(0, -(gridSize * originSize), 0);
        Vector3 left    = origin + new Vector3( -(gridSize * originSize), 0, 0);
        Vector3 right   = origin + new Vector3(  (gridSize * originSize), 0, 0);

        DrawLine(top, left, axisColor, false); 
        DrawLine(left, bottom, axisColor, false);
        DrawLine(bottom, right, axisColor, false);
        DrawLine(right, top, axisColor, false);
        
    }

    /// Takes the potential grid space and outputs it into screen space
    /// <param name="gridSpace"></param>
    /// <returns>Vector3 translated to Screen Space</returns>
    public Vector3 GridToScreen(Vector3 gridSpace)
    {
        
        return (origin+(gridSpace * gridSize));
    }

    /// Takes in screen space and outputs it as grid space
    /// <param name="screenSpace"></param>
    /// <returns>Vector3 translated to Grid Space</returns>
    public Vector3 ScreenToGrid(Vector3 screenSpace)
    {
        return Vector3.zero;
    }

    public static Vector3 RotatePoint(Vector3 Center, float angle, Vector3 pointIN)
    {
        return Vector3.zero;
    }    

    /// Draws the given line object. If you are creating new line object, use the
    ///overload that takes parameters instead.
    /// <param name="line"></param>
    public void DrawLine(Line line, bool drawOnGrid = true)
    {
        if (!drawOnGrid)
        {
            Glint.AddCommand(line);
            return;
        }
        
        DrawLine(line.start, line.end, line.color, drawOnGrid);
    }

    /// Draws a line, This overload takes line parameters
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="color"></param>
    public void DrawLine(Vector3 start, Vector3 end, Color color, bool drawOnGrid = true)
    {
        if (!drawOnGrid)
        {
            Glint.AddCommand(new Line(start, end, color));
            return;
        }

        Glint.AddCommand(new Line(GridToScreen(start), GridToScreen(end), color));
    }
    //Draws the Origin Point (or Symbol)


    /*public void DrawObjects()
    {
       // if (!isdraw)

        if(lineObjects.Count == 0)
        {
            Debug.Log("Nothing to draw here");
            return;
        }

        foreach(DrawingObject obj in lineObjects)
        {
            obj.Draw(this);
        }
    }*/

    


}