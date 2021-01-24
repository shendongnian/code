    using Abot.Core;
    using Abot.Crawler;
    using Abot.Poco;
    using CsQuery.ExtensionMethods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    namespace WebCrawler
    {
    
        public class SiteMapFinder : IHyperLinkParser
        {
            private readonly HyperLinkParser _linkParser;
            public SiteMapFinder()
            {
                _linkParser = new AngleSharpHyperlinkParser();
            }
    
            IEnumerable<Uri> IHyperLinkParser.GetLinks(CrawledPage crawledPage)
            {
                if (crawledPage.HttpWebResponse.ContentType == "text/xml")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(crawledPage.Content.Text);
    
                    if (xml.DocumentElement == null) return new Uri[] {};
    
    
                    XmlNamespaceManager manager = new XmlNamespaceManager(xml.NameTable);
                    manager.AddNamespace("s", xml.DocumentElement.NamespaceURI);
    
    
                    var links = xml.SelectNodes("/s:sitemapindex/s:sitemap", manager);
                    if(links == null) return new Uri[] { };
                    return links
                            .Cast<XmlNode>()
                            .Select(x => new Uri(x.InnerText));
                   
    
    
    
                }
    
    
    
                return _linkParser.GetLinks(crawledPage);
    
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                SiteMapFinder finder = new SiteMapFinder();
                PoliteWebCrawler crawler = new PoliteWebCrawler(null, null, null, null, null, finder, null, null, null);
    
    
                crawler.PageCrawlCompleted += Crawler_PageCrawlCompleted;
                CrawlResult result = crawler.Crawl(new Uri("http://tenders.rfpalertservices.com/sitemap/"));
    
    
            }
    
            private static void Crawler_PageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
            {
                Console.WriteLine(e.CrawledPage.Uri.AbsoluteUri);
                e.CrawledPage.HttpWebResponse.Headers.AllKeys.ForEach(k => Console.WriteLine($"{k}: {e.CrawledPage.HttpWebResponse.Headers[k]}"));
            }
        }
    }
