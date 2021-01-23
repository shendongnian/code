    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    namespace Tests
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                // generate some data
                var artist = new Artist {Name = "Britney", Surname = "Spears"};
                var artists = new[] {artist};
                var collection = new ArtistCollection(artists);
    
                // find an artist by its name, using the custom indexer
                var artist1 = collection["Britney"];
            }
        }
    
        public class Artist
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    
        public class ArtistCollection : Collection<Artist>
        {
            public ArtistCollection()
            {
            }
    
            public ArtistCollection(IList<Artist> list) : base(list)
            {
            }
    
            /// <summary>
            ///     Gets an artist by name.
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public Artist this[string name]
            {
                get
                {
                    if (name == null)
                        throw new ArgumentNullException(nameof(name));
                    var artist = this.SingleOrDefault(s => s.Name == name);
                    return artist;
                }
            }
        }
    }
