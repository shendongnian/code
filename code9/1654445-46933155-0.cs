    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
        
        var html = @"<div class=""l"">
    <span id=""ls_title_7596012"" class=""ls_h_desc"" title=""Required 10 marla 
    old house in any block of bahria town"">Required 10 marla old house in 
    any block of bahria town</span>
    </div>";
            // Try HtmlAgilityPack with css selector
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            IList<HtmlNode> nodes = doc.QuerySelectorAll("div.l #ls_title_7596012");
            Assert.IsNotEmpty(nodes);
            Assert.AreEqual(nodes.First().InnerText, "Required 10 marla old house in \r\nany block of bahria town");
            // try with xpath
            var xpath = @"//*[@id=""ls_title_7596012""]";
            nodes = doc.DocumentNode.SelectNodes(xpath);
            Assert.IsNotEmpty(nodes);
            Assert.AreEqual(nodes.First().InnerText, "Required 10 marla old house in \r\nany block of bahria town");
        }
    }
