    public class Radio
    {
        private int volume;
        public int Volume
        {
            get { return volume; }
            set
            {
                if (value == volume) return;
                volume = value;
                OnVolumeChanged(new EventArgs());
            }
        }
        public event EventHandler VolumeChanged;
        protected virtual void OnVolumeChanged(EventArgs e)
        {
            VolumeChanged?.Invoke(this, e);
        }
    }
