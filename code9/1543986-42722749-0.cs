            SHDocVw.InternetExplorer IE = new SHDocVw.InternetExplorer();
            IE.Visible = false;
            IE.Navigate(@"https://www.goodgaragescheme.com/pages/map.aspx?loc=CO70AN");
            System.Threading.Thread.Sleep(5000);
            mshtml.IHTMLDocument2 htmlDoc = IE.Document as mshtml.IHTMLDocument2;
            string content = htmlDoc.body.outerHTML;
            System.IO.File.WriteAllText(@"FILENAME.txt", content);
            System.Console.WriteLine("done");
            System.Console.ReadKey();
