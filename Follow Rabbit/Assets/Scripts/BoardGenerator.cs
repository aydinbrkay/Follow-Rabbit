using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    private BoardEdgeWallGenerator boardEdgeWallGenerator;
    private BoardSquareGenerator boardSquareGenerator;
    private BoardEdgeWallCornerGenerator boardEdgeWallCornerGenerator;

    void Awake()
    {
        boardEdgeWallGenerator = gameObject.GetComponent<BoardEdgeWallGenerator>();
        boardSquareGenerator = gameObject.GetComponent<BoardSquareGenerator>();
        boardEdgeWallCornerGenerator = gameObject.GetComponent<BoardEdgeWallCornerGenerator>();
    }

    public void GenerateBoard(int boardEdgeLength){
        boardSquareGenerator.GenerateBoardSquares(boardEdgeLength);
        boardEdgeWallGenerator.GenerateBoardEdgeWalls(boardEdgeLength);
        boardEdgeWallCornerGenerator.GenerateBoardEdgeWallCorners(boardEdgeLength);
    }
}
