        static void Main(string[] args)
        {
            int[] Primes = { 1,2,3,4,5,6,7 };
            EasyCL cl = new EasyCL();
            cl.Accelerator = AcceleratorDevice.GPU;
            cl.LoadKernel(IsPrime);
            cl.Invoke("GetIfPrime", 0, Primes.Length, Primes, 1.0);
        }
        static string IsPrime
        {
            get
            {
                return @"
                kernel void GetIfPrime(global int* num, int period)
                {
                    int index = get_global_id(0);
	                
                    int sum = (2.0 / (1.0 + period)) * (num[index] - num[0]);
		            printf("" %d \n"",sum);
	            }";
            }
        }
   
