    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication28
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable retailers = new DataTable();
                retailers.Columns.Add("RetailerID", typeof(int));
                retailers.Columns.Add("RetailerName", typeof(string));
                retailers.Rows.Add(new object[] { 123, "abc" });
                retailers.Rows.Add(new object[] { 124, "abd" });
                retailers.Rows.Add(new object[] { 125, "abe" });
                DataTable invoices = new DataTable();
                invoices.Columns.Add("InvoiceID", typeof(int));
                invoices.Columns.Add("InvoiceProfit", typeof(decimal));
                invoices.Columns.Add("RetailerID", typeof(int));
                invoices.Rows.Add(new object[] { 100, 200, 123 });
                invoices.Rows.Add(new object[] { 101, 201, 123 });
                invoices.Rows.Add(new object[] { 102, 202, 123 });
                invoices.Rows.Add(new object[] { 103, 203, 123 });
                invoices.Rows.Add(new object[] { 104, 204, 124 });
                invoices.Rows.Add(new object[] { 105, 205, 124 });
                invoices.Rows.Add(new object[] { 106, 206, 124 });
                invoices.Rows.Add(new object[] { 107, 207, 125 });
                invoices.Rows.Add(new object[] { 108, 208, 125 });
                invoices.Rows.Add(new object[] { 109, 209, 125 });
                var retailersAndInvoices = (from r in retailers.AsEnumerable()
                                            join i in invoices.AsEnumerable() on r.Field<int>("RetailerID") equals i.Field<int>("RetailerID")
                                            select new { name = r.Field<string>("RetailerName"), profit = i.Field<decimal>("InvoiceProfit") })
                                           .GroupBy(x => x.name)
                                           .Select(x => new { name = x.Key, totalProfit = x.Select(y => y.profit).Sum() }).ToList();
            }
        }
    }
