	class NumericUpDownCell: DataGridViewTextBoxCell
    {
        public NumericUpDownCell(): base()
        {
            this.Style.Format = "0.0";
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericCellControl nUpDown = DataGridView.EditingControl as NumericCellControl;
            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                nUpDown.Value = (Decimal)this.DefaultNewRowValue;
            }
            else
            {
                //nUpDown.Value = Decimal.Parse(this.Value.ToString());
                Object trueValue = this.Value;
                nUpDown.Value = Decimal.Parse(trueValue.ToString());
            }
        }
        public override Type EditType
        {
            get
            {
                // Return the type of the editing control 
                return typeof(NumericCellControl);  
            }
        }
        public override Type ValueType
        {
            get
            {
                return base.ValueType;
            }
            set
            {
                base.ValueType = value;
            }
        }
        public override object DefaultNewRowValue
        {
            get
            {
                // Use 1.0 as the default value.
                return 1.0m;
            }
        }
    }   
