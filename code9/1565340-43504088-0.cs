        public class T{
            public int Field1{get;set;}
            public static T operator +(T c1, T c2) 
           {
               
              return new T{Field1=c1.Field1+c2.Field1;}
           }
    }
