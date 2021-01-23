     public class Voucher
        {
            public Voucher()
            {
                st = new List<SubTransaction>();
            }
            public MainTransaction mt { get; set; }
            public List<SubTransaction> st { get; set; }
        }
