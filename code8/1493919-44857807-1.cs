    public class ChangeLocationRecountProducts : ICopyCommandMutation
    {
      // these fields should be initialized some way (constructor or getter/setters - you decide
      LocationHeaderDTO locHeader;
      string commandId;
      List<FloatProductDetailsDTO> recountProducts;
      public void Mutate(Command floatCommand)
      {
         var fc = floatCommand as FloatCommand;
         if (fc == null) { /* handle problems here */ }
         fc.Location = locHeader ?? fc.Location;
         fc.CommandId = commandId ?? fc.CommandId;
         fc.RecountProducts = recountProuducts ?? fc.RecountProducts;
      }
    }
