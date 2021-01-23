        private async void Btn1_Clicked(object sender, EventArgs e)
        {
           btn1.Text = "Wait";
            await Task.Run(async () =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    //if your code requires UI then wrap it in BeginInvokeOnMainThread
                    //otherwise just run your code
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        btn1.Text = $"Wait {i}";
                    });
                    await Task.Delay(1000);
                }
            });
            btn1.Text = "Done";
           
        }
