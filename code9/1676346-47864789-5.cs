    void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			var lookAtPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
			transform.LookAt (lookAtPos);
			RaycastHit Shot;
			if (Physics.Raycast(transform.position, transform.forward, out Shot))
			{
				Debug.Log ("Raycast hit");
				var score = Shot.transform.GetComponent<ZScore> ();
				if (score != null) {
                    Debug.Log ("Hit ZScore component");
					score.DeductPoints ();
				}
			}
		}
	}
