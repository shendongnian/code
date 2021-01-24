    DateTime dt1;
              dt1 = DateTime.Parse("8:00:00");
            DateTime dt2;
              dt2 = DateTime.Parse("20:00:00");
        if (dt1 <= DateTime.Now && DateTime.Now >= dt2) 
            {
              MessageBox.Show(DateTime.Now.ToString("h:mm tt"));
            }
         else MessageBox.Show("No.");
