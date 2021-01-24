    var finalList = lstFirst.Zip(lstSecond, (c1, c2) => new CarFinal()
            {
                Name = c1.Name,
                Model = c1.Model,
                Description = c2.Description,
                Year = c2.Year
            }).ToList();
