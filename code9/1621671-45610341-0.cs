    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication72
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string xml = doc.ToString();
                string json = string.Format(
                    "{" +
                        "\"id\": \"22307a79-89dc-914e-5cf1-098f992e5054\"," +
                        "\"name\": \"Sample Request\"," +
                        "\"description\": \"\"," +
                        "\"order\": [" +
                            "\"36f699c6-0765-3e31-fdf8-863a3c3d508c\"" +
                        "]," +
                        "\"folders\": []," +
                        "\"timestamp\": 1497005641974," +
                        "\"owner\": \"1189835\"," +
                        "\"public\": false," +
                        "\"requests\": [" +
                            "{" +
                                "\"id\": \"36f699c6-0765-3e31-fdf8-863a3c3d508c\"," +
                                "\"headers\": \"accessKey: 1057550\nsecretKey: t3stH11p7550\n\"," +
                                "\"headerData\": [" +
                                    "{" +
                                        "\"key\": \"accessKey\"," +
                                        "\"value\": \"1057550\"," +
                                        "\"description\": \"\"," +
                                        "\"enabled\": true" +
                                    "}," +
                                    "{" +
                                        "\"key\": \"secretKey\"," +
                                        "\"value\": \"dummy7550\"," +
                                        "\"description\": \"\"," +
                                        "\"enabled\": true" +
                                    "}" +
                                "]," +
                                "\"url\": \"https://feeds.vendor.com/API.php/Job/postHttpJob\"," +
                                "\"queryParams\": []," +
                                "\"preRequestScript\": null," +
                                "\"pathVariables\": {}," +
                                "\"pathVariableData\": []," +
                                "\"method\": \"POST\"," +
                                "\"data\": [" +
                                    "{" +
                                        "\"key\": \"content\"," +
                                        "\"value\": \"{0}\"," +
                                        "\"type\": \"text\"," +
                                        "\"enabled\": true" +
                                    "}," +
                                    "{" +
                                        "\"key\": \"\"," +
                                        "\"value\": \"\"," +
                                        "\"description\": \"\"," +
                                        "\"type\": \"text\"," +
                                        "\"enabled\": true" +
                                    "}" +
                                "]," +
                                "\"dataMode\": \"params\"," +
                                "\"version\": 2," +
                                "\"tests\": null," +
                                "\"currentHelper\": \"normal\"," +
                                "\"helperAttributes\": {}," +
                                "\"time\": 1501909208689," +
                                "\"name\": \"Sample Request\"," +
                                "\"description\": \"Sample Request with sample XML\"," +
                                "\"collectionId\": \"22307a79-89dc-914e-5cf1-098f992e5054\"," +
                                "\"responses\": []" +
                            "}" +
                        "]" +
                    "}",
                    xml);
            }
        }
        
    }
