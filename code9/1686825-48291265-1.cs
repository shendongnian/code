    private void Update() {
		if(!rotating) {
			if(Input.GetKeyDown(KeyCode.D)) {
				rotating = true;
				StartCoroutine(RotatePlatform(90));
			}
			if(Input.GetKeyDown(KeyCode.A)) {
				rotating = true;
				StartCoroutine(RotatePlatform(-90));
			}
		}
	}
