    public class PairingComboBox : ComboBox
    {
        private List<Type> _availableMethod = DerivedTypes.FindAllDerivedTypes<PairingMethod>();
        
        public PairingComboBox()
        {
            DataSource = DerivedTypes.FindAllDerivedTypes<PairingMethod>();
            DisplayMember = "Name";
        }
    }
    public static IPairingMethod CreateInstanceBinder
                   (string pairingMethodName, ICollection<IPlayer> players)
    {
             var t = Type.GetType(pairingMethodName + ",Pairings");
            return (PairingMethod)Activator.CreateInstance(t, players);
     }
