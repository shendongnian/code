        private IEnumerable<string> GetBindingPropertyNames(DependencyObject target)
        {
            return from path in GetBindingPaths(target) select path.Split('.').First();
        }
        private IEnumerable<string> GetBindingPaths(DependencyObject target)
        {
            var ret = new List<string>();
            LocalValueEnumerator lve = target.GetLocalValueEnumerator();
            while (lve.MoveNext())
            {
                LocalValueEntry entry = lve.Current;
                if (entry.Value is DependencyObject)
                {
                    ret.AddRange(GetBindingPaths(entry.Value as DependencyObject));
                }
                if (BindingOperations.IsDataBound(target, entry.Property))
                {
                    Binding binding = (entry.Value as BindingExpression).ParentBinding;
                    ret.Add(binding.Path.Path);
                }
            }
            return ret;
        }
