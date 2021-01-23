	using UnityEngine;
	using UnityEngine.UI;
	using System;
	using System.Threading;
	public class ButtonClick : MonoBehaviour {
		private Vector3 starPos;
		private int starCounter;
        private bool executeSpawn;
		private int[] starTypes;
		private int totalStarTypes = 4;
		public Button button;
		public UnityEngine.UI.Text starCounterText;
		private Image starImage;
		// Use this for initialization
		void Start () {
			starTypes = new int[totalStarTypes];
		}
		void Update(){
			if (Input.GetMouseButtonDown (0)) {
				starCounter++;
				executeSpawn = true;
			}
			
			if(executeSpawn) {
				SpawnStar (i % 5);
				executeSpawn = false;
			}
		}
		// Update is called once per frame
		public void UpdateStar () {
			starCounterText.text = "Star Counter: " + starCounter;
		}
		public void SpawnStar(int type){
			if (type == 0) {
				Debug.Log ("White Star Spawned!");
			}
			if (type == 1) {
				Debug.Log ("Red Star Spawned!");
			}
			if (type == 2) {
				Debug.Log ("Yellow Star Spawned!");
			}
			if (type == 3) {
				Debug.Log ("Blue Star Spawned!");
			}
		}
	}
