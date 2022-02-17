using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera photoCamera;
    public RenderTexture photoTexture;
    public Vector2 moveBounds;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void checkMouse()
    {
        if (Input.mousePosition.x > Screen.width - moveBounds.x)
        {
            //move camera
        }
    }

    void takePhoto()
    { 
        Texture2D tex;
        tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0,0,Screen.width, Screen.height), 0, 0, false);
        tex.Apply();
        GetComponent<Renderer>().material.mainTexture = tex;

    }
}
