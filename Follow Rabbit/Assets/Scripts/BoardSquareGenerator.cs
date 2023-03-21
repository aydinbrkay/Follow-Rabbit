using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSquareGenerator : MonoBehaviour
{
    [SerializeField]private GameObject boardSquarePrefab;

    public void GenerateBoardSquares(int boardEdgeLength){
        for(int i = 0; i < boardEdgeLength; i++){
            for(int j = 0; j < boardEdgeLength; j++){
                SpawnBoardSquare(i, j);
            }
        }
    }

    private void SpawnBoardSquare(int x, int z){
        GameObject spawnedSquare = Instantiate(boardSquarePrefab);
        var boardSquare = spawnedSquare.GetComponent<BoardSquare>();
        if(boardSquare == null){
            boardSquare = spawnedSquare.AddComponent<BoardSquare>(); 
        }
        boardSquare.SetX(x);
        boardSquare.SetZ(z);
    }
}
