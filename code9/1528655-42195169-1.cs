	using System;
	using UnityEngine;
	public class ItemController : MonoBehaviour
	{
		public event Action OnDestroy;
		void DestroyObject ()
		{
			Destroy(gameObject);
			if (OnDestroy != null) OnDestroy(); // OnDestroy is null if there are no subscribers
		}
		void OnMouseDown () // For testing. Unity calls this method when a collider on this gameObject is clicked
		{
			DestroyObject();
		}
	}
