        [Test]
        public void Libary1_Methode1_struct()
        {
            Speed speed = new Speed(new CommInterface());
            int response = 99;
            Mock<ILibary> mockLibary = new Mock< ILibary>();
            mockLibary.Setup(
                r =>
                    r. Methode1(It.IsAny<ushort>(), It.IsAny<short>(), It.IsAny<short>(), It.IsAny<RealLibary.Struct1>()))
                .Callback<ushort, short, short, RealLibary.Struct1>(
                    (hndl, a, b, dbaxis) =>
                    {
                        dbaxis.data = new[] {0, 1, 2, 3};
                        dbaxis.dummy = 0;
                        dbaxis.type = 0;
                    });
            RealLibary.Struct1 struct1 = new RealLibary.Struct1();
            List<object> list = new List<object>();
            list.Add(new short());
            list.Add(struct1);
            list.Add(new short());
            list.Add(new short());
            speed.Methode1(0, mockLibary.Object, list, out response);
            Assert.AreEqual(4, struct1.data.Length);
        }
