    public ActionResult Create()
        {
                PaintballWorkerCreateViewModel model = new PaintballWorkerCreateViewModel()
                {
                    PaintballWorker = new PaintballWorker(),
                    HourlyRate = new PaintballWorkerHourlyRate()
                    {
                        Date = DateTime.Now
                    }
                };
                return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaintballWorkerCreateViewModel paintballWorker)
        {
            (...)
        }
