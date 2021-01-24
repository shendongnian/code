        public class Club : IClub, IComparable<Club> , IComparable
        {
          ...
          public int CompareTo(object obj)
          {
	        return CompareTo(obj as Club);
          }
        }
