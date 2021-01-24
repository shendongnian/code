    foreach (SchoolModel sc in schoolData.Where(s => s.IsHidden == false))
    {
        var schoolMeals = meals.Where(m => m.SchoolId == sc.Id);
        var byInvoiceMealType = schoolMeals.ToLookup(m => m.InvoiceMealType);
        ...
        MealsKs1 = byInvoiceMealType[InvoiceMealType.KeyStage1].Sum(s => s.MealNo),
