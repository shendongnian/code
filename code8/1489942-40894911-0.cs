    class RTTutils
    {
        private bool verbose = false;
        private bool canWrite = false;
    
        private RTTutils()
        {
            sampleList.Add(100);    // First sample should be 100
            optionChosen.Add("E");
    
            x = 5;
            y = 5;
    
            System.IO.File.Delete(this.path);
        }
    
        private RTTutils(bool verbose) : this()
        {
            this.verbose = verbose;
        }
        private void RTTCalc()
        {
            if (this.verbose)
                Console.WriteLine("Test");
        }    
        public static RTTutils Create(bool verbose)
        {
          RTTutils result = new RTTutils(verbose);
          result.RTTCalc();
          return result;
        }
    }
