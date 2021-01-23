        private void Play()
        {
            if (vlcVideo.IsPlaying)
            {
                vlcVideo.Stop();
            }
            string path = @"E:\Sample\2.mjp";
            LocationMedia media = new LocationMedia(path);
            vlcVideo.Media = media;
            vlcVideo.Play();
        }
