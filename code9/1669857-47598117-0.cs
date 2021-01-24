     int movieId; 
     int.tryParse(one_data2.Rows["0"].Cells["MovieID"].Text, out movieId);
     string subId = one_data2.Rows["0"]["SubscriberID"].Text;
     string dueDate = one_data2.Rows["0"]["DueDate"].Text;
     string yourStringFormat ="yyyy-MM-dd" // or whatever format your GridView has
     DateTime lateDate;
     DateTime.TryParseExact(yourStringFormat, pattern, null, System.Globalization.DateTimeStyles.None, out lateDate);
