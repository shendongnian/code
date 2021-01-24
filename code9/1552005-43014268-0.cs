    DateTime iDate;
          iDate = dateTimePicker1.Value;
        DateTime eDate;
          eDate = dateTimePicker2.Value;
        if (iDate > eDate ) {
          MessageBox.Show("Invalid Date.");
        }
