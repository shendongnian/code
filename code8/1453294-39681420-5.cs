    public class Option
    {
        public string NameStartsWith {get; set; }
        public string Data {get; set; }
        public string ElementOne {get; set; }
        public string ElementTwo {get; set; }
    }
    var matches = doc.Root
                     .Descendants("Option")
                     .Where(option => option.Element("NameStartsWith") != null)
                     .Where(option => name.StartsWith(option.Element("NameStartsWith").Value))
                     .Select(option => new Option
                     {
                         NameStartsWith = option.Element("Data").Value,
                         Data = option.Element("Data").Value,
                         ElementOne = option.Element("ElementOne").Value,
                         ElementTwo = option.Element("ElementTwo").Value,
                     });
