using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour {

    [HideInInspector]
    public GameManager gameManager;
    public List<Transform> positions = new List<Transform>();

    int currentPosition = 0;
    float moveDelay = 0.8f;
    float collisionCheckDelay = 0.2f;
    bool collidedWithPlayer = false;

    // Use this for initialization
    void Start () {
        transform.position = positions[currentPosition].position;
        StartCoroutine(MoveToNextPosition());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            collidedWithPlayer = true;
        }

    }

    IEnumerator MoveToNextPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);

            currentPosition++;

            if (currentPosition >= positions.Count)
            {
                Die();
                StopAllCoroutines();
                yield return null;
            }

            transform.position = positions[currentPosition].transform.position;
           
            if (positions[currentPosition].GetComponent<PedestrianPosition>().isDangerPosition)
            {
                yield return new WaitForSeconds(collisionCheckDelay);
                if (collidedWithPlayer)
                {
                    gameManager.UpdateScore();
                    collidedWithPlayer = false;

                } else
                {
                    gameManager.LoseOneLife();
                    Die();
                }
            }

        }
    }

    void Die()
    {
        Destroy(transform.parent.gameObject);
    }
    
}
