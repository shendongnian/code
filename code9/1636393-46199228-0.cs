    private void Create()
    {
        var value = this.ExecutionName; //the property to validate
        var results = new List<ValidationResult>();
        var result = Validator.TryValidateProperty(
            value,
            new ValidationContext(this, null, null)
            {
                MemberName = "ExecutionName" //the name of the property to validate
            },
            results);
        if (!result)
        {
            var validationResult = results.First();
            MessageBox.Show(validationResult.ErrorMessage);
        }
        //...
    }
