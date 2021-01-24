    private MyDataObject _someData;
    public MyDataObject SomeData
    {
        get
        {
            return _ someData;
        }
        set
        {
            _ someData = value;
            if (value == null || string.IsNullOrEmpty(value.MyProperty))
                throw new ApplicationException("SomeData is required");
        }
    }
    <ComboBox.SelectedItem>
        <Binding Path="SomeData" ElementName="Window">
            <Binding.ValidationRules>
                <ExceptionValidationRule />
            </Binding.ValidationRules>
        </Binding>
    </ComboBox.SelectedItem>
