    void OnLevelWasLoaded(){
		cav.GetComponent<Canvas> ().sortingOrder = 0;
		cav.GetComponent<Canvas> ().enabled = false;
	}
	public void  activateNewScene(string name){
		sl.AsgetOP ().allowSceneActivation = true;
		Scene sc = SceneManager.GetSceneByName(name);
		if (sc.IsValid ()) {
				SceneManager.SetActiveScene(sc);
		}
	}
