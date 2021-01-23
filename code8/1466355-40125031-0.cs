    // creating the main delegates type
    delegate void DelegateVoid ();
    
    // declaring delegates
	DelegateVoid Del01 = d1;
	DelegateVoid Del02 = d2;
	DelegateVoid Del03 = d3;
    void Main(string[] args)
    {
        // looping and invoking delegates
        foreach (DelegateVoid d in mergedels (Del01, Del02, Del03)) {
			d.Invoke ();
		}
    }
    List<DelegateVoid> mergedels (params DelegateVoid[] dels)
	{
		List<DelegateVoid> dellist = new List<DelegateVoid> ();
		foreach (DelegateVoid d in dels) {
			dellist.Add (d);
		}
		return dellist;
	}
    static void d1 ()
	{
		Debug.WriteLine ("Hello 1");
	}
	static void d2 ()
	{
		Debug.WriteLine ("Hello 2");
	}
	static void d3 ()
	{
		Debug.WriteLine ("Hello 3");
	}
