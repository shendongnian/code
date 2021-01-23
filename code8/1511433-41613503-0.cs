    private void StartLoading_Click(object sender, EventArgs e)
        {
            const int max = 25;
            var progressHandler = new Progress<int>(value=>{
                LoadingText.Text = value + "/" + max;
                MainProgressBar.Value = value;
            });
    
            var progress = progressHandler as IProgress<int>;
            await Task.Run(() =>
            {
               int P = 0;
               while (P < 25)
               {
                  Thread.Sleep(130);
                  progress?.Report(++P);
               }
            }       
        }
