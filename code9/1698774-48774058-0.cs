    private List<T> GetVideosSection<T>(IEnumerable<ContentAreaItem> items)
        {
            List<T> blocks = null;
            if (items != null)
            {
                blocks = new List<T>();
                foreach (var reference in items)
                {
                    var block = _repo.Get<T>(reference.ContentLink);
                    blocks.Add(block);
                }
            }
            return blocks;
        }
