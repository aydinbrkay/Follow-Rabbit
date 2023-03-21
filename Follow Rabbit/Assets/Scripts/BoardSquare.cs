using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSquare : MonoBehaviour
{
    private int x;
    private int z;
    
    void Start()
    {
        this.transform.position = Vector3.right * x + Vector3.forward * z;
    }

    public void SetX(int newX){
        x = newX;
    }

    public void SetZ(int newZ){
        z = newZ;
    }
}
