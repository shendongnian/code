      public class MeasurementType
      {
        public int Id { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }
      }
    
      public class Measurement
      {
        public int MeasureTypeId { get; set; }
        public DateTime Created { get; set; }
        public decimal Value { get; set; }
      }
    
      public class MeasurementGenerator
      {
        private List<MeasurementType> MeasurementTypes
        {
          get
          {
            return new List<MeasurementType>
            {
              new MeasurementType() {Id = 1, Parameter1 = 80, Parameter2 = 40},
              new MeasurementType() {Id = 2, Parameter1 = 20, Parameter2 = 30},
              new MeasurementType() {Id = 3, Parameter1 = 10, Parameter2 = 50},
              new MeasurementType() {Id = 4, Parameter1 = 15, Parameter2 = 60},
              //and so on
            };
          }
        }
    
        public List<Measurement> GenerateMeasurements(int type)
        {
          var result = new List<Measurement>();
          for (int i = 0; i < 200; i++)
          {
            var measurementType = MeasurementTypes.First(x => x.Id == type);
            result.Add(new Measurement { MeasureTypeId = type, Created = DateTime.Now.AddDays(i), Value = measurementType.Parameter1 * random.NextDouble() + measurementType.Parameter2 });
          }
          return result;
        }
      }
