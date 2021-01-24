    using System;
    using System.Net;
    using System.Text;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace GetSignatureHtml
    {
    
        class Program
        {
            static void Main(string[] args)
            {
                foreach(arg in args)
                {
                    FindData(arg.urlAddress);
                }
            }
    
            public void FindData(arg)  
            {
                string urlAddress = "http://www.url.com/person1";
    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
    
                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
    
                    string data = readStream.ReadToEnd();
    
                    using (FileStream fs = new FileStream(@"C:\Users\ellio\Desktop\test\person1.htm", FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                        {
                            w.WriteLine(data);
                        }
                    }
    
                    Console.Write(data);
                    Console.ReadKey(true);
    
                    response.Close();
                    readStream.Close();
                }
            }    
        }
    }
