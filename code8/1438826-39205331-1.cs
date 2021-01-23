    Node newNode = new Node();
    //Assign Node Id
    newNode.Id = 2; 
    //Declare a new List for Neighbors in Node
    List<KeyValuePair<int, int>> neighborList = new List<KeyValuePair<int, int>>();
    //Add members to neighborList
    neighborList.Add(new KeyValuePair<int, int>(1, 1)); //Assign these values dynamically;
    neighborList.Add(new KeyValuePair<int, int>(2, 2)); 
    neighborList.Add(new KeyValuePair<int, int>(3, 3));
    //Assign neighborList to Neighbors
    //Note that this could have been done without declaring a separate List
    newNode.Neighbors = neighborList;
    //Add newNode to your List
    graph.Add(newNode);
