    public void onIsIdleChanged(Frame frame)
        {
            System.Diagnostics.Debug.WriteLine($"IsIdle: {App.Current.IsIdle}");
            if (App.Current.IsIdle == true)
            {
                //VideoFadeIn.Begin();
                if (!playing)
                    playRandomVideo();
            }
            if (App.Current.IsIdle == false)
            {
                //VideoFadeIn.Stop();
                if (!clickedSelected)
                {
                    stopVideo();
                    if (!playingSelected)
                        frame.Navigate(typeof(Calculadoras));
                    else
                        playingSelected = false;
                }
                else
                {
                    App.Current.IsIdle = true;
                    clickedSelected = false;
                }
            }
        }
