    public static List<Quote> ReadBinaryToList(){
      using(Stream stream = new FileStream(@"quotes.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
           IFormatter formatter = new BinaryFormatter();
            if (stream.Length == 0) {
               List<Quote> quoteList = new List<Quote> {new Quote(Guid.NewGuid(), "Quote dummy", false)};
               formatter.Serialize(stream, quoteList);
               //stream.Position = 0;
               return quoteList;
            }
            else return (List<Quote>)formatter.Deserialize(stream);               
       }
    }
