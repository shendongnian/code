    namespace UnitTestProject1
    {
    [TestFixture]
    [Parallelizable]
    [Category("ParallelTest2")]
    public class ParallelTestingExampleV2_A : BaseTest
    {
        [Test]
        public void TestMethod1()
        {
            Trace.WriteLine($"Test1 has user {AvailableUser.UserName}");
            Thread.Sleep(50000);
            Trace.WriteLine($"Test1 sleeping for 50000ms so one user is Connected.");
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("ParallelTest2")]
    public class ParallelTestingExampleV2_B : BaseTest
    {
        [Test]
        public void TestMethod2()
        {
            Trace.WriteLine($"Test2 has user {AvailableUser.UserName}");
        }
    }
    [TestFixture]
    [Parallelizable]
    [Category("ParallelTest2")]
    public class ParallelTestingExampleV2_C : BaseTest
    {
        [Test]
        public void TestMethod3()
        {
            Trace.WriteLine($"Test3 has user {AvailableUser.UserName}");
        }
    }
    [SetUpFixture]
    public class TestFixtureForTestsNamespace
    {
        public static ListOfUsers ListOfAllPossibleUsers;
        [OneTimeSetUp]
        public void RunBeforeAllTestsAreExecutedInSomeNamespace()
        {
            GetPoolOfUsers();
        }
        private static void GetPoolOfUsers()
        {
            var oneUser = new User
            {
                UserName = "a",
                Password = "a"
            };
            var secondUser = new User
            {
                UserName = "b",
                Password = "b"
            };
            ListOfAllPossibleUsers = new ListOfUsers() { oneUser, secondUser };
        }
    }
    public class BaseTest
    {
        protected User AvailableUser;
        [SetUp]
        public void SetupForEveryTestMethod()
        {
            AvailableUser = TestFixtureForTestsNamespace.ListOfAllPossibleUsers.GetAvailableUser();
        }
        [TearDown]
        public void TearDownForEveryTestMethod()
        {
            TestFixtureForTestsNamespace.ListOfAllPossibleUsers.ReleaseUser(AvailableUser);
        }
    }
    public class User
    {
        internal string UserName = "";
        internal string Password = "";
        internal bool Connected;
    }
    public class ListOfUsers : List<User>
    {
        internal void ReleaseUser(User userToBeReleased)
        {
            lock (this) { userToBeReleased.Connected = false; }
        }
        internal User GetAvailableUser()
        {
            User user = null;
            while (user == null)
            {
                lock (this)
                {
                    for (int i = 0; i < Count && user == null; i++)
                    {
                        if (!this[i].Connected)
                            user = this[i];
                    }
                    if (user != null)
                        user.Connected = true;
                }
                Thread.Sleep(200);
            }
            return user;
        }
    }
}
