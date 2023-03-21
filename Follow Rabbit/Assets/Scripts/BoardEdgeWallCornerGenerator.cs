using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEdgeWallCornerGenerator : MonoBehaviour
{
    [SerializeField]private GameObject boardEdgeWallCornerPrefab;
    private void SpawnBoardEdgeWallCorner(float x, float z, float rotation){
        GameObject spawnedEdgeWallCorner = Instantiate(boardEdgeWallCornerPrefab);
        var boardEdgeWallCorner = spawnedEdgeWallCorner.GetComponent<BoardEdgeWallCorner>();
        if(boardEdgeWallCorner == null){
            boardEdgeWallCorner = spawnedEdgeWallCorner.AddComponent<BoardEdgeWallCorner>();
        }

        boardEdgeWallCorner.SetX(x);
        boardEdgeWallCorner.SetZ(z);
        boardEdgeWallCorner.RotateOnAxisY(rotation);
    }

    public void GenerateBoardEdgeWallCorners(int boardEdgeLength){
        SpawnBoardEdgeWallCorner(-0.5f, 0, 0);
        SpawnBoardEdgeWallCorner(0, boardEdgeLength -0.5f, 90.0f);
        SpawnBoardEdgeWallCorner(boardEdgeLength - 1.0f, -0.5f, 270.0f);
        SpawnBoardEdgeWallCorner(boardEdgeLength - 0.5f, boardEdgeLength -1.0f, 180.0f);
    }
}
