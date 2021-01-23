    public void SongPick(int song) {
        if (song < musicArray.length) {
            audioSource.clip = musicArray[song];    
        }    
        audioSource.Play();
        string currentMusic = musicArray[song].name;
        songName.text = "PLAYING: " + currentMusic;
    }
