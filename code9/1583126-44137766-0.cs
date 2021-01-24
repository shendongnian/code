    public class myViewModel
    {
        public int Id {get;set;}
        public List<object> myObjects {get;set;}
    
        public bool ChangeAmountByName(string name, decimal amount)
        {
            var match = this.myobjects.FirstOrDefault(x => x.Name == name);
            if (match == null) return false;
    
            match.Amount = amount;
            return true;
        }
    }
