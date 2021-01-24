		// Use this for initialization
	void Start () { //************************************Start
		numbers = new float[] { 1.0f,2.0f,3.0f,1.0f,2.0f,3.0f };
        
		for(var num in numbers.GetDuplicates())
			print(num);
	}
