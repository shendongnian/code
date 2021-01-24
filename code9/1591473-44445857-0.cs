    using System.IO; 
    
    string inp;
    
    void Update () 
    {
        if
        (
            Input.anyKeyDown
        )
        {
        inp=inp+(string)Input.inputString;
        string path="txt/txttst001.txt";
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path,true)){
			file.Write(inp);
		}
    }
    }
