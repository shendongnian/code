    IEnumerable<ArtistGenresDocument> list = await ArtistGenresCollection
        .Find(x => x.genre == "Pop" || x.genre == "Easy Listening")
        .ToListAsync();
    var filter = Builders<ArtistDetailsDocument>
        .Filter
        .Nin(x => x.artist_ID, list.Select(l => l.artist_ID));
    var ArtistDetailsDocuments = await ArtistDetailsCollection
        .Find(filter)
        .ToListAsync();
    public class ArtistDetailsDocument
    {
        public ObjectId Id { get; set; }
        public String artist_ID { get; set; }
        public String artistName { get; set; }
    }
    public class ArtistGenresDocument
    {
        public ObjectId Id { get; set; }
        public String artist_ID { get; set; }
        public String genre { get; set; }
    }
