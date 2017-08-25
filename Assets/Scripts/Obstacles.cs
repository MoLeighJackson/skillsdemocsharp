using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// change artwork spawned onto track
public class Obstacles : MonoBehaviour, IRecycle {

    // properties

    //sprites array
    public Sprite[] sprites;

    // box collider aligns with size of sprites
    //public Vector2 colliderOffset = Vector2.zero;

// restart method

    public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];

        //logic to resize collider (video "Dynamically resize 2d box colliders")
        //var collider = GetComponent<BoxCollider2D>();
        //collider.size = renderer.bounds.size;
        //size.y += colliderOffset.y;

        //collider.size = size;
        //collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);
   
        
        //collider.size = renderer.bounds.size; // gives correct size based on current sprite in renderer [changed in video "Dynamically resize 2d box colliders]

     }



// shutdown method
    public void Shutdown()
    {

    }
}
