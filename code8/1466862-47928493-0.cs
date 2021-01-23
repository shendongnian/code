        private void BindableEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var t = typeof(T);
                if (typeof(T) == typeof(decimal?))
                {
                    t = Nullable.GetUnderlyingType(t);
                    var results = decimal.TryParse(e.NewTextValue, out var tmpValue) ?
                        tmpValue : (decimal?) null;
                    NumericText = (T)Convert.ChangeType(results, t);
                }
                else if (typeof(T) == typeof(double?))
                {
                    t = Nullable.GetUnderlyingType(t);
                    var results = double.TryParse(e.NewTextValue, out var tmpValue) ?
                        tmpValue : (double?)null;
                    NumericText = (T)Convert.ChangeType(results, t);
                }
                else if (typeof(T) == typeof(int?))
                {
                    t = Nullable.GetUnderlyingType(t);
                    var results = int.TryParse(e.NewTextValue, out var tmpValue) ?
                        tmpValue : (int?)null;
                    NumericText = (T)Convert.ChangeType(results, t);
                }
            }
            else
            {
                NumericText = default(T);
            }
        }
