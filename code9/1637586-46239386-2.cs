      private void lbFavo_MouseDoubleClick(object sender, MouseEventArgs e)
      {
           switch( lbFavo.SelectedItem )
           {
              //useful for tidiness sake if you want to disable a lot of "URL's"
              case "www.nu.nl":
              case "www.weeronline.nl":
              case "www.buienradar.nl":
                    //output error message, or just do nothing
                    break;
              default: 
                   webBrowser.Navigate(lbFavo.SelectedItem.ToString());
                   tabWeb.TabPages[0].Text = lbFavo.SelectedItem.ToString();
                   break;
           }
           if (cbGeschiedenis.Items.IndexOf(lbFavo.SelectedItem.ToString()) == cbGeschiedenis.SelectedIndex)
           {
              webBrowser.Navigate(lbFavo.SelectedItem.ToString());
              cbGeschiedenis.Items.Add(lbFavo.SelectedItem.ToString());
           }
           else
           {
              ErrorMelding.SetError(txtURL, "U moet zich bezig houden met werk en niet met prive!!");
           }
      }
