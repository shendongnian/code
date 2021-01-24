    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // just some fake data for demonstration
            var model = new HomeEditViewModel
            {
                Name = "Name",
                Floor = Enumerable.Range(1, 10).Select(e => new SelectionItem<int> { Key = e, DisplayName = $"Floor {e}" }),
                Street = Enumerable.Range(1, 10).Select(e => new SelectionItem<int> { Key = e, DisplayName = $"Street {e}" }),
                House = Enumerable.Range(1, 10).Select(e => new SelectionItem<int> { Key = e, DisplayName = $"House {e}" }),
                Town = Enumerable.Range(1, 10).Select(e => new SelectionItem<int> { Key = e, DisplayName = $"Town {e}" }),
                FloorId = 3,
                StreetId = 4,
                HouseId = 5,
                TownId = 6,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, HomeEditPostModel model)
        {
            // needs to save the data here
            return RedirectToAction(nameof(Index));
        }
    }
 
