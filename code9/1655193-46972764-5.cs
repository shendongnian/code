    // model represents exactly database table:
    class Model
    {
        public string Description {get; set;}
        public string Length {get; set;}
    }
    class SpanishModel
    {
        public string Description {get; set;}
        public decimal Length {get; set;}
    }
    // extension functions of model:
    static class ModelExtensions
    {
        private static IFormatProvider spanishCulture = CultureInfo.CreateSpecificCulture("es-ES");
        public static SpanishModel AsSpanishModel(this Model model)
        {
            return new SpanishModel()
            {
                Description = model.Description,
                Length = Decimal.Parse(model.Length, spanishCulture);
            }
        }
        public static Model AsModel(this SpanishModel model) 
        {
             return new Model()
             {
                 description = model.Description,
                 Length = model.Length.ToString(spanishCulture),
             };
        }
        
        public static IEnumerable<SpanishModel> AsSpanishModels(this IEnumerable<Model> models)
        {
             return models.Select(model => model.AsSpanishModel();
        }
         public static IEnumerable<SpanishModel> AsModels(this IEnumerable<SpanishModel> models)
        {
             return models.Select(model => model.AsModel();
        }
    }
