using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOffscreenObject : MonoBehaviour {


    // properities

    // event that triggers reset game
    public float offset = 32f;
   
    
    //end game
    public delegate void OnDestroy();
    public event OnDestroy DestroyCallback;

    private bool offscreen;
    private float offscreenX = 0;
    private Rigidbody2D body2d;

    //method

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    //method

    void Start ()
    {
        offscreenX = (Screen.width/DynamicCamera.pixelsToUnits) / 2 + offset;
    }



    // method uses conditions to check if object is offscreen
    void Update()
    {
        var positionX = transform.position.x;
        var directionX = body2d.velocity.x;

        if (Mathf.Abs(positionX) > offscreenX)
        {
            if (directionX < 0 && positionX < -offscreenX)
            {
                offscreen = true;
            }
            else if (directionX > 0 && positionX > offscreenX)
            {
                offscreen = true;
            }
            else
            {
                offscreen = false;
            }

            if (offscreen)
            {
                OffTrack();

            }


        }
    }
        public void OffTrack()
        {
            offscreen = false;
            GameObjectUtility.Destroy (gameObject);

        if (DestroyCallback != null) 
        {
            DestroyCallback();
        }


    }


    }


