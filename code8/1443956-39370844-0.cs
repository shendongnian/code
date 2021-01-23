        private void MyCode()
        {
            Exception exe = new Exception("Blah");
            exe.Populate();
            DoSomeWork(exe);
        }
        public static void Populate(this System.Exception source)
        {
            try
            {
                throw source;
            }
            catch
            {
            }
        }
