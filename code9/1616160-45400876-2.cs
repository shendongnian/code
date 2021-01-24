    public class Turma
    {
        public string Nome { get; set; }
        public int Value { get; set; }
        // Override the equality operation to check for text value only
        public override bool Equals(object obj)
        {
            if (obj is Turma other) // use pattern matching
            {
                return Nome.Equals(other.Nome);
            }
            return false;
        }
    }
