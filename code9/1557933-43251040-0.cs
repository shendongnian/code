    Controller:                 
                    var model = new SchemaModel
                    {
                        Schema = db.AS_AVTAL_SCHEMA.Where(A => A.AS_AH_LNR == schemaID).ToList(),
                        AS_SC_VECKA = (from AS_AVTAL_SCHEMA in db.AS_AVTAL_SCHEMA
                                       where AS_AVTAL_SCHEMA.AS_AH_LNR == (schemaID)
                                       select AS_AVTAL_SCHEMA.AS_SC_VECKA
                                  ).Distinct().ToList()
                };
                    
    Viewmodel:
        public class SchemaModel
        {
            public List<int?> AS_SC_VECKA { get; set; }
        }
