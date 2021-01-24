        public class DetailsModel : PageModel
        {
            public Car Car { get; set; }
            public IActionResult OnGet(string passedObject)
            {
                Car = JsonConvert.DeserializeObject<Car>(passedObject);
                if (Car == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
