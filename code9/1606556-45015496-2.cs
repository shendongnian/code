    [HttpPost]
    public ActionResult CreateDorm(CreateDormViewModel postData) {
        var selectedFeatureIds = new List<int>();
        for (var i = 0; i < postData.CheckedOptions; i++) {
            if (postData.CheckedOptions[i] == true) {
                var selectedFeatureId = postData.AvailableOptions[i].FeatureID;
                selectedFeatureIds.Add(selectedFeatureId);
            }
        }
        // ...
    }
