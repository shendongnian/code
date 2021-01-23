       public class Invoice
        {
            public int INVOICENO { get; set; }
            public DateTime DATE { get; set; }
        }
        public class InvoiceDetail
        {
            public int INVOICEDETAILID { get; set; }
            public int INVOICENO { get; set; }
            public int CARET { get; set; }
        }
        public class Mixing
        {
            public int MIXINGNO { get; set; }
            public int INVOICEDETAILID { get; set; }
            public int CARETUSED { get; set; }
        }
        [Fact]
        public void LinqTest()
        {
            List<int>  ints = new List<int> {1,2,3};
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice {INVOICENO = 1, DATE = DateTime.Parse("23/01/2017")},
                new Invoice {INVOICENO = 2, DATE = DateTime.Parse("23/01/2017")}
            };
     
            List<InvoiceDetail> invoiceDetails = new List<InvoiceDetail>
            {
                new InvoiceDetail{ INVOICEDETAILID = 1, INVOICENO = 1, CARET = 100},
                new InvoiceDetail { INVOICEDETAILID = 2, INVOICENO = 1, CARET = 200},
                new InvoiceDetail { INVOICEDETAILID = 3, INVOICENO = 2, CARET = 300},
                new InvoiceDetail {INVOICEDETAILID = 4, INVOICENO = 2, CARET = 400}
            };
            List<Mixing> mixings = new List<Mixing>
            {
                new Mixing {MIXINGNO = 1, INVOICEDETAILID = 1, CARETUSED = 50},
                new Mixing {MIXINGNO = 1, INVOICEDETAILID = 2, CARETUSED = 100},
                new Mixing {MIXINGNO = 2, INVOICEDETAILID = 1, CARETUSED = 25},
                new Mixing {MIXINGNO = 2, INVOICEDETAILID = 2, CARETUSED = 50}
            };
            var q =
                invoices.Join(invoiceDetails, i => i.INVOICENO, id => id.INVOICENO, (invoice, detail) => new {invoice, detail})
                    .GroupJoin(mixings, arg => arg.detail.INVOICEDETAILID, m => m.INVOICEDETAILID,
                        (arg, m) => new {arg.invoice, arg.detail, Mixings = m})
                    .GroupBy(arg => arg.invoice)
                    .Select(
                        g =>
                            new
                            {
                                g.Key.INVOICENO,
                                g.Key.DATE,
                                Tot_Caret = g.Sum(arg => arg.detail.CARET),
                                Tot_Used = g.Sum(arg => arg.Mixings.Sum(mixing => mixing.CARETUSED)),
                                Available = g.Sum(arg => arg.detail.CARET) - g.Sum(arg => arg.Mixings.Sum(mixing => mixing.CARETUSED))
                            });
        }
