       int _textProgress, _textMax;
        public int TextProgress
        {
            get => _textProgress;
            set
            {
                _textProgress = value;
                NotifyPropertyChanged(nameof(TextProgress));
            }
        }
    
        public int TextMax
        {
            get => _textMax;
            set
            {
                _textMax = value;
                NotifyPropertyChanged(nameof(TextMax));
            }
        }
     protected async void Button_OnClick(Object sender, EventArgs e)
        {
            TextMax = 0;
    
            var t1 = Task.Run(() => {
                TextProgress += 50;
            });
            var t2 = Task.Run(() => {
                TextProgress += 50;
            });
    
            await Task.WhenAll(t1, t2);
        }
