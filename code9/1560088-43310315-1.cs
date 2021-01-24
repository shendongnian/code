    public class MyViewModel {
        public string TCKimlikNo { get; set; }
    }
    
    public ActionResult YeniBelge(string KimlikNo)
    {
        return View(new MyViewModel { KimlikNo = KimlikNo ?? "My Default Value" });
    }
