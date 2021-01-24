        public int Add(int a, int b) {
            return a + b;
        }
        public static int StaticAdd(int a, int b) {
            return a + b;
        }
        public void InstanceAdd() {
            Console.WriteLine(this.Add(3,3));
        }
        public void InstanceAddStatic()
        {
            Console.WriteLine(StaticAdd(3, 3));
        }
