        // GET: Surveys
    public ActionResult Index()
    {
        using (var api = new SurveyMonkeyApi("zgSdm04SEefy09ONaxV6b0z5rDOoRHXffGXMAasySfAyxUfCTN4x3AR9IyK5NVoRrBKB27bT-SMlbbL0dI2vUNYQiRNZqbslM0-KATC9JwWblgx4mieUwNxoDzC54lxe"))
        {
            IEnumerable<Survey> surveys = api.GetSurveyList();
            return View(surveys.ToList());
        }
    }
