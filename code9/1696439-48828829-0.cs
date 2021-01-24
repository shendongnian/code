    public interface ISettingsService
    {
        double Volumne { get; set; }
        string LastMediaUrl { get; set; }
        MediaStatus PlayingMediaStatus;
        void SaveSettings();
    }
