        public static void WillBeRaised(Action<Action> attach, Action act)
        {
            bool called = false;
            attach(() => called = true);
            act();
            Assert.IsTrue(called);
        }
