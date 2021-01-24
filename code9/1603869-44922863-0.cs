    class SampleCollection
    {
        public SampleCollection()
        {
              NameLookup = new Dictionary<string, List<Sample>>();
              IdLookup = new Dictionary<int, Sample>();
        }
        private Dictionary<string, List<Sample>> NameLookup;
        private Dictionary<int, Sample> IdLookup;
        public void Add(Sample sample)
        {
           IdLookup.Add(sample.Id, Sample);
           List<Sample> list;
           if (!NameLookup.TryGetValue(sample.Name, out list))
              NameLookup.Add(sample.Name, list = new List<Sample>());
           list.Add(Sample);
        }
        public Sample FindById(int id)
        {
           Sample result;
           IdLookup.TryGetValue(id, out result);
           return result;
        }
        public IEnumerable<Sample> FindByName(string name)
        {
           List<Sample> list;
           if (NameLookup.TryGetValue(name, out list))
             foreach(var sample in list)
               yield return sample;
        }
    }
