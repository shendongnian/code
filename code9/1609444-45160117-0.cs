    var listOfEntities = new List<CustomEntity>
    {
          new CustomEntity {Id = 1, Name = "Name1", Value = "Value1"},
          new CustomEntity {Id = 2, Name = "Name2", Value = "Value2"},
          new CustomEntity {Id = 3, Name = "Name3", Value = "Value3"},
          new CustomEntity {Id = 4, Name = "Name4", Value = "Value4"},
    };
    dataGridView1.DataSource = listOfEntities;
    public class CustomEntity
    {
        public int Id { get; set; }
        [DisplayName("Custom name header")]
        public string Name { get; set; }
        [DisplayName("Custom name value")]
        public string Value { get; set; }
    }
