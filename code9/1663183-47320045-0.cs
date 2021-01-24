    using System;
    using System.Dynamic;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		string data = @"{
      'page': '2',
      'per_page': 10,
      'total': 13,
      'total_pages': 2,
      'data': [{
        'Poster': 'N/A',
        'Title': 'They Call Me Spiderman',
        'Type': 'movie',
        'Year': 2016,
        'imdbID': 'tt5861236'
      }, {
        'Poster': 'N/A',
        'Title': 'The Death of Spiderman',
        'Type': 'movie',
        'Year': 2015,
        'imdbID': 'tt5921428'
      }, {
        'Poster': 'https://images-na.ssl-images-amazon.com/images/M/MV5BZDlmMGQwYmItNTNmOS00OTNkLTkxNTYtNDM3ZWVlMWUyZDIzXkEyXkFqcGdeQXVyMTA5Mzk5Mw@@._V1_SX300.jpg',
        'Title': 'Spiderman in Cannes',
        'Type': 'movie',
        'Year': 2016,
        'imdbID': 'tt5978586'
      }]
    }";
    		dynamic content = JsonConvert.DeserializeObject<ExpandoObject>(data);
    		int i;
    		int len = content.data.Count;
    		string result = "";
    		string[] myArray;
    		for (i = 0; i < len; i++)
    		{
    			result += content.data[i].Title; // Extract the movie title.
    			result += ","; // Conact with commas.
    		}
    
    		result = result.Substring(0, result.Length - 1);
    		myArray = result.Split(','); // Array of string with the movie titles.
    		Console.WriteLine(myArray[0]);
    	}
    }
