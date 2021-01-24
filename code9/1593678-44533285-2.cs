        private void UpdateElapsedTime()
        {
            dataStore.ElapsedTicks += stopWatch.Elapsed.Ticks;
            if (stopWatch.IsRunning) stopWatch.Restart();
            timeCount.Text = new TimeSpan(dataStore.ElapsedTicks).ToString(@"hh\:mm\:ss\.ff");
        }
