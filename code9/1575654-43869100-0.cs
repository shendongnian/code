    public Vector3 forward
	{
		get
		{
			return this.rotation * Vector3.forward;
		}
		set
		{
			this.rotation = Quaternion.LookRotation(value);
		}
    }
