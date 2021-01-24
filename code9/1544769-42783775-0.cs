    using System.Collections.Generic;
    using System;
    using System.Linq;
    using UnityEngine;
    
    public interface IGrid<T> where T : GridCell
    {
        Dictionary<GridCoordinate, T> grid { get; set; }
    
        /// <summary>
        /// populates the grid with cell type t + a shiny callback to handle each cell after instantiation
        /// </summary>
        void Generate(T t, System.Action<int, int, T> callback);
    
        /// <summary>
        /// returns the cell at given grid coordinate
        /// </summary>
        T Fetch(GridCoordinate coord);
    }
    
    public partial class RectGrid2D<T> : MonoBehaviour, IGrid<T>, IGridPositionRule<T> where T : GridCell
    {
        public int rows;
        public int columns;
    
       public Dictionary<GridCoordinate, T> grid { get; set; }
    
        public void Generate(T t, Action<int, int, T> callback)
        {
            grid = new Dictionary<GridCoordinate, T>();
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    var coord = new GridCoordinate(x, y);
                    var cell = GameObject.Instantiate(t);
                    grid.Add(coord, cell);
    
                    PositionCell(cell, x, y);
    
                    System.Action<int, int, T> _callback = callback;
                    if (_callback != null)
                    {
                        _callback(x, y, cell);
                    }
                }
            }
        }
    
        /// <summary>
        /// returns the cell at given grid coordinate
        /// </summary>
        public T Fetch(GridCoordinate coord)
        {
            return grid[coord];
        }
    
        /// <summary>
        /// Returns a grid cell given T
        /// </summary>
        public GridCoordinate CoordinateFromCell(T cell)
        {
            return grid.FirstOrDefault(x => x.Value == cell).Key;
        }
    
        public void PositionCell(T cell, int x, int y)
        {
            //define your position rule
        }
    }
    
    public struct GridCoordinate 
    {
        public int x;
        public int y;
    
        public GridCoordinate (int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }
    
    public class GridCell : MonoBehaviour 
    {
    }
    
    public interface IGridPositionRule <T> where T : GridCell
    {
        void PositionCell(T cell, int x, int y);
    }
    
    public partial class GridExample : MonoBehaviour
    {
        [SerializeField] private GridCell gridCell; // prefab
    
        private void Awake()
        {
            RectGrid2D<GridCell> grid = GetComponent<RectGrid2D<GridCell>>();
            grid.Generate(gridCell, (x, y, cell) =>
            {
                // do something with grid cell
            });
        }
    }
