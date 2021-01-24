    private bool shouldMove(string folderName) {
        // insert code to check if it should be moved;
    }
    private string getDestination(string folderName) {
        // insert code to return where it should be moved to.
    }
    // read the array
    List<string> folderNames = new List<string>(File.ReadAllLines("c:\\sometextfile.txt"));
   
    // do something with them 
    folderNames.ForEach(folderName =>
    {
        if (shouldMove(folderName))
          Directory.Move(x, GetDestination(folderName));
    });
