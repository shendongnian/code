    private class Bands
            {
                public string BandName { get; set; }
                public List<string> Songtitles { get; set; }
            }
    
            public JsonResult Band()
            {
                var items = new Bands()
                {
                    BandName = "amber",
                    Songtitles = new List<string> { "song 1", "song 2" }
                };
                return Json(items, JsonRequestBehavior.AllowGet);
            }
