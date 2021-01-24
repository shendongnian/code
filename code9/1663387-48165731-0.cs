    public static void CountSum(decimal[] DNumbers, decimal Dsum)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MetTracker.GaugeCalc))
                {
                    (window as MetTracker.GaugeCalc).CalculateBtn.Content = "working...";
                }
            }
            DNumbers = Array.ConvertAll(DNumbers, element => 10000m * element);
            string TempString = GetSettingsStrings("GBCMaxStep"); // only used to initialize max step value
            Dsum = Dsum * 10000m;
            Int32 Isum = Convert.ToInt32(Dsum);
            Int32[] INumbers = Array.ConvertAll(DNumbers, element => (Int32)element);
            // int result = 0;
                GetmNumberOfSubsets(INumbers, Isum);
            success = false;
            return;
        }
        private static void GetmNumberOfSubsets(Int32[] numbers, Int32 Isum)
        {
            set = numbers;
            sum = Isum;
            FindSubsetSum();
        }
        //-------------------------------------------------------------
        static Int32[] set;
        static Int32[] subSetIndexes;
        static Int32 sum;
        static Int32 numberOfSubsetSums;
        static bool success = false;
        static List<Int32> ResultSet = new List<Int32>();
        
        static List<string> results = new List<string>();//------------------------------------------------------------
        /*
            Method: FindSubsetSum()
        */
        private static void FindSubsetSum()
        {
            numberOfSubsetSums = 0;
            Int32 numberOfElements = set.Length;
            FindPowerSet(numberOfElements);
        }
        //-------------------------------------------------------------
        /*
            Method: FindPowerSet(int n, int k)
        */
        private static void FindPowerSet(Int32 n)
        {
            // Super set - all sets with size: 0, 1, ..., n - 1
            for (Int32 k = 0; k <= n - 1; k++)
            {
                subSetIndexes = new Int32[k];
                CombinationsNoRepetition(k, 0, n - 1);
                if(subSetIndexes.Length >= GBC_MaxStepSetting) {
                    break; }
            }
            if (numberOfSubsetSums == 0)
            {
                MessageBox.Show("No subsets with wanted sum exist.");
            }
        }
        //-------------------------------------------------------------
        /*
            Method: CombinationsNoRepetition(int k, int iBegin, int iEnd);
        */
        private static void CombinationsNoRepetition(Int32 k, Int32 iBegin, Int32 iEnd)
        {
            if (k == 0)
            {
                PrintSubSet();
                return;
            }
            if (success == false)
            {
                for (Int32 i = iBegin; i <= iEnd; i++)
                {
                    subSetIndexes[k - 1] = i;
                    ++iBegin;
                    CombinationsNoRepetition(k - 1, iBegin, iEnd);
                    if (success == true)
                        break;
                }
                
            }
                return;
        }
        private static void PrintSubSet()
        {
            Int32 currentSubsetSum = 0;
            // accumulate sum of current subset
            for (Int32 i = 0; i < subSetIndexes.Length; i++)
            {
                currentSubsetSum += set[subSetIndexes[i]];
                if(currentSubsetSum > sum) { break; }
            }
            if(currentSubsetSum > sum) { return; }
            
            // if wanted sum: print current subset elements
            if (currentSubsetSum == sum)
            {
                ++numberOfSubsetSums;
                // results.Add("(");
                for (Int32 i = 0; i < subSetIndexes.Length; i++)
                {
                   results.Add((set[subSetIndexes[i]]).ToString());
                    ResultSet.Add(set[subSetIndexes[i]]);
                    if (i < subSetIndexes.Length - 1)
                    {
                        // results.Add(" ,");
                    }
                }
                // results.Add(")");
                Int32[] ResultSetArr = ResultSet.ToArray();
                decimal[] ResultSetArrD = Array.ConvertAll(ResultSetArr, element => (decimal)element);
                ResultSetArrD = Array.ConvertAll(ResultSetArrD, element => element / 10000m);
                // var message = string.Join(Environment.NewLine, ResultSetArrD);
                // message = string.Format("{0:0.0000}", message);
                int l = ResultSetArrD.Length;
                string[] ResultString = new string[l];
                foreach(int i in ResultSetArrD)
                {ResultString = Array.ConvertAll(ResultSetArrD, element => element.ToString("0.0000"));}
                var message = string.Join(Environment.NewLine, ResultString);
                decimal ResultSum = ResultSetArrD.Sum();
                MessageBox.Show(message + "\n= " + ResultSum.ToString("0.0000"), "Result");
                Array.Clear(ResultSetArrD, 0, ResultSetArrD.Length);
                Array.Clear(ResultSetArr, 0, ResultSetArr.Length);
                ResultSet.Clear();
                message = null;
                success = true;
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MetTracker.GaugeCalc))
                    {
                        (window as MetTracker.GaugeCalc).CalculateBtn.Content = "Calculate";
                    }
                }
                return;
            }
            if (success == true)
                return;
        }
