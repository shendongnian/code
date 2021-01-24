    static int simpleArraySum(int[] ar,int count) {
            if (count > 0 && count <= 10000)
                {
                    if (count == ar.Length)
                    {
                        if (!ar.Any(item => (item < 0 || item >= 10000)))
                        {
                            return ar.Sum();
                        }
                    }
                }
                return 0;        
        }
