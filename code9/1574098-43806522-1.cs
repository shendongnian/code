    public IEnumerable<MyDataObject> MyObjectBuilder()
    {
        // Declare return object
        var result = new List<MyDataObject>();
        // Get your data 
        string[] Days = System.IO.File.ReadAllLines(@"C: \Users\Illimar\Desktop\Algorithms and Comlexity2\Day_1.txt");
        string[] Depths = System.IO.File.ReadAllLines(@"C: \Users\Illimar\Desktop\Algorithms and Comlexity2\Depth_1.txt");
        string[] IRIS_IDs = System.IO.File.ReadAllLines(@"C: \Users\Illimar\Desktop\Algorithms and Comlexity2\IRIS_ID_1.txt");
        string[] Latitudes = System.IO.File.ReadAllLines(@"C: \Users\Illimar\Desktop\Algorithms and Comlexity2\Latitude_1.txt");
        // etc ...
        // Loop through items to build objects
        for(var i = 0; i <= Days.length(); i++)
        {
            result.Add(new MyDataObject {
                Days = Days[i],
                Depths = Depths[i],
                IRIS_IDs = IRIS_IDs[i],
                Latitudes = Latitudes[i],
                // etc ...
            }
        }
        // Return result
        return result;
    }
 
