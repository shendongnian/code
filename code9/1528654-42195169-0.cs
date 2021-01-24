	using System.Collections;
	using UnityEngine;
	public class ItemManager : MonoBehaviour
	{
		public ItemController Item;
		public Transform[] spawnPoints;
		private float spawnTime = 3f;
		void Start()
		{
			foreach (Transform spawnPoint in spawnPoints)
			{
				StartCoroutine(Spawn(spawnPoint)); // Spawn is implemented as a coroutine, so that a delay can be added
			}
		}
		IEnumerator Spawn(Transform spawnPoint)
		{
			yield return new WaitForSeconds(spawnTime); // See "Coroutines" in Unity documentation
			ItemController newItem = Instantiate(Item, spawnPoint.position, spawnPoint.rotation);
			newItem.OnDestroy += () => { StartCoroutine(Spawn(spawnPoint)); }; // Subscribe to the OnDestroy event. When it occurs, run the Spawn coroutine again.
		}
	}
	
