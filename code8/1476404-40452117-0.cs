    return View(  new List<FeedEventViewModel>() {
        new FeedEventViewModel{
            AnimalId = command.AnimalId,
            AnimalName = command.AnimalName,
            FeederTypeId = command.FeederTypeId,
            FeederType = command.FeederType
           }
        }
        );
