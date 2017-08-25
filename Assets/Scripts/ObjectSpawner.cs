using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public GameObject[] prefabs;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);


    // this method runs first for this script
    // coroutine - run a script independent of a normal loop 
    void Start () {
        ResetDelay();
        StartCoroutine(ObstacleGenerator());
	}
	

    // method
    IEnumerator ObstacleGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
            var newTransform = transform;

            //Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity); changes to code below in "Build a gameobject utility class"
            GameObjectUtility.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
            ResetDelay();
        }

        StartCoroutine(ObstacleGenerator());
    }
	
    // reset spawner delay method

    void ResetDelay ()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }

}
