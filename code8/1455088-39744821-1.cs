     public class Animal
            {
                public String name { get; set; }
                public String habitat { get; set; }
                //changed class to aninmalclass it is a reserved keyword
                public String animalclass { get; set; }
            }
            [HttpPost]
            public JsonResult SendDataStackOverFlow(Animal animal)
            {
                return Json(new { foo = "bar", baz = "Blech" });
            }
