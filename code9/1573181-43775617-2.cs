        public class BetaModel1 : AlphaModel, IBetaModel
        {
            public string PropertyBeta { get; set; }
            public string MethodBeta()
            {
                return "This is Beta?";
            }
        }
