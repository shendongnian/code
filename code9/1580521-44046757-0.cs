            CustomCollection<RuleExpression> oOperands = new CustomCollection<RuleExpression>();
            oOperands.Add(new RuleExpression("Windows/All_x64_Windows_7_Client"));
            ExpressionOperator oOperator = ExpressionOperator.OneOf;
            OperatingSystemExpression oOSExpression = new OperatingSystemExpression(oOperator, oOperands);
            Annotation oAnnotation = new Annotation();
            oAnnotation.DisplayName = new LocalizableString("DisplayName", "Operating system One of (All Windows 7 (64-bit))", null);
            NoncomplianceSeverity oNonComplianceSeverity = NoncomplianceSeverity.None;
            Rule nextRule = new Rule("Rule_" + Guid.NewGuid().ToString("B").Replace("{", string.Empty).Replace("}", string.Empty), oNonComplianceSeverity, oAnnotation, oOSExpression);
            thisDT.Requirements.Add(nextRule);
