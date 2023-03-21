using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayerSpawner : MonoBehaviour
{
    [SerializeField]private GameObject humanPlayerPrefab;

    public GameObject SpawnHumanPlayer(int x, int z, int boardEdgeLengthForMovement){
        GameObject humanPlayerGameObject = Instantiate(humanPlayerPrefab, new Vector3(x, 2, z), new Quaternion());
        humanPlayerGameObject.GetComponent<HumanPlayer>().setBoardEdgeLengthForMovement(boardEdgeLengthForMovement);
        return humanPlayerGameObject;
    }
}
