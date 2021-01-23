    void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<MoveBall>().mats [1] = yourMaterial;;
		}
	}
