         // class
         public class Compra
          {
            public int ID { get; set; }
            List<Combo> compras = new List<Combo>();
          }
         public class Combo
          {
            public int id{ get; set; } 
            public string Name { get; set; }
          } 
    
        // view
        @model Compra
    
          <ol>
            @foreach (var item in Model.compras)
             {
              <li>
                  @item.Name
              </li>
             }
         </ol>
