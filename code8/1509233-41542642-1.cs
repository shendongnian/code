     List<DateTime> dates = new List<DateTime>();
     dates.Add(new DateTime(2017, 12, 10));
     dates.Add(new DateTime(2016, 12, 10));
     dates.Add(new DateTime(2016, 8, 5));
    
     dates.Sort();
     repositoryItemComboBox1.Items.AddRange(dates);
