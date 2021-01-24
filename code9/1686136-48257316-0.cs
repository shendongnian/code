    public void SetMusicVolume()
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(musicVolume.value <= 0 ? 0.001f : musicVolume.value) * 40f);
        musicText.text = Math.Round(musicVolume.value * 100, MidpointRounding.AwayFromZero).ToString();
    }
