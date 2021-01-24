	void OnCollisionEnter(Collision obj){
		if (obj.gameObject.CompareTag ("Trash")) {
			obj.gameObject.SetActive (false);
			activateInactive = true;
            // Get the next dummy:
            GameObject dummy = GarbagesDummy[ActivatedDummyIndex];
            // Increase the index for next time:
            ActivatedDummyIndex++;
            // Activate that dummy:
            dummy.SetActive(true);
        }
    }
