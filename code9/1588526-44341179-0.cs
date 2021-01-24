      var data11 = (from p in db.FeePlan.Where(d => d.AcademicYearID == dts.AcademicYearID && d.Active == true && d.IsEffectiveDates == false)
                              from fb in db.FeePlansToBranches.Where(x => x.FeePlanID == p.FeePlanID && x.BranchID == BranchID)
                              from b in db.Branches.Where(b => b.BranchID == fb.BranchID)
                              from fp in db.AssignFeeplanToClasses.Where(a => a.BranchID == BranchID && a.ClassID == ClassID && a.FeePlanID == p.FeePlanID)
                              from cl in db.Classes.Where(c => c.ClassID == fp.ClassID)
                              select new
                              {
                                  p.FeePlanName,
                                  p.FeePlanID,
                                  b.BranchName,
                                  cl.ClassName,
                                  fp.AssignFeeplanToClassID,
                                  fp.CreatedDate
                              }).Distinct().ToList().AddRange(
    
                (from p in db.FeePlan.Where(d => d.AcademicYearID == dts.AcademicYearID && d.Active == true &&d.IsEffectiveDates == true)
                             from fb in db.FeePlansToBranches.Where(x => x.FeePlanID == p.FeePlanID && x.BranchID == BranchID)
                             from b in db.Branches.Where(b => b.BranchID == fb.BranchID)
                             from fp in db.AssignFeeplanToClasses.Where(a => a.BranchID == BranchID && a.ClassID == ClassID && a.FeePlanID == p.FeePlanID)
                             from cl in db.Classes.Where(c => c.ClassID == fp.ClassID)
                             where (DateTime.Now> p.StartDate && DateTime.Now < p.EndDate)
                             select new
                             {
                                 p.FeePlanName,
                                 p.FeePlanID,
                                 cl.ClassName,
                                 b.BranchName,
                                 fp.AssignFeeplanToClassID,
                                 fp.CreatedDate
                             }).Distinct().ToList());
