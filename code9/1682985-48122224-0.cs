    public void loadData()
    {
        GetComponent<SavingLoading>().Load(GameObject.Find("LoginSystem").GetComponent<LoginSystem>().Username);
	    StartCoroutine(() => {
		    yield return new WaitUntil(() => GetComponent<SavingLoading>().LoadedData != "");
		    string[] Data = GetComponent<SavingLoading>().LoadedData.Split(',');
		    Level = Convert.ToInt32(Data[0]);
		    CurrentXp = Convert.ToInt32(Data[1]);
		    currentHealth = Convert.ToInt32(Data[2]);
		    maxHealth = Convert.ToInt32(Data[3]);
		    Vector3 LoadedPos = new Vector3(Convert.ToSingle(Data[4]), Convert.ToSingle(Data[5]), Convert.ToSingle(Data[6]));
		    transform.position = LoadedPos;
	    });
    }
