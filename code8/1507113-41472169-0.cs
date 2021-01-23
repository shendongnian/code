    public ActionResult TestMachine(int id = 0)
    {
        XDocument Xdoc = XDocument.Load("test.xml");
        var Test = Xdoc.Descendants("testing").Select
        (imm => new test
        {
            TestId = Convert.ToInt32(imm.Element("testId").Value),
            Name = imm.Element("name").Value,
            Machine = imm.Element("machine").Value,
            Image = imm.Elements("img").Select(img => new Images {
            Url = img.Value
            }).ToList() 
        }).Where(i=> i.TestId == id).FirstOrDefault();
        return View(test);
    }
