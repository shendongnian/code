        private Dictionary<string, IView> GetViewsFromAssembly()
        {
            var asm = System.Reflection.Assembly.GetEntryAssembly();
            var views = new Dictionary<string, IView>();
            foreach (var res in asm.GetManifestResourceNames())
            {
                using (Stream stream = asm.GetManifestResourceStream(res))
                using (StreamReader reader = new StreamReader(stream))
                {
                    views.Add(res, new View(reader.ReadToEnd()));
                }
            }
            return views;
        }
