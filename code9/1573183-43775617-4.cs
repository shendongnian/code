        public void DoStuffWith(IBetaModel betaModel)
        {
            betaModel.PropertyBeta = "WOW, it works";
        }
        public void DoStuff()
        {
            var betaModel1 = new BetaModel1();
            var betaModel2 = new BetaModel2();
            AlphaModel betaModel1_ = new BetaModel1();
            //AlphaModel betaModel2_ = new BetaModel2(); //won't compile
            betaModel1.PropertyAlpha = "Test";
            //betaModel2.PropertyAlpha = "Test"; //won't compile
            DoStuffWith(betaModel1); //great!!!
            DoStuffWith(betaModel2); //great too!!!
        }
