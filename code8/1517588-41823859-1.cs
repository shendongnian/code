    public class Invoice
    {
        public int InvoiceNo { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class InvoiceDetails
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceNo { get; set; }
        public decimal Caret { get; set; }
    }
    public class Mixing
    {
        public int MixingNo { get; set; }
        public int InvoiceDetailId { get; set; }
        public decimal CaretUsed { get; set; }
    }
---
    private static void ExecQuery()
    {
        var invoices = new List<Invoice>();
        invoices.Add(new Invoice { InvoiceNo = 1, DateTime = new DateTime(2017, 1, 23) });
        invoices.Add(new Invoice { InvoiceNo = 2, DateTime = new DateTime(2017, 1, 23) });
        var invoiceDetails = new List<InvoiceDetails>();
        invoiceDetails.Add(new InvoiceDetails { InvoiceDetailId = 1, InvoiceNo = 1, Caret = 100 });
        invoiceDetails.Add(new InvoiceDetails { InvoiceDetailId = 2, InvoiceNo = 1, Caret = 200 });
        invoiceDetails.Add(new InvoiceDetails { InvoiceDetailId = 3, InvoiceNo = 2, Caret = 300 });
        invoiceDetails.Add(new InvoiceDetails { InvoiceDetailId = 4, InvoiceNo = 2, Caret = 400 });
        var mixings = new List<Mixing>();
        mixings.Add(new Mixing { MixingNo = 1, InvoiceDetailId = 1, CaretUsed = 50 });
        mixings.Add(new Mixing { MixingNo = 2, InvoiceDetailId = 2, CaretUsed = 100 });
        mixings.Add(new Mixing { MixingNo = 3, InvoiceDetailId = 1, CaretUsed = 25 });
        mixings.Add(new Mixing { MixingNo = 4, InvoiceDetailId = 2, CaretUsed = 50 });
        // select all from invoices
        var query = from i in invoices
                    // join the details
                    join id in invoiceDetails on i.InvoiceNo equals id.InvoiceNo
                    // group the details on invoice
                    group id by new { i.InvoiceNo, i.DateTime } into ig
                    // again join the details (from the mixing)
                    join id in invoiceDetails on ig.Key.InvoiceNo equals id.InvoiceNo
                    // join the mixing
                    join mix in mixings on id.InvoiceDetailId equals mix.InvoiceDetailId into mix2 // store in temp for outer join
                    from mbox in mix2.DefaultIfEmpty()
                    // group mixing (and sum the caret of the previous group
                    group mbox by new { ig.Key.InvoiceNo, ig.Key.DateTime, TotalCaret = ig.Sum(item => item.Caret) } into igm
                    // calculate the caret used (because it is used twice in the results)
                    let caretUsedCaret = igm.Where(item => item != null).Sum(item => item.CaretUsed)
                    // select the results.
                    select new
                    {
                        igm.Key.InvoiceNo,
                        igm.Key.DateTime,
                        igm.Key.TotalCaret,
                        CaretUsedCaret = caretUsedCaret,
                        Available = igm.Key.TotalCaret - caretUsedCaret
                    };
        foreach (var row in query)
        {
            Trace.WriteLine(row.ToString());
        }
    }
