using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int tilesMovement = 1;
    public int MaxTilesMovement = 3;
    public float CheckInputRate = 1f;

    [SerializeField] TurnsManager turnsManager;
    [SerializeField] Transform playerTransform;

    public void EnemyTurn()
    {
        StartCoroutine(MovePlayer());
    }
    IEnumerator MovePlayer()
    {
        while (tilesMovement < MaxTilesMovement)
        {
            float dist = Vector3.Distance(playerTransform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 1f);
            tilesMovement++;

            yield return new WaitForSeconds(CheckInputRate);
        }

        EnemyTurnEnded();
    }

    void EnemyTurnEnded()
    {
        turnsManager.TurnEnded();
        tilesMovement = 0;
    }
}