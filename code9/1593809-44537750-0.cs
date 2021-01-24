        public class DictionaryInit
        {
            public string Letter { get; private set; }
            public DictionaryInit(string letter)
            {
                this.Letter = letter;
                C = new Dictionary<int, DictionaryCheckup>()
                {
                    {1000, new DictionaryCheckup {theGrouping=letter}},
                    {100, new DictionaryCheckup {theGrouping=letter}},
                };
            }
            public Dictionary<int, DictionaryCheckup> C { get; private set; }
        } 
    var list = new List<DictionaryInit>();
    list.AddRange(new[]{new DictionaryInit("C"), new DictionaryInit("D")});
    cmbDictionList.DataSource = list;
    cmbDictionList.DisplayMember = "Letter";
