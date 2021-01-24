    private async Task PlayMusicA()
    {
        btn_A_firstDo.BeginInvoke((Action)(() => btn_A_firstDo.Enabled = false));
        //Play some music here...
        await Task.Delay(1000);
        btn_A_firstDo.BeginInvoke((Action)(() => btn_A_firstDo.Enabled = true));
    }
