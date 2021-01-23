        public void createObjectSurveyCheckBox(string InputValues)
        {
            var instance = new SurveyCheckBox();
            foreach (var property in typeof(SurveyCheckBox).GetProperties().Where(x => x.Name.Contains("chkAwareness")))
            {
                if (InputValues.Contains(property.Name))
                    property.SetValue(instance, true);
            }
        }
