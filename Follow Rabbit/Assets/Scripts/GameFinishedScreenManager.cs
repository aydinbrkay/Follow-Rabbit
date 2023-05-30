using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishedScreenManager : MonoBehaviour
{
    [SerializeField]private GameObject RouteSuccessScreen;
    [SerializeField]private GameObject RouteFailureScreen;

    public void ShowRouteSuccessScreen(){
        RouteSuccessScreen.SetActive(true);
    }

    public void ShowRouteFailureScreen(){
        RouteFailureScreen.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
