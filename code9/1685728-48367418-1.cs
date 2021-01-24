    class Example {
        public void GetFile(string path) {
            var fileInfo = new FileInfo(path);
            Stream stream = fileInfo.Open(FileMode.Open);
            var abstraction = new TagLib.StreamFileAbstraction(fileInfo.Name, stream, stream);
            var file = TagLib.File.Create(abstraction);//used to extrack track metadata
            
            var tag = file.Tag;
            var beatsPerMinute = tag.BeatsPerMinute; //<--
            //get other metadata about file
            var title = tag.Title;
            var album = tag.Album;
            var genre = tag.JoinedGenres;
            var artists = tag.JoinedPerformers;
            var year = (int)tag.Year;
            var tagTypes = file.TagTypes;
            var properties = file.Properties;
            var pictures = tag.Pictures; //Album art
            var length = properties.Duration.TotalMilliseconds;
            var bitrate = properties.AudioBitrate;
            var samplerate = properties.AudioSampleRate;
        }
    }
