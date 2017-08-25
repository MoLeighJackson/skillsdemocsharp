using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBg : MonoBehaviour {

    public int textureSize = 32;
    public bool scaleHorizontally = true;
    public bool scaleVertically = true;
	
	void Start () {

        //calculate how many tiles will fit in screen's resolution

        //var newWidth = Mathf.Ceil(Screen.width / (textureSize * DynamicCamera.scale)); becomes code below in "Emulate parallax scrolling"
        var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil(Screen.width / (textureSize * DynamicCamera.scale));

        //this code: var newHeight = Mathf.Ceil(Screen.height / (textureSize + DynamicCamera.scale)); becomes code below in "Emulate parallax scrolling"
        var newHeight = !scaleVertically ? 1 : Mathf.Ceil(Screen.height / (textureSize * DynamicCamera.scale));
        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);
		
	}
	

}
