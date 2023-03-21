using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayerSpawner : MonoBehaviour
{
    [SerializeField]private GameObject computerPlayerPrefab;

    public GameObject SpawnComputerPlayer(){
        return Instantiate(computerPlayerPrefab);
    }
}
