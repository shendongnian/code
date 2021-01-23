        private void FastForwardButton_Click(object sender, RoutedEventArgs e)
        { try
            { do
                {
                    ManageFrequencyChange(0.1);
                }
                while (FMRadio.Instance.SignalStrength * 100 < 65);
            }
            catch (RadioDisabledException ex)
            {
                
            }
        }
