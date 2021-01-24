        public IMvxAsyncCommand<SeekBar.StopTrackingTouchEventArgs> PlayProgressChanged
        {
            get
            {
                return new MvxAsyncCommand<SeekBar.StopTrackingTouchEventArgs>(OnPlayProgressChange);
            }
        }
        private async Task OnPlayProgressChange(SeekBar.StopTrackingTouchEventArgs e)
        {
            var progr = e.SeekBar.Progress;
            await _playingService.SetTime((int) progr).ConfigureAwait(false);
        }
