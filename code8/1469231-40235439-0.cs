    public class CollectionViewModel
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
    public IActionResult Collection([FromQuery] IEnumerable<CollectionViewModel> model)
    {
        return View(model);
    }
