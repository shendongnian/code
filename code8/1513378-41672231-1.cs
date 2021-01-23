        public static int GetMaximumProduct(string number, int quantity)
        {
            if (number == null)
                throw new ArgumentNullException(nameof(number));
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (quantity > number.Length)
                throw new ArgumentException($"{nameof(quantity)} can not be greater than the length of {nameof(number)}.");
            var maximumProduct = 0;
            var normalizedNumber = number.Trim();
            normalizedNumber = normalizedNumber.StartsWith("-") ? normalizedNumber.Substring(1) : normalizedNumber;
            if (string.IsEmpty(normalizedNumber))
            {
                 product = 0;
                 return true;
            }
            for (var i = 0; i < normalizedNumber.Length - (quantity - 1); i++)
            {
                int currentProduct;
                if (TryMultiplyDigits(normalizedNumber.Substring(i, quantity), out currentProduct))
                {
                    if (currentProduct > maximumProduct)
                    {
                        maximumProduct = currentProduct;
                    }
                }
                else
                {
                    throw new FormatException("Specified number does not have the correct format.");
                }
            }
            return maximumProduct;
        }
