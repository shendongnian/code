	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System;
	public class ObjectPool {
		private List<GameObject> poolList;
		private int initialSize;
		private GameObject prefab;
		private Func<GameObject> instantiationMethod;//Use this to do custom processing
		public ObjectPool(GameObject prefab, int initialSize)
		{
			this.prefab = prefab;
			this.initialSize = initialSize;
			createPool();
		}
		public ObjectPool(GameObject prefab, int initialSize, Func<GameObject> instantiationMethod)
		{
			this.prefab = prefab;
			this.initialSize = initialSize;
			this.instantiationMethod = instantiationMethod;
			createPool();
		}
		private List<GameObject> createPool()
		{
			poolList = new List<GameObject>();
			for (int i = 0; i < initialSize; i++)
			{
				createNewPoolObject();
			}
			return poolList;
		}
		private GameObject createNewPoolObject()
		{
			GameObject poolEntry = null;
			poolEntry = (instantiationMethod == null) ? MonoBehaviour.Instantiate(prefab) : instantiationMethod();
			
			poolEntry.SetActive(false);
			poolList.Add(poolEntry);
			return poolEntry;
		}
		public GameObject get()
		{
			GameObject poolElement = poolList.Find(obj => !obj.activeInHierarchy);
			if(poolElement == null)
			{
				poolElement = createNewPoolObject();
			}
			return poolElement;
		}
		public int size()
		{
			return poolList.Count;
		}
	}
