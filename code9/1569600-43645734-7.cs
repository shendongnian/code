    public class UseThisOnYourView // Give it another name
    {
        public List<CategProdViewModel> Items { get; set; }
        public real TotalSale { get { return this.Items.Sum(x => x.Sale); } }
    }
