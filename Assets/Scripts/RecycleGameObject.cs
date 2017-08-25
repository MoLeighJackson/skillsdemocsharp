using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IRecycle
{
    void Restart();
    void Shutdown();
}


// class
public class RecycleGameObject : MonoBehaviour
{

    // list of components that implement IRecycle
    private List<IRecycle> recycleComponents;

    void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        recycleComponents = new List<IRecycle>();
        foreach (var component in components)
        {
            if(component is IRecycle) {
                recycleComponents.Add(component as IRecycle);
        }

    }

    // debug statement
    //Debug.Log(name + "Found " + recycleComponents.Count + " Components");
}


// methods
    public void Restart()
    {
        gameObject.SetActive(true);

        // loop through recycled components
        foreach (var component in recycleComponents)
        {
            component.Restart();
        }
    }

    public void Shutdown()
    {
        gameObject.SetActive(false);

        foreach (var component in recycleComponents)
        {
            component.Shutdown();
        }
    }
}
