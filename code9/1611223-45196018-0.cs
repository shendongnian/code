    public class Callbacks
    {
        public static readonly Func<IState, Banknote, Type> OnBanckoneInserted = 
          (s, b) => s.BanknoteInserted(b);
        // and so on, for each method
        public Func<IState, Banknote, Type> BanknoteInserted { get; set; }
        // and so on, for each method
    }
