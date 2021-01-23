    private void Right_Click(object sender, EventArgs e)
    {         
        using (var ctx = new NORTHWNDEntities())
        {
            if (currentIndex < ctx.Employees.Count())
            {
                Employee empl = ctx.Employees.ToList().ElementAt(currentIndex);
                Id.Text = empl.EmployeeID.ToString();
                FirstName.Text = empl.FirstName;
                LastName.Text = empl.LastName;
                DateOfBirth.Text = empl.BirthDate.Value.ToShortDateString();
                currentIndex++;
            }
            else
            {
                Load();
            }
        }
    }
