    public class Vehicle
    {
        private Radio musicRadio;
        public Radio MusicRadio
        {
            get { return musicRadio; }
            set
            {
                musicRadio = value;
                if (musicRadio != null)
                {
                    // In the unlikely event that the same radio is assigned more than once, 
                    // we only want to subscribe to the event one time, so remove it first.
                    musicRadio.VolumeChanged -= MusicRadio_VolumeChanged;
                    musicRadio.VolumeChanged += MusicRadio_VolumeChanged;
                }
            }
        }
        private void MusicRadio_VolumeChanged(object sender, EventArgs e)
        {
            Explode();
        }
        private void Explode()
        {
            if (MusicRadio.Volume == 10)
            {
                Application.Shutdown();
            }
        }
    }
