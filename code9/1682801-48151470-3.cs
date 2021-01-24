    public async void Button_Clicked(object sender, EventArgs e)
    {
         // indicate you will do something time consuming:
         this.ProgressBar1.Visible = true;
         await DoSomethingTimeconsumingAsync(...);
         // finished:
         this.progressBar1.Visible = false;
    }
