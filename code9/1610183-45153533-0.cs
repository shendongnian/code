    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Lists
    {
    	public class Song
    	{
    		public string Title;
    		public string Artist;
    		public string Image;
    
    		public override string ToString()
    		{
    			return string.Format( "Title = {0}, Artist = {1}, Image = {2}", Title, Artist, Image.Replace("https://en.wikipedia.org/wiki/File:", string.Empty) );
    		}
    	}
    
    	public class Program
    	{
    		static void Main( string [] args )
    		{
    			List< string > titles = new List< string > { "Dazed And Confused", "Iron Man", "The Wall" };
    			List< string > artists = new List< string > { "Led Zeppelin", "Black Sabbath", "Pink Floyd" };
    			List< string > images = new List< string > { 
    				"https://en.wikipedia.org/wiki/File:Led_Zeppelin_-_Led_Zeppelin_(1969)_front_cover.png", 
    				"https://en.wikipedia.org/wiki/File:Black_Sabbath_-_Paranoid.jpg", 
    				"https://en.wikipedia.org/wiki/File:PinkFloydWallCoverOriginalNoText.jpg"
    			};
    
    			var songs = titles.SelectMany(
    				t => artists.SelectMany(
    					a => images,
    					( a, i ) => new Song { Title = t, Artist = a, Image = i } ) );
    
    			foreach ( var song in songs )
    			{
    				Console.WriteLine( song );
    			}
    			Console.Read();
    
    		}
    	}
    }
