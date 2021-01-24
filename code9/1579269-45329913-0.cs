    private async void Ws_HelloCompleted(object sender, Please.HelloCompletedEventArgs e) {
        string error = null;
        if (e.Error != null)
            error = e.Error.Message;
        else if (e.Cancelled)
            error = "Cancelled";
        if (!string.IsNullOrEmpty(error)) {
            await DisplayAlert("Error", error, "OK", "Cancel");
        } else {
            test.Text = e.Result;
        }
    }
