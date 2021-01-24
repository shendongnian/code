		interactables = new List<GameObject> ();
		objects = GameObject.FindGameObjectsWithTag ("questable");
		interactablesSize = objects.Length;
		Debug.Log (interactablesSize);
		for (int i = 0; i < interactablesSize; i++) {
			InteractionSettings iset = objects [i].GetComponentInChildren<InteractionSettings> ();
			if (iset != null) {
				interactables.Add(iset.gameObject);
			}
		}
