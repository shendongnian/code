    using System;  
    using System.IO;  
    using System.Net;  
    using System.Xml;  
      
    namespace UsingSOAPRequest  
    {  
        public class Program  
        {  
            static void Main(string[] args)  
            {  
                //creating object of program class to access methods  
                Program obj = new Program();  
                Console.WriteLine("Please Enter Input values..");  
                //Reading input values from console  
                int a = Convert.ToInt32(Console.ReadLine());  
                int b = Convert.ToInt32(Console.ReadLine());  
                //Calling InvokeService method  
                obj.InvokeService(a, b);  
            }  
            public void InvokeService(int a, int b)  
            {  
                //Calling CreateSOAPWebRequest method  
                HttpWebRequest request = CreateSOAPWebRequest();  
      
                XmlDocument SOAPReqBody = new XmlDocument();  
                //SOAP Body Request  
                SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>  
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-   instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">  
                 <soap:Body>  
                    <Addition xmlns=""http://tempuri.org/"">  
                      <a>" + a + @"</a>  
                      <b>" + b + @"</b>  
                    </Addition>  
                  </soap:Body>  
                </soap:Envelope>");  
      
      
                using (Stream stream = request.GetRequestStream())  
                {  
                    SOAPReqBody.Save(stream);  
                }  
                //Geting response from request  
                using (WebResponse Serviceres = request.GetResponse())  
                {  
                    using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))  
                    {  
                        //reading stream  
                        var ServiceResult = rd.ReadToEnd();  
                        //writting stream result on console  
                        Console.WriteLine(ServiceResult);  
                        Console.ReadLine();  
                    }  
                }  
            }  
      
            public HttpWebRequest CreateSOAPWebRequest()  
            {  
                //Making Web Request  
                HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://localhost/Employee.asmx");  
                //SOAPAction  
                Req.Headers.Add(@"SOAPAction:http://tempuri.org/Addition");  
                //Content_type  
                Req.ContentType = "text/xml;charset=\"utf-8\"";  
                Req.Accept = "text/xml";  
                //HTTP method  
                Req.Method = "POST";  
                //return HttpWebRequest  
                return Req;  
            }  
        }  
    }  
