    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace xml {
        class Program {
            static void Main(string[] args) {
                var data =
    @"<ProdExtract>
        <Product>
            <Barcode>         
              <Eancode>0000000000000</Eancode>        
            </Barcode>
        </Product>
        <Product>
            <Barcode>         
              <Eancode>0000000000000</Eancode>        
            </Barcode>
        </Product>
        <Product>       
            <Barcode>         
              <Eancode>5391524344444</Eancode>        
            </Barcode>
        </Product>
    </ProdExtract>";
    
                var xml = XDocument.Parse(data);
                var eancode = xml.Descendants("Eancode").Where(x => x.Value != "0000000000000");
                var product = eancode.Select(x => x.Parent.Parent);
                foreach (var p in product) {
                    Console.WriteLine(p);
                    }
                }
            }
        }
