    public class ProjectionResult
    {
        public string nombre { get; set; }
        public Nullable<int> horasPorSemana { get; set; }
        public Nullable<int> nivel { get; set; }
        public Nullable<int> unidades { get; set; }
        public IEnumerable<Nullable<double>> evaluacion_calificacion { get; set; }
    }
