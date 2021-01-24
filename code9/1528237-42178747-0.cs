    class Program
    {
        class Cell
        {
            public string Id { get; set; }
            public int Node1 { get; set; }
            public int Node2 { get; set; }
            public int Min { get { return Math.Min( Node1, Node2 ); } }
            public Cell( string name, int node1, int node2 )
            {
                Id = name;
                Node1 = node1;
                Node2 = node2;
            }
            public override string ToString()
            {
                return Id + "(" + Node1.ToString() + "," + Node2.ToString() + ")";
            }
        }
        static void Main( string[] args )
        {
            var A = new Cell( "A", 4, 9 );
            var B = new Cell( "B", 6, 1 );
            var C = new Cell( "C", 1, 3 );
            var D = new Cell( "D", 3, 10 );
            var E = new Cell( "E", 7, 2 );
            var F = new Cell( "F", 4, 2 );
            var G = new Cell( "G", 9, 8 );
            var H = new Cell( "H", 10, 5 );
            var I = new Cell( "I", 7, 5 );
            var J = new Cell( "J", 6, 8 );
            var cells = new List<Cell>() { A, B, C, D, E, F, G, H, I, J };
            // A dictionary to store the cells corresponding to each node values
            Dictionary<int, List<Cell>> dict = new Dictionary<int, List<Cell>>();
            // Add all the cells to the dictionary
            foreach ( var cell in cells )
                AddCell( dict, cell );
            // Start with arbitrary first cell and remove it from the dictionary
            var currentCell = GetCell( dict, A.Node1 );
            RemoveCell( dict, currentCell );
            // The result is a list of cells initialized with the first cell
            var result = new List<Cell>() { currentCell };
            // Calculation loop
            bool doContinue = true;
            while ( doContinue )
            {
                // Tries to get a next cell from the node1 of current cell...
                var nextCell = GetCell( dict, currentCell.Node1 );
                // ... or if not found, tries to get it from node2
                if ( nextCell == null )
                    nextCell = GetCell( dict, currentCell.Node2 );
                if ( nextCell == null )
                // If not found, we stop
                {
                    doContinue = false;
                }
                else
                // If found
                {
                    // Add the next cell to the result
                    result.Add( nextCell );
                    // Remove the cell
                    RemoveCell( dict, nextCell );
                }
                // The next cell becomes the current cell
                currentCell = nextCell;
            }
        }
        // Adding a cell puts the cell against its two nodes values
        static void AddCell( Dictionary<int, List<Cell>> dict, Cell cell )
        {
            List<Cell> cells = null;
            if ( dict.TryGetValue( cell.Node1, out cells ) == false )
            {
                cells = new List<Cell>();
                dict[cell.Node1] = cells;
            }
            cells.Add( cell );
            if ( dict.TryGetValue( cell.Node2, out cells ) == false )
            {
                cells = new List<Cell>();
                dict[cell.Node2] = cells;
            }
            cells.Add( cell );
        }
        // Gets a cell from a node value
        static Cell GetCell( Dictionary<int, List<Cell>> dict, int node )
        {
            var cell = null as Cell;
            var cells = dict[node];
            if ( cells.Count > 0 )
                cell = cells.First();
            return cell;
        }
        // Removes a cell from the dictionary for both node1 and node2 entries.
        static void RemoveCell( Dictionary<int, List<Cell>> dict, Cell cell )
        {
            dict[cell.Node1].Remove( cell );
            dict[cell.Node2].Remove( cell );
        }
    }
