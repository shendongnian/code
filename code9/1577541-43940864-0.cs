       string myText = tbProductId.Text;
            if (myText.Equals(""))
            {
                MessageBox.Show("Please enter somthing");
            }
            else
            {
                tbProductId.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInf‌​o.ToTitleCase(tbProd‌​uctId.Text);
                tbProductId.Focus();
                tbProductId.Select(tbProductId.Text.Length, 0);
                //Move Cursor to location of where error
            }
