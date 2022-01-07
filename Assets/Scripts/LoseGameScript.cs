using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameScript : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    [SerializeField] Transform collisionChecker;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Blocker"))
        {
            gameManager.StopGame();
        }
    }

    private void Update()
    {
        foreach (Collider collider in Physics.OverlapSphere(collisionChecker.position, 0.5f))
        {
            if (collider.CompareTag("Blocker"))
            {
                gameManager.StopGame();
            }
        }
    }



}
