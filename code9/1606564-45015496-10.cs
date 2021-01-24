    [HttpPost]
    public ActionResult CreateDorm(CreateDormViewModel postData) {
        var selectedFeatureIds = new List<int>();
        foreach (var option in postData.DormOptions) {
            if (option.Checked) {
                selectedFeatureIds.Add(option.FeatureID);
            }
        }
        // ...
    }
