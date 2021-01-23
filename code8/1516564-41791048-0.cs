        using (var pack = ZipPackage.Open(xpsFileName, FileMode.Open, FileAccess.ReadWrite))
        {
            foreach (var part in pack.GetParts()) if (part.Uri.OriginalString.EndsWith(".fpage"))
                {
                    using (var file = part.GetStream(FileMode.Open, FileAccess.ReadWrite))
                    {
                        var page = ProcessPage(XElement.Load(file));
                        file.Position = 0;
                        page.Save(file);
                        file.SetLength(file.Position);
                    }
                }
        }
