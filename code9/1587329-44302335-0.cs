    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    // Attached to Main Camera
    public class CameraController : MonoBehaviour {
        // set manually in inspector
        public GameObject[] players;
        public float movementSpeed = 1.0f;
        public float rotationSpeed = 1.0f;
	
        private int currentPlayer;
        private float startTime;
        private float distanceToPlayer;
        private Vector3 startPosition;
        private Quaternion startOrientation;
	
        // Use this for initialization
        void Start () {
            currentPlayer = 0;
            ResetCamera();
        }
	
        // Update is called once per frame
        void Update () {
            float distanceCovered;
            float rotationCovered;
            float fractionTraveled;
            // switch to previous
            if (Input.GetButtonDown("left ctrl")) {
                if (currentPlayer == 0) currentPlayer = players.Length - 1;
                else currentPlayer--;
                ResetCamera();
            }
		
            // switch to nextPlayer
            if (Input.GetButtonDown("right ctrl")) {
                if (currentPlayer == players.Length - 1) currentPlayer = 0;
                    else currentPlayer++;
                    ResetCamera();
                }
		
                // Keep moving camera
                if (transform.position != players[currentPlayer].transform.position)
                {
                    distanceCovered = (Time.time - startTime) * movementSpeed;
                    fractionTraveled = distanceCovered / distanceToPlayer;
                    rotationCovered = (Time.time - startTime) * rotationSpeed;
                    // Lerp to player position
                    transform.position = Vector3.Lerp(
                        startPosition, 
                        players[currentPlayer].transform.position, 
                        fractionTraveled
                    );
                    // match player orientation
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation, 
                        players[currentPlayer].transform.rotation, 
                        rotationCovered
                    );
                // Stop moving camera
                } else {
                    // Match orientation
                    if (transform.rotation != players[currentPlayer].transform.rotation) 
                        transform.rotation = players[currentPlayer].transform.rotation;
			
                    // Set parent transform to current player
                    transform.parent = players[currentPlayer].transform;
                }
        }
	
        void ResetCamera() {
            transform.parent = null;
            startTime = Time.time;
            startPosition = transform.position;
            startOrientation = transform.rotation;
            distanceToPlayer = Vector3.Distance(
                transform.position, 
                players[currentPlayer].transform.position
            );
        }
    }
