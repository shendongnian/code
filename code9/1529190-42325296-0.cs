    public class UnitTest1
        {
            [TestMethod]
            public void TestDetermineWinner_B_IsTheWinner()
            {
                var P1 = Isolate.Fake.Instance<Player>();
                var P2 = Isolate.Fake.Instance<Player>();
    
                Isolate.WhenCalled(() => P1.Age).WillReturn(0);
                Isolate.WhenCalled(() => P2.Age).WillReturn(1);
    
                var result = new ClassUnderTest().DetermineWinner(P1, P2);
    
                Assert.AreEqual(P2, result);
            }
        }
        public class ClassUnderTest
        {
            public Player DetermineWinner(Player a, Player b)
            {
                if (a.Age > b.Age) { return a; }
                return b;
            ///few more conditions checking properties of both players
            }
        }
        public class Player
        {
            public Player(DbConnection c, world w, DateTime logTime)
            { } //not easy to mock...
    
            public int Age { get; internal set; }
        }
