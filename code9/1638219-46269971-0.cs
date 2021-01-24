       try
       {
        .... your code ...
       }
       catch (FormatException ex)
       {
            //FormatException was thrown, display your message
            MessageBox.Show("You forgot to put the number!");
       }
       catch (Exception ex)
       {
            // Some other kind of exception was thrown ...
            MessageBox.Show(ex.Message);
       }
