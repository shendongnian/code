        public static EitherAsync<string, int> Op1() =>
            1;
        public static EitherAsync<string, int> Op2() =>
            2;
        public static EitherAsync<string, int> Op3() =>
            3;
        public static EitherAsync<string, int> Calculate(int x, int y, int z) =>
            x + y + z;
        public static async Task<int> M()
        {
            var res = from x in Op1()
                      from y in Op2()
                      from z in Op3()
                      from w in Calculate(x, y, z)
                      select w;
            return await res.IfLeft(0);
        }
