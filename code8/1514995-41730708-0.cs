        MediaPlayer mediaPlayer = new MediaPlayer();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Open(new Uri(@"C:\temp\Kalimba.mp3"));
            if (DateTime.Now.Second % 2 == 0)
            {
                mediaPlayer.Balance = 1;
                mediaPlayer.Play();
            }
            else
            {
                mediaPlayer.Balance = -1;
                mediaPlayer.Play();
            }
        }
