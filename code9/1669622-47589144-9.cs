    public static class GetStringFromEnum
    {
      public static string ToFriendlyString(this MedicineType me)
      {
        return  ((int)me).ToString("D2");
      }
      public static string ToFriendlyString(this OtherEnum oe)
      {
        return  ((int)oe).ToString("D2");
      }
    }
