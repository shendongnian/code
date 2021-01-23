      void Serial(string port)
      {
          SerialPort sp = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
          try
          {
               sp.Open();
               try
               {
                   sp.WriteLine("G"); // Send 1 to Arduino
                   sp.Close();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
           }
           catch (Exception e)
           {
                System.Diagnostics.Debug.WriteLine(e.Message); 
           }
      }
