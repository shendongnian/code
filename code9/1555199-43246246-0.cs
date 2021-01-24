    private void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Bow")
		{
				this.transform.parent = col.gameObject.transform;
				GameObject.Find("Controller").GetComponent<FixedJoint>().connectedBody = null;		
		}
    }
