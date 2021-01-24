    using UnityEngine;
	using System.Collections;
	public class SetPositions : MonoBehaviour 
	{
		public GameObject PickUp;
		void Start() 
		{
			transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 0.5f, Random.Range(-9.5f, 9.5f));
		}
	}
