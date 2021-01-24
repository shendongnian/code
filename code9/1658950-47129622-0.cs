	void Update () {
		if(save_click_name != clickedButtonName)
			UnityEngine.Debug.Log ("Before: printing in update method save click name" + save_click_name);
		save_click_name = clickedButtonName;
		if(Input.GetKeyUp(KeyCode.A)) {
			int rand = UnityEngine.Random.Range(0,10);
			clickedButtonName = "something " + rand.ToString();
		}
	}
