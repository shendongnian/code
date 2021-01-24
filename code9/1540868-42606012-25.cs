     internal class MyTable : IMyTable<List<object>>
     {
         public string Surname { get; set; }
         public int Addresss { get; set; }
         string IMyTable<List<object>>.Name{ get; set; }
         List<object> IMyTable<List<object>>.GetAll()
         {
             return new List<object>() { ((IMyTable<List<object>>)this).Name, Surname, Addresss };
         }
     }
