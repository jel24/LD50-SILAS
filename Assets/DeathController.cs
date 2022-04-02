using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DeathController : MonoBehaviour
{
    public Seeker seeker;
    public int movesPerTurn;
    public Transform target;
    public TriggeredEvent onDeathTurnEnd;
    public float moveDistance, moveTime, moveDelay;

    int movesLeft;
    int currentWaypoint;
    Path path;


    public void NewTurn()
    {
        movesLeft = movesPerTurn;
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        TakeTurn();

    }

    void TakeTurn()
    {
        if (movesLeft > 0)
        {
            Debug.Log(movesLeft);
            StartCoroutine(MoveToSpot(path.vectorPath[1] - transform.position));
        } else
        {
            onDeathTurnEnd.Trigger();
        }
    }

    IEnumerator MoveToSpot(Vector2 translation)
    {
        float time = 0f;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            transform.Translate(translation / moveTime * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(moveDelay);
        movesLeft--;
        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }
}
