using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public RecycleGameObject prefab;

    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();


    // method creates and instances

    private RecycleGameObject CreateInstance(Vector2 pos)
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;

        poolInstances.Add(clone);

        return clone;
    }


    // method returns instance

    public RecycleGameObject NextObject (Vector3 pos)
    {
        RecycleGameObject instance = null;

        // itirate through pool of instances
        foreach (var go in poolInstances)
        {
            if(go.gameObject.activeSelf != true)
            {
                instance = go;
                instance.transform.position = pos;
            }
        }

        if(instance == null)
             instance = CreateInstance(pos);

        instance.Restart();

        return instance;
    }


}
