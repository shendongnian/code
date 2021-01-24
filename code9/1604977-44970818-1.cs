    private readonly Dictionary<string, BitmapImage> EmojiCache = new Dictionary<string, BitmapImage>();
    private BitmapImage GetEmoji(string emojiCode) {
        if (EmojiCache.ContainsKey(emojiCode)) {
            return EmojiCache[emojiCode];
        }
        WebClient client = new WebClient();
        byte[] emojiBytes = client.DownloadData($"https://twemoji.maxcdn.com/2/72x72/{emojiCode}.png");
        BitmapImage emojiImg = new BitmapImage();
        using (MemoryStream ms = new MemoryStream(emojiBytes)) {
            ms.Position = 0;
            emojiImg.BeginInit();
            emojiImg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            emojiImg.CacheOption = BitmapCacheOption.OnLoad;
            emojiImg.UriSource = null;
            emojiImg.StreamSource = ms;
            emojiImg.EndInit();
        }
        EmojiCache.Add(emojiCode, emojiImg);
        return emojiImg;
    }
