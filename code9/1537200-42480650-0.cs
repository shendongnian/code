    public abstract class ComponentData : BaseData
    {
        public Collection<Array> ArraysRegister { get; private set; }
        
        public int[] Ints;
        
        public float[] Floats;
        
        public ComponentData()
        {
          ArraysRegister = new Collection<Array>();
          ArraysRegister.Add(this.Ints);
          ArraysRegister.Add(this.Floats);
          /* whatever you need in base class*/
        }
    
        protected void Copy(int source, int destination)
        {
          for (int i = 0; i < ArraysRegister.Count; i++)
          {
            ArraysRegister[i][destination] = ArraysRegister[i][source];
          }
        }
        /* All the other methods */
    }
    
    public class SomeComponentData : ComponentData
    {
        // In child class you only have to define property...
        public decimal[] Decimals;
        
        public SomeComponentData()
        {
          // ... and add it to Register
          ArraysRegister.Add(this.Decimals);
        }
        // And no need to modify all the base methods
    }
