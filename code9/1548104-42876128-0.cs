    public class MyClass
    {
    	string word = "asd";
    	public List<string> Words = new List<string>();
    
    	public void OpenFile()
    	{
    		using (var fileStream = File.OpenRead("wordlist.txt"))
    		using (var streamReader = new StreamReader(fileStream))
    		{
    			String line;
    			while ((line = streamReader.ReadLine()) != null)
    			{
    				Words.Add(line);
    			}
    		}
    	}
    
    	public void anagram()
    	{
    		Console.WriteLine(word);
    	}
    }
