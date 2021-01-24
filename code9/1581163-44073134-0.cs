    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main(string[] args)
            {
                Response response = new Response(FILENAME);
            }
        }
        public class Response
        {
            public Response(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement response = doc.Descendants().Where(x => x.Name.LocalName == "Response").FirstOrDefault();
                XNamespace awsNs = response.GetNamespaceOfPrefix("aws");
                requestId = (string)response.Descendants(awsNs + "RequestId").FirstOrDefault();
                XElement alexa = response.Descendants(awsNs + "Alexa").FirstOrDefault();
                contentData = alexa.Elements(awsNs + "ContentData").Select(x => new ContentData() {
                    urlType = (string)x.Element(awsNs + "DataUrl").Attribute("type"),
                    url = (string)x.Element(awsNs + "DataUrl"),
                    title = (string)x.Descendants(awsNs + "Title").FirstOrDefault(),
                    description = (string)x.Descendants(awsNs + "Description").FirstOrDefault(),
                    linkCount = (int)x.Element(awsNs + "LinksInCount"),
                    keyWords  = x.Elements(awsNs + "Keywords").Select(y => (string)y).ToList()
                }).FirstOrDefault();
                categoryData = alexa.Element(awsNs + "Related").Descendants(awsNs + "CategoryData")
                    .GroupBy(x => (string)x.Element(awsNs + "Title"), y => (string)y.Element(awsNs + "AbsolutePath"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                trafficData = alexa.Elements(awsNs + "TrafficData").Select(x => new TrafficData() {
                    rank = (int)x.Element(awsNs + "Rank"),
                    statics = x.Descendants(awsNs + "UsageStatistic").Select(y => new Statistics() {
                        months = (int?)y.Descendants(awsNs + "Months").FirstOrDefault(),
                        days = (int?)y.Descendants(awsNs + "Days").FirstOrDefault(),
                        rankValue = (int)y.Element(awsNs + "Rank").Element(awsNs + "Value"),
                        rankDelta = (int)y.Element(awsNs + "Rank").Element(awsNs + "Delta"),
                        reachrankValue  = (int)y.Element(awsNs + "Reach").Element(awsNs + "Rank").Element(awsNs + "Value"),
                        reachRankDelta = (int)y.Element(awsNs + "Reach").Element(awsNs + "Rank").Element(awsNs + "Value"),
                        reachPerMillionValue = (decimal)y.Element(awsNs + "Reach").Element(awsNs + "PerMillion").Element(awsNs + "Value"),
                        reachPerMillionDeltaPercentage = decimal.Parse(((string)(y.Element(awsNs + "Reach").Element(awsNs + "PerMillion").Element(awsNs + "Delta"))).Split(new char[] {'%'}).FirstOrDefault()),
                        pageViewsPerMillionValue = (decimal)y.Element(awsNs + "PageViews").Element(awsNs + "PerMillion").Element(awsNs + "Value"),
                        pageViewsPerMillionDeltaPercentage  = decimal.Parse(((string)(y.Element(awsNs + "PageViews").Element(awsNs + "PerMillion").Element(awsNs + "Delta"))).Split(new char[] {'%'}).FirstOrDefault()),
                        pageViewsRankValue   = (int)y.Element(awsNs + "PageViews").Element(awsNs + "Rank").Element(awsNs + "Value"),
                        pageViewsRankDelta  = (int)y.Element(awsNs + "PageViews").Element(awsNs + "Rank").Element(awsNs + "Value"),
                        pageViewsPerUserValue  = (decimal)y.Element(awsNs + "PageViews").Element(awsNs + "PerUser").Element(awsNs + "Value"),
                        pageViewsPerUserDeltaPercentage  = decimal.Parse(((string)(y.Element(awsNs + "PageViews").Element(awsNs + "PerUser").Element(awsNs + "Delta"))).Split(new char[] {'%'}).FirstOrDefault())
                    }).ToList(),
                    contributingSubdomain = x.Descendants(awsNs + "ContributingSubdomain").Select(y => new ContributingSubdomain() {
                        dataUrl = (string)y.Element(awsNs + "DataUrl"),
                        months = (int?)y.Descendants(awsNs + "Months").FirstOrDefault(),
                        days = (int?)y.Descendants(awsNs + "Days").FirstOrDefault(),
                        reachPercentage = decimal.Parse(((string)(y.Element(awsNs + "Reach").Element(awsNs + "Percentage"))).Split(new char[] { '%' }).FirstOrDefault()),
                        pageViewsPercentage = decimal.Parse(((string)(y.Element(awsNs + "PageViews").Element(awsNs + "Percentage"))).Split(new char[] { '%' }).FirstOrDefault()),
                        pageViewsPerUser =  (decimal)y.Element(awsNs + "PageViews").Element(awsNs + "PerUser")
                    }).ToList()
                }).FirstOrDefault();
                
            }
            public string requestId { get; set; }
            public ContentData contentData { get; set;}
            public Dictionary<string, string> categoryData { get; set; }
            public TrafficData trafficData { get; set; }
        }
        public class ContentData
        {
            public string urlType {get;set;}
            public string url { get; set;}
            public string title { get; set;}
            public string description { get; set;}
            public int linkCount { get;set;}
            public List<string> keyWords { get; set;}
        }
        public class TrafficData
        {
            public int rank { get;set;}
            public List<Statistics> statics { get; set;}
            public List<ContributingSubdomain> contributingSubdomain { get; set; }
        }
        public class Statistics
        {
            public int? days { get; set; }
            public int? months { get; set; }
            public int rankValue { get; set;}
            public int rankDelta { get;set;}
            public int reachrankValue { get; set; }
            public int reachRankDelta { get; set; }
            public decimal reachPerMillionValue { get; set; }
            public decimal reachPerMillionDeltaPercentage { get; set; }
            public decimal pageViewsPerMillionValue { get; set; }
            public decimal pageViewsPerMillionDeltaPercentage { get; set; }
            public decimal pageViewsRankValue { get; set; }
            public decimal pageViewsRankDelta { get; set; }
            public decimal pageViewsPerUserValue { get; set; }
            public decimal pageViewsPerUserDeltaPercentage { get; set; }
        }
        public class ContributingSubdomain
        {
            public string dataUrl { get; set; }
            public int? months { get; set; }
            public int? days { get; set; }
            public decimal reachPercentage { get; set; }
            public decimal pageViewsPercentage { get; set; }
            public decimal pageViewsPerUser { get; set; }
        }
    }
