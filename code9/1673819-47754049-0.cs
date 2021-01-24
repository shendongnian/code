	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	public class RandomSpawner : MonoBehaviour {
		public GameObject objectToSpawn;
		public int spawnCount;
		public float minDistance = 2;
		public float maxDistance = 10;
		public float minPitchDegrees = 0;
		public float maxPitchDegrees = 45;
		public float minYawDegrees = -180;
		public float maxYawDegrees = 180;
		void Start () 
		{
			for (int i = 0; i < spawnCount; i++) 
			{
				float distance = minDistance + Random.value * (maxDistance - minDistance);
				float yaw = minYawDegrees + Random.value * (maxYawDegrees - minYawDegrees);
				float pitch = minPitchDegrees + Random.value * (maxPitchDegrees - minPitchDegrees);
				Vector3 position = RotationHelper.ConvertYawPitch (Vector3.forward * distance, yaw, pitch);
				Instantiate (objectToSpawn, position, Quaternion.identity);
			}
		}
	}
