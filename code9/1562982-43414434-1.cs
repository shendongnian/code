     public class GridData {
     
        // The concrete data doesn't have to be exposed
        // let's make it private
        private float[] data;
        // let's use properties for this (= less code)
        // get; means it's accessible as defined at the beginning (public)
        // private set; means only the class it self can change these numbers
        public int RowCount { get; private set; }
        public int ColCount { get; private set; }
        // I want to represent the data as a 2D grid so let's make a function
        public float GetCell(int x, int y) {
            // validate requests!
            if( 
                x >= ColCount || x < 0
            ||
                y >= RowCount || y < 0
            ) {
                // don't be shy to throw exceptions!
                // they communicate exceptional circumstances!
             throw new ArgumentOutOfRangeException("Requested cell is not on grid");
            } 
            return data[y * RowCount + x];
        }
        // I want the data to be set from outside
        public float SetCell(int x, int y, float value) {
            // excercise for you!
        }
        public GridData(int cols, int rows) {
            RowCount = rows;
            ColCount = cols;
            this.data = new float[rows * cols];
        }
    }
