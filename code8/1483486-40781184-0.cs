    using ScrapySharp.Extensions;
    using HtmlAgilityPack;
    
    namespace ConsoleLab
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                HtmlWeb web = new HtmlWeb();
                var document = web.Load("your url");
                //css class selector example
                var res1 = document.DocumentNode.CssSelect(".yourClass");
                //css id selector example
                var res2 = document.DocumentNode.CssSelect("#yourID");
            }
        }
    }
