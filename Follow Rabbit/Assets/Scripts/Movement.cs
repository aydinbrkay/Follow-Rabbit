using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private int boardEdgeLength;

    private Vector3 GetMoveDirection(){
        Vector3 moveDirection = new Vector3(0f, 0f, 0f);

        if(Input.GetKeyDown(KeyCode.S)){
            moveDirection = Vector3.left;
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            moveDirection = Vector3.right;
        }
        else if(Input.GetKeyDown(KeyCode.A)){
            moveDirection = Vector3.forward;
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            moveDirection = Vector3.back;
        }
        return moveDirection;
    }

    private bool CheckIfMoveLegit(Vector3 moveDirection){
        Vector3 proposedPosition = transform.position + moveDirection;
        if(proposedPosition.x > 0 && proposedPosition.x < boardEdgeLength && 
        proposedPosition.z > 0 && proposedPosition.z < boardEdgeLength){
            return true;
        }
        else{
            return false;
        }
    }

    public void Move(){
        Vector3 moveDirection = GetMoveDirection();
        if(CheckIfMoveLegit(moveDirection)){
            transform.position += moveDirection;
        } 
    }
    
    public void setBoardEdgeLength(int boardEdgeLengthForMovement){
        boardEdgeLength = boardEdgeLengthForMovement;
    }
}
