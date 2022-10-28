using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int tilesMovement = 1;
    public int MaxTilesMovement = 3;
    public float CheckInputRate = 1f;
    public GameObject EndTurnUI;

    bool isPlayerTurn;
    int totalMovement;

    public void PlayerTurn()
    {
        isPlayerTurn = true;
        EndTurnUI.SetActive(true);
        StartCoroutine(MovePlayer());
    }
    IEnumerator MovePlayer()
    {
        while (CanPlayerMove())
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.z += tilesMovement;
                totalMovement++;

            }
            if (Input.GetKey("s"))
            {
                pos.z -= tilesMovement;
                totalMovement++;

            }
            if (Input.GetKey("d"))
            {
                pos.x += tilesMovement;
                totalMovement++;

            }
            if (Input.GetKey("a"))
            {
                pos.x -= tilesMovement;
                totalMovement++;

            }


            transform.position = pos;

            yield return new WaitForSeconds(CheckInputRate);
        }
    }

    bool CanPlayerMove()
    {
        if (isPlayerTurn && totalMovement < MaxTilesMovement)
            return true;
        else
            return false;
    }

    public void PlayerEndedTurn()
    {
        totalMovement = 0;
        isPlayerTurn = false;
        EndTurnUI.SetActive(false);
    }
}
