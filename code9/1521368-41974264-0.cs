      bool isstoreTapped = false;
      bool iskoleksiTapped = false;
      private void loginBtn_Click(object sender, RoutedEventArgs e)
      {
          loadingLogin.IsActive = true;
          FailedMessage.Visibility = Visibility.Collapsed;
          ProsesLogin();
          if(isstoreTapped==true)
          {
              this.Frame.Navigate(typeof(Store));
          }
          if(iskoleksiTapped==true)
          {
              this.Frame.Navigate(typeof(koleksibuku.KolesiPage));
          }
       
      }
      private void store_Tapped(object sender, TappedRoutedEventArgs e)
      {
          if (((App)(App.Current)).UserName == "Sign in to your account")
          {
              LoginDialog.IsOpen = true;
              loginDetail.Visibility = Visibility.Collapsed;
              loginEnter.Visibility = Visibility.Visible;
              emailBox.Text = "";
              passwordBox.Password = "";
              isstoreTapped = true;
              iskoleksiTapped = false;
          }
          else
          {
              this.Frame.Navigate(typeof(Store));
          }
      }
      private void koleksi_Tapped(object sender, TappedRoutedEventArgs e)
      {
          if (((App)(App.Current)).UserName == "Sign in to your account")
          {
              LoginDialog.IsOpen = true;
              loginDetail.Visibility = Visibility.Collapsed;
              loginEnter.Visibility = Visibility.Visible;
              emailBox.Text = "";
              passwordBox.Password = "";
              iskoleksiTapped = true;
              isstoreTapped = false;
          }
          else
          {
              this.Frame.Navigate(typeof(koleksibuku.KolesiPage));
          }
      }
