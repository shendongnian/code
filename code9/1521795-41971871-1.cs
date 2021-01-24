    public class LoanItem
    {
        public string referenceNumber { get; set; }
        public string status { get; set; }
        public List<Borrower> Borrowers {get;set;}
        public string BorrowerName { get { return Borrowers.Where(x=>x.Type == "BORROWER").FirstOrDefault().Name; }
        public string CoBorrowerName { get { return return Borrowers.Where(x=>x.Type == "COBORROWER").FirstOrDefault().Name; } }
    }
