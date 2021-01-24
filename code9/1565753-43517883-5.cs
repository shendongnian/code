            static void Main(string[] args)
        {
            PrintHelpPage();
            Console.ReadKey();
        }
        public static void PrintHelpPage()
        {
            var th = new Thread(() => {
                var br = new WebBrowser();
                br.DocumentCompleted += PrintDocument;
                br.Navigate("http://google.com");
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public static void PrintDocument(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            var browser = sender as WebBrowser;
            // Print the document now that it is fully loaded.
            browser.Print();
            // Dispose the WebBrowser now that the task is complete. 
            browser.Dispose();
        }
