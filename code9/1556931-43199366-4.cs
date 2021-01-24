    if (resultStation != resultStation2)
    {
        MessageBox.Show("Номера на станцията в единия файл не отговаря на номера на станцията в другият файл!" + Environment.NewLine + Environment.NewLine +
                    "ЗАБЕЛЕЖКА!" + Environment.NewLine + Environment.NewLine + "В двата файла, номера на станцията трябва да бъде един и същ!");
    }
    comboBox1.Items.Add(resultStation);
    for (int i = 0; i < (this.resultYears.Count > this.resultYears2.Count ? this.resultYears.Count : this.resultYears2.Count); i++)
    {
        var year = i < this.resultYears.Count ? this.resultYears[i] : string.Empty;
        var year2 = i < this.resultYears2.Count ? this.resultYears2[i] : string.Empty;
        if (year == year2)
        {
            comboBox2.Items.Add(year);
        }
        else
        {
            MessageBox.Show("Годините от двата файла не съвпадат.");
        }
    }
