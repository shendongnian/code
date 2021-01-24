    public class Input
    {
        public int VariableA { get; set; }
        public int VariableB { get; set; }
        public List<Sancti> Sancts { get; set; }
        public override bool Equals(object obj)
        {
            Input otherInput = obj as Input;
            if (ReferenceEquals(otherInput, null))
                return false;
            if ((this.VariableA == otherInput.VariableA) && 
                (this.VariableB == otherInput.VariableB) && 
                this.Sancts.OrderBy(x=>x.Symbol).SequenceEqual(otherInput.Sancts.OrderBy(x => x.Symbol)))
                return true;
            else
            {
                return false;
            }
                
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + VariableA.GetHashCode();
                hash = hash * 23 + VariableB.GetHashCode();
                hash = hash * 23 + Sancts.GetHashCode();
                return hash;
            }
        }
    }
    public class Sancti
    {
        public string Symbol { get; set; }
        public double Percentage { get; set; }
        public override bool Equals(object obj)
        {
            Sancti otherInput = obj as Sancti;
            if (ReferenceEquals(otherInput, null))
                return false;
            if ((this.Symbol == otherInput.Symbol) && (this.Percentage == otherInput.Percentage) )
                return true;
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + Symbol.GetHashCode();
                hash = hash * 23 + Percentage.GetHashCode();
                return hash;
            }
        }
    }
