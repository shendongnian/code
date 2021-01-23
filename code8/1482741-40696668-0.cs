    public void DestroyObjects(string tag)
	{
		GameObject[] Obj = GameObject.FindGameObjectsWithTag(tag);
		if(Obj==null)
			return;
		else
		{
			Debug.Log(Obj.Length);
			for(int i=0; i< Obj.Length; i++)
			{
				Destroy(Obj[i]);
			}
			Debug.Log(tag + "Objects Destroyed!");
		}
	}
