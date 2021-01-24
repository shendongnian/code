    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<Sku>> SplitChosenCopy = new List<List<Sku>>();
                List<Sku> skus = new List<Sku>();
                skus.Add(new Sku { Term_name = "301", Sku_name = "sku2", Sku_qty = 30 });
                skus.Add(new Sku { Term_name = "302", Sku_name = "sku4", Sku_qty = 3 });
                List<Sku> skus2 = new List<Sku>();
                skus2.Add(new Sku { Term_name = "301", Sku_name = "sku7", Sku_qty = 30 });
                skus2.Add(new Sku { Term_name = "302", Sku_name = "sku4", Sku_qty = 3 });
                List<Sku> skus3 = new List<Sku>();
                skus3.Add(new Sku { Term_name = "301", Sku_name = "sku2", Sku_qty = 9 });
                skus3.Add(new Sku { Term_name = "302", Sku_name = "sku4", Sku_qty = 8 });
                SplitChosenCopy.Add(skus);
                SplitChosenCopy.Add(skus2);
                SplitChosenCopy.Add(skus3);
                var results = SplitChosenCopy.GroupBy(x => x).ToList();
            }
        }
        class Sku : IEqualityComparer<Sku>
        {
            private string term_name;
            private string sku_name;
            private int sku_qty;
            public string Term_name
            {
                get { return term_name; }
                set { term_name = value; }
            }
            public string Sku_name
            {
                get { return sku_name; }
                set { sku_name = value; }
            }
            public int Sku_qty
            {
                get { return sku_qty; }
                set { sku_qty = value; }
            }
            bool IEqualityComparer<Sku>.Equals(Sku  a, Sku  b)
            {
                return  a.term_name.Equals(b.term_name) && a.sku_name.Equals(b.sku_name) && a.sku_qty.Equals(b.sku_qty);
     
            }
            int IEqualityComparer<Sku>.GetHashCode(Sku obj)
            {
                if (Object.ReferenceEquals(obj, null))
                    return 0;
                return (obj.term_name + "^" +  obj.sku_name + "^" + obj.sku_qty.ToString()).GetHashCode() ;
            }
        }
    }
