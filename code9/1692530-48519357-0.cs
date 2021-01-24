    public bool IsOn
    {
        get
        {
            return _isOn;
        }
        set
        {
            bool someCondition;
            // a test is done
            if (value != _isOn && someCondition)
            {
                _isOn = value;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Condition not OK");
                MyCheckBox.Checked = !value; // here is my solution
            }
        }
    }
