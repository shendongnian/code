    //add this wrapper property to your class:
    private string _wrapper;
    public string Wrapper
    {
        get { return _wrapper; }
        set
        {
            _wrapper = value;
            decimal d;
            if (Decimal.TryParse(_wrapper, out d))
                WageLimitFormulaID = d;
        }
    }
    private decimal _wageLimitFormulaID;
    public decimal WageLimitFormulaID
    {
        get { return _wageLimitFormulaID; }
        set { _wageLimitFormulaID = value; }
    }
----------
    <TextBox Name="LevyWageLimitFormulaID_TextBox"
                         Width="150"
                         HorizontalAlignment="Center"
                         Grid.Row="4" Grid.Column="1">
        <TextBox.Text>
            <Binding Path="SelectedStateRule.LevyRule.Wrapper" UpdateSourceTrigger="PropertyChanged">
                <Binding.ValidationRules>
                    <vm:NumericValidator ValidatesOnTargetUpdated="True" />
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>
    </TextBox>
