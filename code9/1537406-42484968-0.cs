                try
                {
                    int left = 1;
                    int right = 38;
                    double Both;
                    bool ConverstionSucceed = double.TryParse((left + "." + right), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out Both);
                }
                catch (Exception ex)
                {
                }
