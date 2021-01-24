    .Field(nameof(DepartmentName),
        validate: (state, response) =>
        {
            var value = (string)response;
            string[] departments = Enum.GetNames(typeof(Department)).ToArray();
    
            IEnumerable<Choice> choices = departments.Select(d => new Choice()
                    {
                        Description = new DescribeAttribute(d, null, null, null, null),
                        Terms = new TermsAttribute() { Alternatives = new[] { d } },
                        Value = d
                    }).ToArray();
    
            var result = new ValidateResult()
            {
                IsValid = false,
                Choices = choices,
                Feedback = "Department name is not valid."
            };
    
            if (departments.Any(x => x.ToLower() == value))
            {
                result.IsValid = true;
                result.Feedback = null;
                result.Value = value;
            }
            return Task.FromResult<ValidateResult>(result);
        });
