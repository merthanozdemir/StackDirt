using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGoUp : MonoBehaviour
{
    public static CameraGoUp instance;
    public Vector3 targetPoss;
    private float smoothMove = 1f;
    void Start()
    {
        targetPoss = transform.position;
     
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, targetPoss, smoothMove * Time.deltaTime);
    }
}
