        class Position { }
    class Repository
    {
        private XElement xlmRecords;
        public Repository(string filePath)
        {
            xlmRecords = XElement.Load(filePath);
        }
        public List<Position> FindAll()
        {
            return xlmRecords.Elements("position")
                .Select(position =>
                {
                    return new Position
                    {
                        //You fill the Position properties view xml position values
                    };
                }).ToList();
        }
    }
  
