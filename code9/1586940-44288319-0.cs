    public Material materials[]; // assign the materials in the order you want
    
    public void getCharacters (string name)
    {
	int materialIndex = 0;
	
	for (int i = 0; i < text.lenght; i++)
	{
		char c = char.ToUpper(text[i]);
		GameObject go = GameObject.Find("" + c);
        go.SetActive (true);
		
		go.transform.position = new Vector3(i, 0, 0); // place the letters in the x axis separated by one meter
		
		// change the material
		go.GetCOmponent<Renderer>().sharedMaterial = materials[materialIndex];		
		materialIndex = (materialIndex + 1) % materials.length; // cycle the materials
		
        // setPosicionNext2EachOther
        // setColoredMaterial(Blue,Green,Red,Yellow) in this order 
        //Debug.Log("GameObject name Log: "+go.name);  
	}
}
