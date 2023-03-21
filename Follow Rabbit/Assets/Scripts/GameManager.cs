using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject computerPlayer;
    private GameObject humanPlayer;
    [SerializeField]private GameObject boardGenerator;
    [SerializeField]private GameObject humanPlayerSpawner;
    [SerializeField]private GameObject computerPlayerSpawner;
    private Vector3 humanPlayerLastPosition;
    private List<Tuple<int, int>> route;
    private int routeIndex = 0;
    private int routeLength = 5;
    private int boardEdgeLength = 7;

    void Start() {
        GenerateBoard(boardEdgeLength);
        SpawnComputerPlayer();
    }
    void Update()
    {   
        SpawnHumanPlayer();
        CheckIfGameFinished();
    }

    private void GenerateBoard(int boardEdgeLength){
        boardGenerator.GetComponent<BoardGenerator>().GenerateBoard(boardEdgeLength);
    }
    private void SpawnComputerPlayer(){
        if(computerPlayer == null && humanPlayer == null){
            computerPlayer = computerPlayerSpawner.GetComponent<ComputerPlayerSpawner>().SpawnComputerPlayer();
            computerPlayer.GetComponent<ComputerPlayer>().StartMovement(routeLength, boardEdgeLength);
        }
    }

    private void CheckIfGameFinished(){
        if(humanPlayer != null){
            if(CheckIfRouteDoneByHumanPlayer() == false){
                CheckIfGoneOutOfRoute();
            }
            else{
                Debug.Log("Route Finished");
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    private bool CheckIfRouteDoneByComputerPlayer(){
        if(computerPlayer == null){
            return true;
        }
        else{
            if(computerPlayer.GetComponent<ComputerPlayer>().IsRouteDone()){
                return true;
            }
            else{
                return false;
            }
        }
    }

    private void SpawnHumanPlayer(){
        if(CheckIfRouteDoneByComputerPlayer() && humanPlayer == null){
            route = computerPlayer.GetComponent<ComputerPlayer>().GetRoute();
            Destroy(computerPlayer);
            humanPlayer = humanPlayerSpawner.GetComponent<HumanPlayerSpawner>().SpawnHumanPlayer(route[0].Item1, route[0].Item2, boardEdgeLength);
            humanPlayerLastPosition = humanPlayer.transform.position;
        }
    }

    private bool CheckIfGoneOutOfRoute(){
        Vector3 humanPlayerCurrentPosition = humanPlayer.transform.position;
        if(CheckIfHumanPlayerChangedPosition(humanPlayerCurrentPosition)){
            if(humanPlayerCurrentPosition.x == route[routeIndex + 1].Item1 && humanPlayerCurrentPosition.z == route[routeIndex + 1].Item2){
                routeIndex++;
                humanPlayerLastPosition = humanPlayerCurrentPosition;
                return false;
            }
            else{
                Debug.Log("Out of route");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        return false;
    }

    private bool CheckIfHumanPlayerChangedPosition(Vector3 humanPlayerCurrentPosition){
        if(humanPlayerCurrentPosition.x == humanPlayerLastPosition.x && humanPlayerCurrentPosition.z == humanPlayerLastPosition.z){
            return false;
        }
        return true;
    }

    private bool CheckIfRouteDoneByHumanPlayer(){
        if(routeLength == routeIndex){//First position in route is spawn point for computerPlayer.
            return true;
        }
        return false;
    }
}
