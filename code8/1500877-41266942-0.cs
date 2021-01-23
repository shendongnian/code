    public IEnumerable<entityCount> queryCount(){
            var countQ = this.doc.Descendants("METADATA") .Select(m => new entityCount {
                strCount = m.Element("COUNT").Value
            });
    
            return countQ;    
    }
