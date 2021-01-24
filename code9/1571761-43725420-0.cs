    public class ProtoArray<T>
    {
        public ProtoArray(T[] array)
        {
            this.Data=array;
            this.Dimensions=new int[array.Length];
        }
        public ProtoArray(T[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            this.Data=new T[n*m];
            for(int i = 0; i<n; i++)
            {
                for(int j = 0; j<m; j++)
                {
                    // Row Major
                    Data[i*m+j]=array[i, j];
                    // For Column Major use Data[i+j*n]=array[i, j];
                }
            }
            this.Dimensions=new[] { n, m };
        }
        public int[] Dimensions { get; set; }
        public T[] Data { get; set; }
        public T[,] ToArray2()
        {
            if(Dimensions.Length==2)
            {
                int n = Dimensions[0], m = Dimensions[1];
                T[,] array = new T[n, m];
                for(int i = 0; i<n; i++)
                {
                    for(int j = 0; j<m; j++)
                    {
                        array[i, j]=Data[i*m+j];
                    }
                }
                return array;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
    public class Tile
    {
        public int x;
        public int y;
        // ...
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tile[,] map = new Tile[16, 4];
            ProtoArray<Tile> array = new ProtoArray<Tile>(map);
            //serialize array
            //
            // de-serialize array
            Tile[,] serialized_map = array.ToArray2();
        }
    }
