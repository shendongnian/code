    public void Start() {
        string filename = "myFile.txt";
        CreateFile(filename); //call your create textfile method
        ReadFile(filename); //call read file method
    }
    
    public void CreateFile(string filename) {
        var myFile = File.Create(myPath); //create file
        //some other operations here like writing into the text file
        myFile.Close(); //close text file
    }
    
    public void ReadFile(string filename) {
        string text;
        var fileStream = new FileStream(filename, FileMode.Open, 
        FileAccess.Read); //open text file
        //vvv read text file (or however you implement it like here vvv
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {
            text = streamReader.ReadToEnd();
        }
        //finally, close text file
        fileStream.Close();
    }
