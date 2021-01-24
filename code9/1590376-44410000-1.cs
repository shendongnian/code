    using System;
    using System.Linq;
    using System.Xml.Linq;
    static class Program
    {
        static void Main()
        {
            var el = XDocument.Parse(xml).Root;
    
            var interests = from intIdEl in el.Elements("InterestId")
                            let children = intIdEl.ElementsAfterSelf().TakeWhile(
                                x => x.Name != "InterestId")
                            let feedIdEl = children.Elements("FeedId").FirstOrDefault()
                            let descIdEl = children.Elements("Description").FirstOrDefault()
                            let intEl = children.Elements("Interest").FirstOrDefault()
                            select new
                            {
                                InterestId = (int?)intIdEl,
                                FeedId = (int?)feedIdEl,
                                Description = (string)descIdEl,
                                Interest = (string)intEl
                            };
    
            foreach(var obj in interests)
            {
                Console.WriteLine(
                  $"{obj.InterestId}, {obj.FeedId}, {obj.Description}, {obj.Interest}");
            }
        }
        const string xml = @"<Users>
    <InterestId>8</InterestId><FeedId>4608</FeedId>
    <Description>Test</Description> <Interest>Cricekt</Interest>
    <InterestId>12</InterestId> <FeedId>4609</FeedId>
    <Description>Test 2</Description> <Interest>Read</Interest>
    </Users>";
    }
