using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayerMovement : MonoBehaviour
{
    public void Move(List<Tuple<int, int>> route){
        StartCoroutine(MoveAccordingToRoute(route));
    }

    private IEnumerator MoveAccordingToRoute(List<Tuple<int, int>> route){
        foreach(Tuple<int, int> position in route){
            StartCoroutine(ChangePosition(3, new Vector3(position.Item1, 2, position.Item2)));
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<ComputerPlayer>().RouteDone();
    }

    IEnumerator ChangePosition(int seconds, Vector3 position){
        transform.position = position;
        yield return new WaitForSeconds(seconds);
    }

}
