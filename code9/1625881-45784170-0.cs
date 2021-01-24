    string allID = "";   
    foreach (var c in client)
    {
        var r = server.Any(x => x.Id == c.Id);
        
        if (r==true)
        {
            allID += c.Id + ","; //will append values of matched c.ID with a comma
        }
    }
    allID = allID.Remove(allID.Length - 1); //Removes the last extra comma
    Console.WriteLine(String.Format("Cannot delete as {0} exists", allID)); 
