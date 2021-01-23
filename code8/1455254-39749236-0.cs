    private void AudioComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (AudioComboBox.SelectedIndex == AudioComboBox.Items.IndexOf("Sali 3la Mohammed 1"))
                {
                    play1();
                }
    
                else if (AudioComboBox.SelectedIndex == AudioComboBox.Items.IndexOf("Sali 3la Mohammed 2"))
                {
                    play2();
                }
            }
    
    
            private void play1()
            {
                SoundPlayer simpleSound = new SoundPlayer("sound1.wav");
                simpleSound.Play();
            }
            private void play2()
            {  
                SoundPlayer simpleSound = new SoundPlayer("sound2.wav");
                simpleSound.Play();
            }
