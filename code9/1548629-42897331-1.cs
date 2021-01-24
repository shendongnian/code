            //ObservableCollection<GeneratorObject> toIterate;
            // I am assuming that 'toIterate' is not null and bound to the UI
            toIterate.Add(new GeneratorObject(99));
            toIterate.Add(new GeneratorObject(1));
            toIterate.Add(new GeneratorObject(10));
            toIterate.Add(new GeneratorObject(6));
            var copy = toIterate.ToList();
            copy.Sort();
            foreach (GeneratorObject field in copy)
            {
            }
