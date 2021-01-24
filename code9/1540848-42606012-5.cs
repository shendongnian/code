     internal class MyTable : IMyTable<List<string>>
     {
         public string Surname { get; set; }
         public string Addresss { get; set; }
         string IMyTable<List<string>>.Name{ get; set; }
         List<string> IMyTable<List<string>>.GetAll()
         {
             return new List<string>() { ((IMyTable<List<string>>)this).Name, Surname, Addresss };
         }
     }
