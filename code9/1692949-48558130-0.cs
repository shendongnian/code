    public override TypeConverter Converter {
         get {
            return TypeDescriptor.GetConverter(this.objs[index]);
         }
      }
