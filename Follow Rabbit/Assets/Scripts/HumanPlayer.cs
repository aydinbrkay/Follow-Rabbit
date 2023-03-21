using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour
{
    private Movement movement;
    void Awake() {
        movement = gameObject.GetComponent<Movement>();
    }
    
    void Update()
    {
        Move();
    }

    public void Move(){
        movement.Move();
    }

    public void setBoardEdgeLengthForMovement(int boardEdgeLengthForMovement){
        movement.setBoardEdgeLength(boardEdgeLengthForMovement);
    }
}
