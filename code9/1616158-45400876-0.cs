    public class Turma
    {
        public string Nome { get; set; }
        public int Value { get; set; }
        // Override the equality operation to check for text value only
        public override bool Equals(object obj)
        {
            var other = obj as Turma;
            if (other!=null)
            {
                return Nome.Equals(other.Nome);
            }
            return false;
        }
    }
