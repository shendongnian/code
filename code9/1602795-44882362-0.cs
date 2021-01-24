    public class SampleData : DropCreateDatabaseIfModelChanges<MusicStoreEntities>
        {
            protected override void Seed(MusicStoreEntities context)
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Rock" },
                    new Genre { Name = "Jazz" },
                    new Genre { Name = "Metal" },
                    new Genre { Name = "Alternative" },
                    new Genre { Name = "Disco" },
                    new Genre { Name = "Blues" },
                    new Genre { Name = "Latin" },
                    new Genre { Name = "Reggae" },
                    new Genre { Name = "Pop" },
                    new Genre { Name = "Classical" },
                };
