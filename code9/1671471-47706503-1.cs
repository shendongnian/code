    public class MapsToClaseB : MapsToAttribute
    {
        public MapsToClaseB() : base(typeof(ClaseB)) { }
        public void ConfigureMapping(IMappingExpression<ClaseA, ClaseB> mappingExpression)
        {
            mappingExpression.AfterMap(
                (a, b) => b.objetoB_inside = new ClaseB_inside{texto_inside = a.texto});
        }
    }
