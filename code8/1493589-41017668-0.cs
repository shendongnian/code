    public class TestThread
    {
        public void CountTo10(string _threadName)
        {
            Realm realm = Realm.GetInstance();
            for (int i = 0; i < 5; i++)
            {
                realm.Write(() =>
                {
                    RandomNumber random = new RandomNumber();
                    System.Console.WriteLine("Iteration: " + i.ToString() + " Random No: " + random.number.ToString() + " from " + _threadName);
                    realm.Manage(random);
                });
    
                Thread.Sleep(500);
            }
            // no need to call `Realm.close()` in Realm-Xamarin, that closes ALL instances.
            // Realm instance auto-closes after this line
        }
    }
