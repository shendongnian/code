        [HttpPost]
        public IActionResult Index(string parametro)
        {
            // create your process an run it, passing what you want to do
            Process process = new Process();
            var question = process.Run(async (questionBox) =>
            {
                // we start the service
                SaleService service = new SaleService();
                // wait for the result
                var result = await service.GetValue(questionBox);
                // and close the process with the result from the process
                process.End(result);
            });
    
            return View(question);
        }
        // here we have the method that deliver us the user response interaction
        [HttpPost]
        public async Task<JsonResult> Answer(bool result, string id)
        {
            // we define the result for an Id on the process
            var response = await Process.DefineAnswer(id, result);
            // get the response from process.End used bellow
            // and return to the user
            return Json(response);
        }
