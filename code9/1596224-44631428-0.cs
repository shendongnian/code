    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication63
    {
        class Program
        {
            static void Main(string[] args)
            {
                Song.songs = new List<Song>() {
                    new Song() { SongID = 1, SongName = "A"},
                    new Song() { SongID = 2, SongName = "B"},
                    new Song() { SongID = 3, SongName = "C"}
                };
                Artist.artists = new List<Artist>() {
                    new Artist() { ArtistID= 1, ArtistName= "D"},
                    new Artist() { ArtistID= 2, ArtistName= "E"},
                    new Artist() { ArtistID= 3, ArtistName= "F"}
                };
                MAPPING_Artist.mappings = new List<MAPPING_Artist>() {
                 new MAPPING_Artist() { SongID = 1, ArtistID = 1},
                 new MAPPING_Artist() { SongID = 1, ArtistID = 2},
                 new MAPPING_Artist() { SongID = 1, ArtistID = 3},
                 new MAPPING_Artist() { SongID = 3, ArtistID = 2}
                };
                var groups = (from map in MAPPING_Artist.mappings
                              join song in Song.songs on map.SongID equals song.SongID
                              join art in Artist.artists on map.ArtistID equals art.ArtistID 
                              select new { songID = song.SongID,songName = song.SongName, artistname = art.ArtistName})
                              .GroupBy(x => x.songID)
                              .Select(x => new {
                                  songID = x.Key,
                                  songName = x.FirstOrDefault().songName,
                                  artists = x.Select(y => y.artistname).ToList()
                              }).ToList();
            }
        }
        public class Song
        {
            public static List<Song> songs = new List<Song>();
            public int SongID { get; set; }
            public string SongName { get; set; }
        }
        public class Artist
        {
            public static List<Artist> artists = new List<Artist>();
            public int ArtistID { get; set; }
            public string ArtistName { get; set; }
        }
        public class MAPPING_Artist
        {
            public static List<MAPPING_Artist> mappings = new List<MAPPING_Artist>();
            public int SongID { get; set; }
            public int ArtistID { get; set; }
        }
    }
