      public string VideoName { get; set; }
        public string Author { get; set; }
        public Uri Vid_url { get; set; }
        public BitmapImage Image { get; set; }
        public VideoListItem(string videoname,string author,Uri url, BitmapImage img)
        {
            this.VideoName = videoname;
            this.Author = author;
            this.Vid_url = url;
            this.Image = img;
        }
