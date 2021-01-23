       public ActionResult Index()
        {
            ResumeVM _vm = new ResumeVM(); 
            Repository _repository = new Repository();
            //these repository methods will populate your lists 
            _vm.Resume = _repository.PopulateResume();
            _vm.Experience = _repository.PopulateExperice();
            return View("Index",_vm);
        }
