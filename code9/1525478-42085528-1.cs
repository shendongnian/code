    public class Derived : Base
    {
        public override bool Equals(object obj)
        {
            if(!base.Equals( obj ) )
              return false; 
            Derived o = obj as Derived;
            if( o == null ) return false;
            return y_value == o.y_value;
        }
    }
