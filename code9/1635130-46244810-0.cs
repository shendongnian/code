    private async void Test()
    {
      testbtn.Visibility = Visibility.Visible;
      IProgress<string> progress = new Progress<string>(value => { ... });
      await Task.Run(() => LoadAll(progress));
      testbtn.Visibility = Visibility.Collapsed;
    }
