       [HttpGet]
                public ActionResult Test()
                {
                    var viewModel = new CitySelectorViewModel();
                    FillCities(viewModel);
                    return View(viewModel);
                }
          private void FillCities(CitySelectorViewModel viewModel)
            {
                viewModel.CitiesList.Add(new CityViewModel { CityId = 1, CityName = "Dublin", CountryName = "Ireland" });
                viewModel.CitiesList.Add(new CityViewModel { CityId = 2, CityName = "London", CountryName = "England" });
                viewModel.CitiesList.Add(new CityViewModel { CityId = 3, CityName = "Paris", CountryName = "France" });
                viewModel.CitiesList.Add(new CityViewModel { CityId = 4, CityName = "New York", CountryName = "United States" });
                viewModel.CitiesList.Add(new CityViewModel { CityId = 5, CityName = "Rome", CountryName = "Italy" });
            }
