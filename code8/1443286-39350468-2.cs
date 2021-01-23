    void OnCollisionEnter2D(Collision2D col)
	{
		Color myColor = GetComponent<Renderer> ().material.color;
		Color otherColor = col.gameObject.GetComponent<Renderer> ().material.color;
		if(myColor.IsEqualTo(otherColor))
		{
			Destroy(col.gameObject);
		} 
	}
