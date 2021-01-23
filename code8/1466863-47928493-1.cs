        private void BindableEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var t = typeof(T);
                t = Nullable.GetUnderlyingType(t);
                if (typeof(T) == typeof(decimal?))
                {
                    var results = decimal.TryParse(e.NewTextValue, out var tmpValue) ?
                        tmpValue : (decimal?) null;
                    if (results != null)
                        NumericText = (T)Convert.ChangeType(results, t);
                    else
                        NumericText = default(T);
                }
                else if (typeof(T) == typeof(double?))
                {
                    var results = double.TryParse(e.NewTextValue, out var tmpValue) ?
                        tmpValue : (double?)null;
                    if (results != null)
                        NumericText = (T)Convert.ChangeType(results, t);
                    else
                        NumericText = default(T);
                }
                else if (typeof(T) == typeof(int?))
                {
                    var results = int.TryParse(e.NewTextValue, out var tmpValue) ?
                        tmpValue : (int?)null;
                    if (results != null)
                        NumericText = (T)Convert.ChangeType(results, t);
                    else
                        NumericText = default(T);
                }
            }
            else
            {
                NumericText = default(T);
            }
        }
