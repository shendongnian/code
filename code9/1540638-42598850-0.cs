    namespace MusicService
    {
        public interface IAlbum {
            //common album properties/methods
        }
        public interface IArtist {
            //common artist properties/methods
        }
        internal abstract class AlbumBase:IAlbum {
            // implement common functions and properties if you have them...
            // otherwise, skip this
        }
        internal abstract class ArtistBase:IAlbum {
            // implement common functions and properties if you have them...
            // otherwise, skip this
        }	
    }
    
    namespace MusicService.AppleMusic 
    {
        internal class Album:AlbumBase 
        {  //OR Album:IAlbum if you skipped that AlbumBase thing
            //code apple music specific stuff here ... 
            // think of this as a "mask" that the apple album is 
            // wearing so that it can pretend to be an iAlbum
        }
        internal class Artist:ArtistBase 
        {  
            //same comments apply here
        }	
    }
    namespace MusicService.Spotify 
    {
        internal class Album:AlbumBase 
        {  
            //GO and do liekwise with Spotify
        }
        internal class Artist:ArtistBase 
        {  
            //GO and do liekwise with Spotify
        }
    }
