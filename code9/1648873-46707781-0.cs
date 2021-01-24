    var mealsAndSchoolsPerformance = schoolData
        .Where(s => s.IsHidden == false)
        .AsParallel()//This causes that following query will run on multiple threads
        .Select(sc => new MealsAndSchoolPerformanceUI
            {
                Id = sc.Id,
                SchoolName = sc.SchoolName,
                Week = DateExtensions.GetIso8601WeekOfYear(startDate, true),
                TotalFoodSpent = foodSpend.ContainsKey(sc.Id) ? foodSpend[sc.Id] : 0,
                TotalHours = totalHours.ContainsKey(sc.Id) ? totalHours[sc.Id]: 0,
                MealsKs1 = meals.Where(m => m.SchoolId == sc.Id).Where(m => m.InvoiceMealType == InvoiceMealType.KeyStage1).Sum(s => s.MealNo), 
                MealsKs2 = meals.Where(m => m.SchoolId == sc.Id).Where(m => m.InvoiceMealType == InvoiceMealType.KeyStage2).Sum(s => s.MealNo), 
                MealsNursery = meals.Where(m => m.SchoolId == sc.Id).Where(m => m.InvoiceMealType == InvoiceMealType.Nursery).Sum(s => s.MealNo), 
                MealsStaff = meals.Where(m => m.SchoolId == sc.Id).Where(m => m.InvoiceMealType == InvoiceMealType.Adult).Sum(s => s.MealNo),
                MealsSenior = meals.Where(m => m.SchoolId == sc.Id).Where(m => m.InvoiceMealType == InvoiceMealType.Senior).Sum(s => s.MealNo),
                TotalSales = meals.Where(m => m.SchoolId == sc.Id).Sum(m => m.TotalPrice),
                TotalInvoicePrice = meals.Where(m => m.SchoolId == sc.Id).Sum(m => m.TotalInvoicePrice),
                Region = sc.SchoolLead?.AddressRegion ?? " ",
                SchoolGroup = sc.SchoolGroups.FirstOrDefault()?.GroupName ?? "",
                Manager = sc.ManagerUser?.FullName ?? "",
                ServiceStarted = sc.ServiceStarted,
                RollNoNursery = sc.RollNoNursery ?? 0,
                RollNoSchool = sc.RollNoSchool ?? 0,
                ServingDays = MealBL.MealServingDays(sc.Id, startDate, startDate.AddDays(6))
            })
        .ToList();
