    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XmlDocument doc = new XmlDocument();
            
            doc.LoadXml("<Field ID=\"{b77cdbcf-5dce-4937-85a7-9fc202705c91}\" Group=\"_Hidden\" SourceID=\"http://schemas.microsoft.com/sharepoint/v4\" Name=\"IconOverlay\" StaticName=\"IconOverlay\" DisplayName=\"IconOverlay\" Type=\"Text\" Required=\"FALSE\" AllowDeletion=\"TRUE\" Version=\"6\" Sealed=\"FALSE\" Hidden=\"TRUE\" CanToggleHidden=\"TRUE\" />");
            
            var element = doc.DocumentElement;
            if (element.Attributes["CanToggleHidden"] != null)
                element.SetAttribute("CanToggleHidden", "TRUE");
            Console.WriteLine(doc.ToString());
        }
    }
