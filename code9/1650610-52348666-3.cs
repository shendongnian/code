        public class DetailsModel : PageModel
        {
            public Car Car { get; set; }
            public IActionResult OnGet(Dictionary<string, string> cars)
            {
                if (cars == null)
                {
                    return NotFound();
                }
                Dictionary<int, Car> dictCars = cars
                .ToDictionary(item => int.Parse(item.Key), item => JsonConvert.DeserializeObject<Car>(item.Value));
                Car = dictCars
                    .Select(item => item.Value)
                    .FirstOrDefault<Car>();
                if (Car == null)
                {
                    return NotFound();
                }
                return Page();
            }
        }
