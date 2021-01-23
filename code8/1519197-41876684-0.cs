    public void MyKeyDownHandler(object sender, System.Windows.Forms.KeyEventArgs e)
    {
           if(this.CurrentPageControl.RTB.Text.Length >= MY_LIMITING_CONSTANT_I_SET)
             {  
                 MyPageUserControl mpuc = new MyPageUserControl();            
                 mpuc.RTB.Text = this.CurrentPageControl.RTB.Text.Split(' ').Last();
                 thePageCollectionIPresumeYouHave.Add(mpuc);
                 this.CurrentPageControl = thePageCollectionIPresumeYouHave.Last();
                 mpuc.RTB.Focus();
             }
    }
