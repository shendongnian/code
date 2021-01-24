    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
               new TestStructureElement(FILENAME); 
            }
        }
        public class TestStructureElement
        {
            public static TestStructureElement root = new TestStructureElement();
            
            public string id { get; set; }
            public string _Type { get; set;}
            public string objectRef { get; set; }
            public int t42ElementId { get;set;}
            public List<TestStructureElement> children { get;set;}
            public static TestResults testResults { get; set; }
            public TestStructureElement() { }
            public TestStructureElement(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement testStructure = doc.Descendants("TestStructureElement").FirstOrDefault();
                GetTree(testStructure, root);
            }
            public void GetTree(XElement xml, TestStructureElement testStructure)
            {
                testStructure.id = (string)xml.Attribute("Id");
                testStructure._Type = (string)xml.Attribute("Type");
                testStructure.objectRef = (string)xml.Attribute("ObjectRef");
                testStructure.t42ElementId = (int)xml.Attribute("T42ElementId");
                if (xml.Elements("TestStructureElement") != null)
                {
                    testStructure.children = new List<TestStructureElement>();
                    foreach (XElement child in xml.Elements("TestStructureElement"))
                    {
                        TestStructureElement childStructure = new TestStructureElement();
                        testStructure.children.Add(childStructure);
                        GetTree(child, childStructure);
                    }
                }
                
                TestStructureElement.testResults = xml.Descendants("TestResults").Select(x => new TestResults()
                {
                    testState = (string)x.Attribute("TestState"), 
                    evalaution = (string)x.Descendants("Evaluation").FirstOrDefault().Attribute("VDSEvaluation"),
                    evaluationRemark = (string)x.Descendants("Evaluation").FirstOrDefault().Element("Remark"),
                    testCaseActivity = x.Descendants("TestCaseActivity")
                        .GroupBy(y => (string)y.Attribute("TCActivity"), z => (string)z.Attribute("TCActivityState"))
                        .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).FirstOrDefault();
            }
        }
        public class TestResults
        {
            public string testState { get; set; }
            public string evalaution { get; set; }
            public string evaluationRemark { get; set; }
            public Dictionary<string, string> testCaseActivity { get; set; }
        }
    }
