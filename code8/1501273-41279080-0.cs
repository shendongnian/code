    private async void button_Click(object sender, EventArgs e)
    {
        if (!submitIsActive)
        {
            submitIsActive = true;
            await SubmitAsync();
            submitIsActive = false;
        }
    }
