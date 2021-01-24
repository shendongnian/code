    public ActionResult Ddl()
    {
        var segmentList = new List<listofSegments>();
        listofSegments segmentItem;
        var strArr = new string[] { "Jaipur", "Kota", "Bhilwara", "Udaipur", "Chitorgar", "Ajmer", "Jodhpur" };
        for (int index = 0; index < strArr.Length; index++)
        {
            segmentItem = new listofSegments();
            segmentItem.Text = strArr[index];
            segmentItem.Value = (index + 1).ToString();
            segmentList.Add(segmentItem);
        }
        return View(segmentList);
    }
    
    [HttpPost]
    public ActionResult ActionPostData(string Segmentation)
    {
        return RedirectToAction("Ddl");
    }
    
    public class listofSegments
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
