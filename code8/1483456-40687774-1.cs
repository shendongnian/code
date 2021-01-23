        private static Task<int> SleepAsync(int MS)
    {
        return Task.Run(() =>
        {
            Thread.Sleep(MS);
            return MS / 1000;
        });
    }
            private async void StatusLoopTimer_Tick(object sender, EventArgs e)
        {
            oSkype.CurrentUserStatus = TUserStatus.cusOnline;
            await SleepAsync(1000);
            oSkype.CurrentUserStatus = TUserStatus.cusDoNotDisturb;
            await SleepAsync(1000);
            oSkype.CurrentUserStatus = TUserStatus.cusAway;
            await SleepAsync(1000);
            oSkype.CurrentUserStatus = TUserStatus.cusInvisible;
            await SleepAsync(1000);
        }
