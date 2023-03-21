using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEdgeWallGenerator : MonoBehaviour
{
    [SerializeField]private GameObject boardEdgeWallPrefab;
    public void GenerateBoardEdgeWalls(int boardEdgeLength){
        for(int i = 1; i < boardEdgeLength - 1; i++){//Excluding corners
            SpawnBoardEdgeWall(i, 0, boardEdgeLength);
            SpawnBoardEdgeWall(0, i, boardEdgeLength);
            SpawnBoardEdgeWall(boardEdgeLength - 1, i, boardEdgeLength);
            SpawnBoardEdgeWall(i, boardEdgeLength - 1, boardEdgeLength);
        }
    }

    private void SpawnBoardEdgeWall(int x, int z, int boardEdgeLength){
        GameObject spawnedEdgeWall = Instantiate(boardEdgeWallPrefab);
        var boardEdgeWall = spawnedEdgeWall.GetComponent<BoardEdgeWall>();
        if(boardEdgeWall == null){
            boardEdgeWall = spawnedEdgeWall.AddComponent<BoardEdgeWall>();
        }
        boardEdgeWall.SetX(x);
        boardEdgeWall.SetZ(z);
        if(x == 0 || x == boardEdgeLength - 1){
            boardEdgeWall.RotateOnAxisY(90);
        }
    }
}
