using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteGenerator : MonoBehaviour
{
    private List<Tuple<int, int>> GetAvailablePositions(Tuple<int, int> current, int boardEdgeLength){
        List<Tuple<int, int>> availablePositions = new List<Tuple<int, int>>();
        List<Tuple<int, int>> allDirections = new List<Tuple<int, int>>();

        allDirections.Add(new Tuple<int, int>(current.Item1 - 1, current.Item2));
        allDirections.Add(new Tuple<int, int>(current.Item1 + 1, current.Item2));
        allDirections.Add(new Tuple<int, int>(current.Item1, current.Item2 - 1));
        allDirections.Add(new Tuple<int, int>(current.Item1, current.Item2 + 1));

        foreach(Tuple<int, int> tuple in allDirections){
            int x = tuple.Item1;
            int z = tuple.Item2;
            if(x > 0 && x < boardEdgeLength - 1 && z > 0 && z < boardEdgeLength - 1){
                availablePositions.Add(tuple);
            }
        }
        return availablePositions;
    }

    private Tuple<int, int> SelectRandomDirectionFromAvailable(List<Tuple<int, int>> availablePositions){
        return availablePositions[UnityEngine.Random.Range(0, availablePositions.Count - 1)];
    }

    private Tuple<int, int> GenerateRandomStartPoint(int boardEdgeLength){
        return new Tuple<int, int>(UnityEngine.Random.Range(1, boardEdgeLength - 1), UnityEngine.Random.Range(1, boardEdgeLength - 1));
    }

    public List<Tuple<int, int>> GenerateRoute(int routeLength, int boardEdgeLength){
        List<Tuple<int, int>> route = new List<Tuple<int, int>>();
        Tuple<int, int> start = GenerateRandomStartPoint(boardEdgeLength);
        Tuple<int, int> current = new Tuple<int, int>(start.Item1, start.Item2);
        route.Add(current);

        for(int i = 0; i < routeLength; i++){
            current = SelectRandomDirectionFromAvailable(GetAvailablePositions(current, boardEdgeLength));
            route.Add(current);
        }

        return route;
    }
}
