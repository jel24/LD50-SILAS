using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Attributes")]
    public float moveDistance;
    public float moveTime;
    public LayerMask moveCheckLayerMask;
    public MoveManager moveManager;

    bool inputAllowed = true;

    private void Awake()
    {
        moveManager.NewTurn();
    }


    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (inputAllowed && context.performed && moveManager.CanMove())
            if (CheckIfValidMove(Vector2.left) && inputAllowed && context.performed)
            {
                inputAllowed = false;
                StartCoroutine(MoveToSpot(Vector2.left));
            }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (inputAllowed && context.performed && moveManager.CanMove())
            if (CheckIfValidMove(Vector2.right) && inputAllowed && context.performed)
            {
                inputAllowed = false;
                StartCoroutine(MoveToSpot(Vector2.right));
            }
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        if (inputAllowed && context.performed && moveManager.CanMove())
            if (CheckIfValidMove(Vector2.up) && inputAllowed && context.performed)
            {
                inputAllowed = false;
                StartCoroutine(MoveToSpot(Vector2.up));
            }
    }

    public void MoveDown(InputAction.CallbackContext context)
    {
        if (inputAllowed && context.performed && moveManager.CanMove())
            if (CheckIfValidMove(Vector2.down))
            {
                inputAllowed = false;
                StartCoroutine(MoveToSpot(Vector2.down));
            }
    }

    bool CheckIfValidMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, moveDistance, moveCheckLayerMask);
        return !hit;

    }
    IEnumerator MoveToSpot(Vector2 translation)
    {
        float time = 0f;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            transform.Translate(translation * moveDistance / moveTime *  Time.deltaTime);
            yield return null;
        }
        inputAllowed = true;
        moveManager.UseMove();

    }

    public void NewTurn()
    {
        moveManager.NewTurn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
