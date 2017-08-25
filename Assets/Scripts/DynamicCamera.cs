using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//scalable camera based on screen size/resolution
public class DynamicCamera : MonoBehaviour {

    public static float pixelsToUnits = 2f;
    public static float scale = 2f;
    public Vector2 ScreenResolution = new Vector2(480, 320); 

    void Awake()
    {
        var camera = GetComponent<Camera>(); //get reference to camera in unity
        
        if(camera.orthographic) {
            scale = Screen.height / ScreenResolution.y;
            pixelsToUnits *= scale;
            camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
        }
    }
    
  
}
