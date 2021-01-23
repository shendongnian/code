    [HttpPost]
        public PartialViewResult _ShowEmployeeProjects(string ActiveOnlySelect)
        {
            // DO YOUR MAGIC   
            // model should be a List[BTGHRM.Models.EmployeeProjectHistoryModel]
            PartialView("Partial/_ShowEmployeeProjects", model);
        }
