using System.Numerics;
using UnityEngine;

public class CursorMovement
{
    public virtual void UpdatePosition(Vector3 pos)
    {
        // Default implementation (can be empty)
    }
    public virtual Vector3 CalculateNewPosition()
    { 
        // Default implementation (can be empty)
        return null;
        }
}


public class PromptCursorMovement : CursorMovement
{

    public override Vector3 CalculateNewPosition()
    {

        //myRigidbody.MovePosition(
        //    transform.position + change * Speed * Time.deltaTime
        //    );
        Vector2 com = myRigidbody.centerOfMass;
        offset = new Vector3(-com.x, -com.y, -5);
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition() //Camera.main.ScreenToWorldPoint(Input.mousePosition)
            + offset;
        //Debug.Log("Cursor: " + mousePosition);
        Vector3 smoothedPosition =
        Vector2.Lerp(transform.position, mousePosition,
        moveSpeed);
        //pos.x = Mathf.Clamp(pos.x, 0, 9);
        //pos.y = Mathf.Clamp(pos.y, 0, 19);
        return smoothedPosition;
    }

    public override void  UpdatePosition(Vector3 pos)
    {
        transform.position = pos;
        //transform.position += change * Speed * Time.deltaTime;
        //var pos = Camera.main.WorldToViewportPoint(transform.position);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
        //Debug.Log(transform.position);
        myRigidbody.MovePosition(transform.position);

    }

    }

public class ResponseACursorMovement : CursorMovement
{
    public float moveSpeed = 0.1f; // Adjust as necessary
    private Rigidbody2D myRigidbody;
    private Vector3 offset;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 newPos = CalculateNewPosition();
        UpdatePosition(newPos);
        DrawOnCanvas(newPos);
    }

    public override Vector3 CalculateNewPosition()
    {
        Vector2 com = myRigidbody.centerOfMass;
        offset = new Vector3(-com.x, -com.y, -5);
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition() + offset;
        Vector3 smoothedPosition = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        return smoothedPosition;
    }

    public override void UpdatePosition(Vector3 pos)
    {
        transform.position = pos;
        myRigidbody.MovePosition(transform.position);
    }

    private void DrawOnCanvas(Vector3 position)
    {
        // Assuming you have a reference to your Line class to call Draw on it
        Line line = GetComponent<Line>();  // Or however you're referencing it
        line.Draw(new Vector2(position.x, position.y), Camera.main, renderTexture);
    }

}

public class ResponseBCursorMovement : CursorMovement
{
    public override void Move(Vector2 position)
    {
        // Custom implementation for ResponseB version
        // Your cursor movement logic for ResponseB goes here
    }

    //I had to remove the @ from moothedPosition@  Response B error below
    public Vector3 smoothedPosition = default;

    public float lerpTime = 0.01f;
    public Vector2 hoverPosition = default;
    
    public static void UpdateCursor()
    {
        transform.position = smoothedPosition;
        hoverPosition = rb.transform.position;
        RenderTexture canvasTexture = GameObject.Find("MyCanvas").GetComponent<SpineObject>().unlitMaterial.GetTextureProperties()[0].texture;
        List<Vector4> vertices = new List<Vector4>();
        List<Color> colors = new List<Color>();
        FeedLiveData(camera, hoverPosition, vertices, colors);

    }

    void Update()
    {
        Vector2 myMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition, new Vector3(0f, 0f, 1f));
        UpdateCursorLerp(myMousePosition);

    }

    public void UpdateCursorLerp(Vector2 targetCursor)
    {
         transform.position = Vector2.Lerp(transform.position, targetCursor, lerpTime);
    }


}



// CursorMovement.cs Prompt
