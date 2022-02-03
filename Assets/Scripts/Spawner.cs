using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dirt_prefab;

    private void Start()
    {
        
    }
    public void Dirt_Spawner() {

        GameObject Dirt_obj = Instantiate(dirt_prefab);
        Dirt_obj.transform.position = transform.position;
    }
    
}
