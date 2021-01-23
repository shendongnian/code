      private void LosujPytania()
        {
            Random losowa = new Random();
            List<int> pula = new List<int>();
            int a = losowa.Next(1, 20);
            pula.AddRange(Get10RandomNumbers(losowa));
        }
        private IEnumerable<int> Get10RandomNumbers(Random losowa)
        {
            HashSet<int> ints = new HashSet<int>();   
            while (ints.Count < 10)
            {
                ints.Add(losowa.Next(20));
            }
            return ints;
        }
