      string actualPassword = "";
      string displayedPassword = "";
      DispatcherTimer dispatcherTimer = new DispatcherTimer();
      public MainWindow()
      {
         InitializeComponent();
         tbPassword.PreviewKeyDown += tbPassword_PreviewKeyDown;
         tbPassword.PreviewTextInput += tbPassword_PreviewTextInput;
         dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
         dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
      }
      private void tbPassword_PreviewKeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Back)
         {
            if (actualPassword.Length > 0)
            {
               actualPassword = actualPassword.Substring(0, actualPassword.Length - 1);
               if (actualPassword.Length > 0)
               {
                  ShowLastCharacter();
                  tbPassword.CaretIndex = displayedPassword.Length;
               }
            }
         }
      }
      private void tbPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
      {
         actualPassword += e.Text;
         e.Handled = true;
         ShowLastCharacter();
         tbPassword.CaretIndex = displayedPassword.Length;
      }
      private void ShowLastCharacter()
      {
         var lastChar = actualPassword.Substring(actualPassword.Length - 1);
         displayedPassword = "";
         for (int i = 0; i < actualPassword.Length - 1; i++)
            displayedPassword += "•";
         displayedPassword += lastChar;
         tbPassword.Text = displayedPassword;
         if (dispatcherTimer.IsEnabled)
            dispatcherTimer.Stop();
         dispatcherTimer.Start();
      }
      private void dispatcherTimer_Tick(object sender, EventArgs e)
      {
         displayedPassword = "";
         for (int i = 0; i < actualPassword.Length; i++)
            displayedPassword += "•";
         tbPassword.Text = displayedPassword;
         tbPassword.CaretIndex = displayedPassword.Length;
      }
