        public IEnumerable<SoftwareImageTestPlan> GetAssignedTestPlansForSPSI(int softwareProductID, int SoftwareImageID)
        {
            var records = _entities.tblSoftwareImageTestPlans
                                   .Where(x => 
                                     x.SoftwareProductID == SoftwareProductID && 
                                     x.SoftwareImageID == SoftwareImageID)
                                   .Select(x => new SoftwareTestPlan { 
                                     Id = Id,  // example
                                     ... do more mapping here  
                                    })
                                   .ToList();
    
            if (records == null)
                return new List<SoftwareImageTestPlan>();
            else
                return records;
        }
