    using System;
    using System.Linq;
    using System.Net;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main (string[] args)
            {
                var url = "http://example.com/1392/Music/1392/Shahrivar/21/Avicii%20-%20True/01.%20Avicii%20Ft.%20Aloe%20Blacc%20-%20Wake%20Me%20Up%20(CDQ)%20%5b320%5d.mp3";
                var uri = new Uri (url);
                string[] segments = uri.Segments.Select (x => WebUtility.UrlDecode (x).TrimEnd ('/')).ToArray ();
            }
        }
    }
