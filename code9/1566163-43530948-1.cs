	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	public class PlayerMovement : MonoBehaviour {
		Vector2 _playerPosition;
		public GameObject Player; // assign your player prefab
		void Start () {
			_playerPosition = Vector2.zero;
		}
		void Update () {
			if (Input.GetKey(KeyCode.W)) {
				_playerPosition.y += 5f; 
			}
			if (Input.GetKey(KeyCode.S)) {
				_playerPosition.y -= 5f;
			}
			if (Input.GetKey(KeyCode.D)) {
				_playerPosition.x += 5f;
			}
			if (Input.GetKey(KeyCode.A)) {
				_playerPosition.x -= 5f;
			}
			
			Player.transform.position = _playerPosition;
		}
	}
