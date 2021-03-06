using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
public class DeathController : MonoBehaviour
{
    public Seeker seeker;
    public int movesPerTurn;
    public TriggeredEvent onDeathTurnEnd, onDestroyDecoy;
    public float moveDistance, moveTime, moveDelay;

    int movesLeft;
    int currentWaypoint;
    Path path;
    Transform target;


    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }


    public void NewTurn()
    {
        movesLeft = movesPerTurn;
        AstarPath.active.Scan();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("GameOver", .5f);
        } else if (collision.tag == "Decoy")
        {
            target = FindObjectOfType<PlayerController>().transform;
            onDestroyDecoy.Trigger();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");

    }

    public void OnDecoyUse()
    {
        target = FindObjectOfType<Decoy>().transform;
    }
}
