        private int[] ToBinaryNumbers(int value)
        {
            var binary = Convert.ToString(value, 2).Reverse();
            int ix = 0;
            return binary.Select(x => { var res = x == '1' ? (int?)Math.Pow(2, ix) : (int?)null; ix++; return res; }).Where(x => x.HasValue).Select(x => x.Value).ToArray();
        }
