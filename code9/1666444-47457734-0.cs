    public class CommanditairesEqualityComparer: IEqualityComparer<Commanditaires>
        {
            
            public bool Equals(Commanditaires first, Commanditaires second)
            {
                if (first== null && first== null)
                    return true;
    
                return first.Id == second.Id
                    && first.Level == second.Level;
            }    
            
            public int GetHashCode(Commanditaires model)
            {
                return model.Id.GetHashCode() + model.Level.GetHashCode();
            }
        }
