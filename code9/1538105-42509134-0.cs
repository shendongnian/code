    using System;
    
     public class Music
        {
            public virtual string play()
            {
                return "Play Music";
            }
        }
    
        public class Drum : Music
        {
            public override string play()
            {
                return "Play Drums";
            }
        }
    
        public class Piano : Music
        {
            public override string play()
            {
                return "Play Piano";
            }
        }
    
        public class PlayMusicService
        {
            private readonly Music _musicContext;
            public PlayMusicService(Music musicContext)
            {
                this._musicContext = musicContext;
            }
    
            public string PlayAlbum()
            {
                return _musicContext.play();
            }        
        }
       
    					
    public class Program
    {
    	public static void Main()
    	{
    	     string whatPlayed = "";
    		
    		Drum drums = new Drum();        
            PlayMusicService music1 = new PlayMusicService(new Drum());		
            whatPlayed = music1.PlayAlbum();
    		Console.WriteLine(whatPlayed);
    		
    		Piano piano = new Piano();
    		PlayMusicService music2 = new PlayMusicService(new Piano());
    		whatPlayed = music2.PlayAlbum();
    		Console.WriteLine(whatPlayed);
    	}
    }
