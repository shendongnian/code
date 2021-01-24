    using System;
    using System.IO;
    using System.Net;
    
    namespace Console_API_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                /* The XML Request */
                string xmlRequest = 
              @"<request>
    
                <auth>
                    <type> basic </type>
                    <username> USERNAME </username>
    
                    <password> PASSWORD </password>
    
                </auth>
    
                <method>
    
                    <name> getProperties </name>
    
                    <params>
    
                         <propertyIds> 356930 </propertyIds>
    
                        <showAllStatus> 0 </showAllStatus>
    
                    </params>
    
                  </method>
    
            </request>";
            /* Initiate a Web Request object */
            WebRequest request = WebRequest.Create("https://ach.entrata.com/api/properties");   
            request.Method = "POST";
            /* Initiate the request writer */
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            
            /* If you want to send an XML Request, use these options */
            request.ContentType = "APPLICATION/XML; CHARSET=UTF-8";                             
            requestWriter.Write(xmlRequest);
            requestWriter.Close();
            /* Read the response */
            StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();
            Console.WriteLine(responseData);
        }
    }
    }
