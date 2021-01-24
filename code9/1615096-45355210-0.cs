    [HttpPost]
    public ActionResult UserInput(UserInputViewModel inputParameters)
    {
        if (!ModelState.IsValid)return View();
        
        PocketName resultPocketName;
        IEnumerable<Point> crossPoints;
        PoolTable poolTable = new PoolTable((int)inputParameters.Width, (int)inputParameters.Height, (int)inputParameters.BallPointX, (int)inputParameters.BallPointY, inputParameters.VectorX, inputParameters.VectorY);
        resultPocketName = poolTable.Play();
        crossPoints = poolTable.CrossPoints;
        ViewBag.ResultPocketName = resultPocketName;
        ViewBag.CrossPoints = crossPoints;
        return View("ViewName", whatEverModelYouNeed);
    }
