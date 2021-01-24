     [TestMethod()]
            public void ParseParameterTest()
            {
                Algo.Alpha.AlphaCalculator calc = new Alpha.AlphaCalculator();
                string test_input = File.ReadAllText(@"..\..\..\case\Alpha Example Input.json");
                string expected = File.ReadAllText(@"..\..\..\case\Alpha Example DOutput.json");
                string res = calc.AlphaCalcParam(test_input);
           
                Assert.AreEqual(expected, res);
            }
