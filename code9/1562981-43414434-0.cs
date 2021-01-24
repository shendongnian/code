    [System.Serializable] // not a mistake, but do you really need this?
    public class GridData  {
        [System.Serializable] 
        public struct rowData{
            public float[] colum;
        }
        // why are you using a struct with only one field in it
        // do you really need a struct?
        // PITFALL: you'll be wondering later on, why the values for numRows and numColums are the same for all instances
        // Why? Because they are static! That means there are *not* instantiated
        public static int numRows =30;
        public static int numColums =20;
        
        // You are initializing your rowData here
        // and again in the constructor. What do you actually want?
        public rowData[] rows = new rowData[numRows]; 
        //
        //Constructor
        public GridData(int x, int y){
            // As mentioned before: 
            // you are assigning instantiating values to static fields
            numRows =y;
            numColums = x;
            // you are *defining* a local variable called rows and initializing it with an array of length numColums
            // After we leave the constructor this get's lost
            rowData[] rows = new rowData[numColums];
        }
    }
   
