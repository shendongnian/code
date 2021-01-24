    class FirefoxOptionsEx : FirefoxOptions {
        public new string Profile { get; set; }
        public override ICapabilities ToCapabilities() {
            var capabilities = (DesiredCapabilities)base.ToCapabilities();
            var options = (IDictionary)capabilities.GetCapability("moz:firefoxOptions");
            var mstream = new MemoryStream();
            using (var archive = new ZipArchive(mstream, ZipArchiveMode.Create, true)) {
                foreach (string file in Directory.EnumerateFiles(Profile, "*", SearchOption.AllDirectories)) {
                    string name = file.Substring(Profile.Length + 1).Replace('\\', '/');
                    if (name != "parent.lock") {
                        using (Stream src = File.OpenRead(file), dest = archive.CreateEntry(name).Open())
                            src.CopyTo(dest);
                    }
                }
            }
            options["profile"] = Convert.ToBase64String(mstream.GetBuffer(), 0, (int)mstream.Length);
            return capabilities;
        }
    }
