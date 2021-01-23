    private int GetGender()
        {
            if (rbMale.Checked)
            {
                return (int)Gender.Male;
            }
            else if (rbFemale.Checked)
            {
                return (int)Gender.Female;
            }
            else
            {
                return (int)Gender.NoSelection;
            }
        }
