     class Program
        {
            static void Main(string[] args)
            {
                var smallList = new List<MyStruct>() { new MyStruct
              {
                  Field1="1f",
                   Field2 ="2f"
              },
              new MyStruct
              {
                  Field1="2f",
                   Field2 ="22f"
              }};
                var bigList = new List<MyStruct>() { new MyStruct
              {
                  Field1="1f",
                   Field2 ="2f"
              },
              new MyStruct
              {
                  Field1="3 f",
                   Field2 ="22f"
              },new MyStruct
              {
                  Field1="4f",
                   Field2 ="22f"
              } 
                };
                  //find the difference 
                var diffList = smallList.Except(bigList);  
                 
            }
            public struct MyStruct:IEquatable<MyStruct>
            {
                public string Field1;
                public string Field2;
    
                public bool Equals(MyStruct other)
                {
                    if (this.Field1==other.Field1 && this.Field2==other.Field2)
                    {
                        return true;   
                    }
                    return false;   
                }
                public override int GetHashCode()
                {
                    return Field1.GetHashCode() & Field2.GetHashCode();
                }
           public override bool Equals(object obj)
            {
                return  this.Equals(obj);
            }
            }
        }
