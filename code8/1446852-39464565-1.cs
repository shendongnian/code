    [HttpPost]
        public PartialViewResult _ShowEmployeeProjects(string ActiveOnlySelect)
        {
            // DO YOUR MAGIC   
            // model should be a List[BTGHRM.Models.your_model]
            PartialView("Partial/_ShowEmployeeProjects", model);
        }
