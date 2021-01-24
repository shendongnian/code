    public class MyCustomValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is MyDataObject)
            {
                var myDataObj = (MyDataObject)value;
                if (myDataObj.CheckCustomBusinessRules())
                    return new ValidationResult(true, null);
            }
     
            return new ValidationResult(false, "Invalid selection!");
        }
    }
    <ComboBox.SelectedItem>
        <Binding Path="SomeData" ElementName="Window">
            <Binding.ValidationRules>
                <local:PersonValidation />
            </Binding.ValidationRules>
        </Binding>
    </ComboBox.SelectedItem>
