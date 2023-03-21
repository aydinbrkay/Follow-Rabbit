using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    private bool isRouteDone = false;
    private ComputerPlayerMovement computerPlayerMovement;
    private List<Tuple<int, int>> route;
    private RouteGenerator routeGenerator;

    public void StartMovement(int routeLength, int boardEdgeLength){
        computerPlayerMovement = gameObject.GetComponent<ComputerPlayerMovement>();
        routeGenerator = gameObject.GetComponent<RouteGenerator>();
        route = routeGenerator.GenerateRoute(routeLength, boardEdgeLength);
        computerPlayerMovement.Move(route);
    }

    public void RouteDone(){
        isRouteDone = true;
    }

    public bool IsRouteDone(){
        return isRouteDone;
    }

    public List<Tuple<int, int>> GetRoute(){
        return route;
    }
}
