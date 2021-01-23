    var dtPicker1 = new DotNetNuke.Web.UI.WebControls.DnnDateTimePicker();
    dtPicker1.ID = "dnnDatePicker1";
    dtPicker1.Width = 300;
    dtPicker1.Calendar.RangeMinDate = System.DateTime.Today;
    dtPicker1.DateInput.EmptyMessage = "Select Date";
    mainPlaceHolder.Controls.Add(dtPicker1);
