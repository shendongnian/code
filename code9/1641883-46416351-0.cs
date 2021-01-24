    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class EnemyMovement : MonoBehaviour {
    private Rigidbody2D enemyRigidbody;
    private int movementValue;
    private float timeTilNextMovement;
    private bool isMoving;
    [SerializeField]
    private float movementSpeed;
    private Vector2 moveRight;
    private Vector2 moveLeft;
	// Use this for initialization
	void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        moveRight = Vector2.right;
        moveLeft = Vector2.left;
        MakeMovementDecision();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeTilNextMovement -= Time.fixedDeltaTime;
        switch (movementValue)
        {
            case 0:
                Debug.Log("IDLE"); 
                isMoving = false;
                enemyRigidbody.velocity = Vector2.zero;
                break;
            case 1:
                Debug.Log("RIGHT");
				isMoving = true;
                transform.Translate(moveRight * (movementSpeed * Time.fixedDeltaTime));
                break;
            case 2:
                Debug.Log("LEFT");
				isMoving = true;
                transform.Translate(moveLeft * (movementSpeed * Time.fixedDeltaTime));
                break;
        }
        if (timeTilNextMovement < 0)
        {
            MakeMovementDecision();
        }
	}
    private void MakeMovementDecision()
    {
        movementValue = Random.Range(0, 3);
        timeTilNextMovement = Random.Range(2.0f, 5.0f);
    }
}
