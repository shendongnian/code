    public class Encuesta
    {
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
    public class Pregunta
    {
        public Tema Tema { get; set; }
    }
    public class Tema
    {
        // not actually needed but for clarification
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
