	void OnCollisionEnter(Collision col)
	{
		var me = gameObject.GetComponent<Renderer>();
		var other = col.gameObject.GetComponent<Renderer>();
		if (me != null && other != null)
		{
			if (me.sharedMaterial.color == other.sharedMaterial.color)
			{
				// congratulation you are colliding with same color.
			}
		}
	}
