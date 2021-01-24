        private class ChemicalFilter : Filter
        {
            private readonly RecyclerViewAdapter _adapter;
            public ChemicalFilter(RecyclerViewAdapter adapter)
            {
                _adapter = adapter;
            }
            protected override FilterResults PerformFiltering(ICharSequence constraint)
            {
                var returnObj = new FilterResults();
                var results = new List<Chemical>();
                if (_adapter._originalData == null)
                    _adapter._originalData = _adapter._items;
                
                if (constraint == null) return returnObj;
                if (_adapter._originalData != null && _adapter._originalData.Any())
                {
                    // Compare constraint to all names lowercased. 
                    // It they are contained they are added to results.
                    results.AddRange(
                        _adapter._originalData.Where(
                            chemical => chemical.Name.ToLower().Contains(constraint.ToString())));
                }
                
                // Nasty piece of .NET to Java wrapping, be careful with this!
                returnObj.Values = FromArray(results.Select(r => r.ToJavaObject()).ToArray());
                returnObj.Count = results.Count;
                constraint.Dispose();
                return returnObj;
            }
            protected override void PublishResults(ICharSequence constraint, FilterResults results)
            {
                using (var values = results.Values)
                    _adapter._items = values.ToArray<Java.Lang.Object>()
                        .Select(r => r.ToNetObject<Chemical>()).ToList();
                    
                _adapter.NotifyDataSetChanged();
                // Don't do this and see GREF counts rising
                constraint.Dispose();
                results.Dispose();
            }
        }
