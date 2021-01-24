    [HttpPost]
    public ActionResult Mapping(AddSubscriptionPlanModel addSubscriptionModel, FormCollection formCollection)
        {
            var AllFeatures = String.Empty;
            var index = "AllFeatures[";
            foreach (var item in formCollection)
            {
                if (item.ToString().Contains(index))
                {
                    AllFeatures += " " + formCollection.GetValues(item.ToString())[0];
                }
            }
            //put breakpoint here to see userValues
