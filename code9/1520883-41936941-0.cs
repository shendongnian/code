    <TextBox>
        <TextBox.Text>
            <Binding Path="Age" UpdateSourceTrigger="PropertyChanged">
                <Binding.ValidationRules>
                    <local:StringToIntValidationRule ValidationStep="RawProposedValue"/>
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>
        ...
    </TextBox>
----------
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);
            return new ValidationResult(false, "Please enter a valid integer value.");
        }
    }
