      private void lbFavo_MouseDoubleClick(object sender, MouseEventArgs e)
      {
           //using && instead of || here. You want to evaluate all strings before you navigate to the site.
           if (lbFavo.SelectedItem != "www.nu.nl" && lbFavo.SelectedItem != "www.weeronline.nl" && lbFavo.SelectedItem != "www.buienradar.nl")
           {
              webBrowser.Navigate(lbFavo.SelectedItem.ToString());
              tabWeb.TabPages[0].Text = lbFavo.SelectedItem.ToString();
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
