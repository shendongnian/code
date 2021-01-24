            using (var ms = new MemoryStream())
            {
                await _actionExecutedContext.Request.Content.CopyToAsync(ms);
                try
                {
                    ms.Position = 0;
                    using (var reader = new StreamReader(ms))
                        return reader.ReadToEnd();
                }
                catch (ObjectDisposedException exception)
                {
                    return $"Stream in RequestContentAsync is unreadable. {exception}";
                }
            }
