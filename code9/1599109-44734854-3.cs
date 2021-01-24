    public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CalculationModel model)
        {
            ModelState.Clear();
            switch (model.calculationMethod)
            {
                case CalculationMethod.Addition:
                    model.Result = model.FirstNumber + model.SecondNumber;
                    break;
                case CalculationMethod.Subtraction:
                    model.Result = model.FirstNumber - model.SecondNumber;
                    break;
                case CalculationMethod.Multiplication:
                    model.Result = model.FirstNumber * model.SecondNumber;
                    break;
                case CalculationMethod.Division:
                    model.Result = model.FirstNumber / model.SecondNumber;
                    break;
            }
            return View(model);
        }
