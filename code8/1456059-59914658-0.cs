        public static string LinkifyYoutube(this string url)
        {
            if (!url.Contains("data-linkified"))
            {
                return "";
            }
            int pos1 = url.IndexOf("<a target=\'_blank\' data-linkified href=\'", StringComparison.Ordinal);
            int pos2 = url.IndexOf("</a>", StringComparison.Ordinal);
            if (pos1 <= -1 || pos2 - pos1 <= 0)
            {
                return "";
            }
            url = url.Substring(pos1, pos2 - pos1);
            url = url.Replace("<a target=\'_blank\' data-linkified href=\'", "");
            url = url.Replace("\'>", "");
            url = url.Replace("</a>", "");
            var zh = url.LastIndexOf("https", StringComparison.Ordinal);
            if (zh <= 0)
            {
                return "";
            }
            url = url.Substring(0, zh);
            Uri uri = null;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                try
                {
                    uri = new UriBuilder("http", url).Uri;
                }
                catch
                {
                    return "";
                }
            }
            string host = uri.Host;
            string[] youTubeHosts = { "www.youtube.com", "youtube.com", "youtu.be", "www.youtu.be" };
            if (!youTubeHosts.Contains(host))
            {
                return "";
            }
            var query = HttpUtility.ParseQueryString(uri.Query);
            if (query.AllKeys.Contains("v"))
            {
                return Regex.Match(query["v"], @"^[a-zA-Z0-9_-]{11}$").Value;
            }
            else if (query.AllKeys.Contains("u"))
            {
                return Regex.Match(query["u"], @"/watch\?v=([a-zA-Z0-9_-]{11})").Groups[1].Value;
            }
            else
            {
                var last = uri.Segments.Last().Replace("/", "");
                if (Regex.IsMatch(last, @"^v=[a-zA-Z0-9_-]{11}$"))
                {
                    return last.Replace("v=", "");
                }
                string[] segments = uri.Segments;
                if (segments.Length > 2 && segments[segments.Length - 2] != "v/" && segments[segments.Length - 2] != "watch/")
                {
                    return "";
                }
                return Regex.Match(last, @"^[a-zA-Z0-9_-]{11}$").Value;
            }
        }
