    using System;
    
    namespace ConsoleApplication1
    {
        public class ConsistantRandom: Random
        {
            private const int MBIG = Int32.MaxValue;
            private const int MSEED = 161803398;
            private const int MZ = 0;
    
            private int inext;
            private int inextp;
            private int[] SeedArray = new int[56];
    
            public ConsistantRandom()
                : this(Environment.TickCount)
            {
            }
    
            public ConsistantRandom(int seed)
            {
                int ii;
                int mj, mk;
    
                int subtraction = (seed == Int32.MinValue) ? Int32.MaxValue : Math.Abs(seed);
                mj = MSEED - subtraction;
                SeedArray[55] = mj;
                mk = 1;
                for (int i = 1; i < 55; i++)
                {
                    ii = (21 * i) % 55;
                    SeedArray[ii] = mk;
                    mk = mj - mk;
                    if (mk < 0) mk += MBIG;
                    mj = SeedArray[ii];
                }
                for (int k = 1; k < 5; k++)
                {
                    for (int i = 1; i < 56; i++)
                    {
                        SeedArray[i] -= SeedArray[1 + (i + 30) % 55];
                        if (SeedArray[i] < 0) SeedArray[i] += MBIG;
                    }
                }
                inext = 0;
                inextp = 21;
            }
            protected override double Sample()
            {
                return (InternalSample() * (1.0 / MBIG));
            }
    
            private int InternalSample()
            {
                int retVal;
                int locINext = inext;
                int locINextp = inextp;
    
                if (++locINext >= 56) locINext = 1;
                if (++locINextp >= 56) locINextp = 1;
    
                retVal = SeedArray[locINext] - SeedArray[locINextp];
    
                if (retVal == MBIG) retVal--;
                if (retVal < 0) retVal += MBIG;
    
                SeedArray[locINext] = retVal;
    
                inext = locINext;
                inextp = locINextp;
    
                return retVal;
            }
    
            public override int Next()
            {
                return InternalSample();
            }
    
            private double GetSampleForLargeRange()
            {
                int result = InternalSample();
                bool negative = (InternalSample() % 2 == 0) ? true : false;
                if (negative)
                {
                    result = -result;
                }
                double d = result;
                d += (Int32.MaxValue - 1);
                d /= 2 * (uint)Int32.MaxValue - 1;
                return d;
            }
    
    
            public override int Next(int minValue, int maxValue)
            {
                if (minValue > maxValue)
                {
                    throw new ArgumentOutOfRangeException("minValue");
                }
    
                long range = (long)maxValue - minValue;
                if (range <= (long)Int32.MaxValue)
                {
                    return ((int)(Sample() * range) + minValue);
                }
                else
                {
                    return (int)((long)(GetSampleForLargeRange() * range) + minValue);
                }
            }
            public override void NextBytes(byte[] buffer)
            {
                if (buffer == null) throw new ArgumentNullException("buffer");
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = (byte)(InternalSample() % (Byte.MaxValue + 1));
                }
            }
        }
        
    }
