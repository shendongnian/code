     list = (from p in conn.Table<LocalFileInfo>() select new LocalFileInfo() {
                    IsFavorite = p.IsFavorite,
                    LastModified = p.LastModified,
                    Name = p.Name,
                    ParentFolder = p.ParentFolder,
                    Path = p.Path,
                    Size = p.Size,
                    SourceId = p.SourceId,
                    SourceName = p.SourceName,
                    SourceType = p.SourceType,
                    WhenCrawled = p.WhenCrawled
                })
