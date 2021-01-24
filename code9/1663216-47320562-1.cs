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
