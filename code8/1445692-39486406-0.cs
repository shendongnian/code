    private void volumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
            {
                if (volumeSlider != null) {
                    var volume = float.Parse(volumeSlider.Value.ToString());
                    volumeTextBox.Text = volume.ToString();
                }
            }
