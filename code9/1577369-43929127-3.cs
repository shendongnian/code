	using UnityEngine;
	using System.Collections;
	public class ObjectPoolInstantiator : MonoBehaviour {
		public GameObject pool1Prefab;
		public GameObject pool2Prefab;
		private ObjectPool pool1;
		private ObjectPool pool2;
		void Start () {
			pool1 = new ObjectPool(pool1Prefab, 5);
			pool2 = new ObjectPool(pool2Prefab, 5);
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown(KeyCode.Space))
			{
				GameObject pool1Element = pool1.get();
				pool1Element.SetActive(true);
				Debug.Log("poo1 size : " + pool1.size());
				GameObject pool2Element = pool2.get();
				pool2Element.SetActive(true);
				Debug.Log("poo2 size : " + pool2.size());
			}
		}
	}
