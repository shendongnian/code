    class TigerConsumer : IDataConsumer<Tiger> 
    {
        public IDataProducer<Tiger> p;
        public IDataProducer<Tiger> Producer { set { p = value; } }
        ... and so on ...
    }
    class GiraffeProducer : IDataProducer<Giraffe> 
    { 
      public IEnumerable<Giraffe> GetRecords() { 
        yield return new Giraffe(); 
      }
    TigerConsumer t = new TigerConsumer();
    IDataConsumer<Mammal> m = t;        // compatible with IDataConsumer<Mammal>
    m.Producer = new GiraffeProducer(); // compatible with IDataProducer<Mammal>
    foreach(Tiger tiger in t.p.GetRecords()) 
      // And we just cast a giraffe to tiger
