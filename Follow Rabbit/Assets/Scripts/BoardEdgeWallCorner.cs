using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEdgeWallCorner : MonoBehaviour
{
    private float x;
    private float z;

    void Start()
    {
        this.transform.position = Vector3.right * x + Vector3.up * 0.5f + Vector3.forward * z;
    }

    public void SetX(float newX){
        x = newX;
    }

    public void SetZ(float newZ){
        z = newZ;
    }

    public void RotateOnAxisY(float rotation){
        transform.Rotate(0, rotation, 0);
    }
}
