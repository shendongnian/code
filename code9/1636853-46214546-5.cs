    dynamic formData=new ExpandoObject();
    formData.Name = "Job blogs";
    formData.Date = DateTime.Today;
    formData.IsEnabled = true;
    formData.Titles = new []{ 
                               new SelectedListeItem{Text="Mr",Value="Mr"},
                               new SelectedListeItem{Text="Mrs",Value="Mrs"}
                            };
