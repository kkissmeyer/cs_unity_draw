using System.Numerics;
using UnityEngine;

public class Brush
{
    public virtual Line Draw(Vector2 position, Camera cam, RenderTexture renderTexture)
    {
        // Default implementation (can be empty)
        return null; 
    }
}

public class PromptBrush : Brush
{

    // Texture Brush.cs
     public override Line Draw(Vector2 position, Camera cam, RenderTexture renderTexture)
        {
            // Vector3 worldPos = cam.ScreenToWorldPoint(position);
            // Debug.Log(transform);
            // Vector3 localPos = transform.InverseTransformPoint(worldPos);
            // int x = Mathf.RoundToInt(localPos.x + textureWidth / 2f - brushSize / 2f);
            // int y = Mathf.RoundToInt(localPos.y + textureHeight / 2f - brushSize / 2f);
            int x = Mathf.RoundToInt(position[0]);
            int y = Mathf.RoundToInt(position[1]);
            Texture2D texture = GameObject.Find("DrawingCanvas").GetComponent<DrawingCanvas>().texture;
            Debug.Log(brushPixels[0]);
            if (x >= 0 && x < textureWidth && y >= 0 && y < textureHeight)
            {
                // Debug.Log($@"x: {x} 
                //              y: {y}");
                texture.SetPixels(x, y, brushSize, brushSize, brushPixels);
                texture.Apply();
            }

            Refresh?.Invoke();
            return null;
        }
}

public class ResponseABrush : Brush
{
    //Uses Prompt Version of method
    // Texture Brush.cs
     public override Line Draw(Vector2 position, Camera cam, RenderTexture renderTexture)
        {
            // Vector3 worldPos = cam.ScreenToWorldPoint(position);
            // Debug.Log(transform);
            // Vector3 localPos = transform.InverseTransformPoint(worldPos);
            // int x = Mathf.RoundToInt(localPos.x + textureWidth / 2f - brushSize / 2f);
            // int y = Mathf.RoundToInt(localPos.y + textureHeight / 2f - brushSize / 2f);
            int x = Mathf.RoundToInt(position[0]);
            int y = Mathf.RoundToInt(position[1]);
            Texture2D texture = GameObject.Find("DrawingCanvas").GetComponent<DrawingCanvas>().texture;
            Debug.Log(brushPixels[0]);
            if (x >= 0 && x < textureWidth && y >= 0 && y < textureHeight)
            {
                // Debug.Log($@"x: {x} 
                //              y: {y}");
                texture.SetPixels(x, y, brushSize, brushSize, brushPixels);
                texture.Apply();
            }

            Refresh?.Invoke();
            return null;
        }
}

public class ResponseBBrush : Brush
{
    // Texture Brush.cs
    public override Line Draw(Vector2 position, Camera cam, RenderTexture renderTexture)
    {
        int x = Mathf.RoundToInt(position[0]);
        int y = Mathf.RoundToInt(position[1]);

        Texture2D texture = GameObject.Find("Canvas").GetComponent<DrawingCanvas>().texture;

        if (x >= 0 && x < textureWidth && y >= 0 && y < textureHeight)
        {
            texture.SetPixels(x, y, brushSize, brushSize, brushPixels);
            texture.Apply();
        }

        Refresh?.Invoke();
        return null;       
    }
}


