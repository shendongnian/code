    public string GetResponse(string question)
    {
        string response = "";
        
        while(response != "Y" && response != "N")
        {
            Console.WriteLine(question);
            response = Console.ReadLine();
        }
 
        return response;
    }
