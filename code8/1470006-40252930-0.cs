    using System;
    using System.Collections.Generic;
    namespace DictionaryOfFunctions_StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                Position start = new Position()
                {
                    X = 0,
                    Y = 0,
                    Orientation = CompassDirection.North
                };
                start.Move(CompassDirection.North, 5);
                start.Print(); // X: 0 Y: 5 Orientation: North
                start.Move(CompassDirection.SouthWest, 5);
                start.Print(); // X: -5 Y: 0 Orientation: SouthWest
                start.Move(CompassDirection.East);
                start.Print(); // X: -5 Y: 0 Orientation: East
                start.Move(dX: 5, dY: 1, newDirection: CompassDirection.West);
                start.Print(); // X: 0 Y: 1 Orientation: West
                start.Move(dY: -1, newDirection: CompassDirection.North);
                start.Print(); // X: 0 Y: 0 Orientation: North
                Console.ReadKey();
            }
        }
        public enum CompassDirection
        {
            NorthWest,
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West
        }
        public class Position
        {
            public CompassDirection Orientation { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public void Move(int dX = 0, int dY = 0, CompassDirection? newDirection = null)
            {
                X += dX;
                Y += dY;
                Orientation = newDirection.HasValue ? newDirection.Value : Orientation;
            }
            public void Move(CompassDirection newDirection, int distance = 0)
            {
                var movement = new Dictionary<CompassDirection, Action>
                {
                    {CompassDirection.NorthWest, () => Move(dY: 1, dX: -1)},
                    {CompassDirection.North, () => Move(dY: 1)},
                    {CompassDirection.NorthEast, () => Move(dY: 1, dX: 1)},
                    {CompassDirection.East, () => Move(dX: 1)},
                    {CompassDirection.SouthEast, () => Move(dY: -1, dX: 1)},
                    {CompassDirection.South, () => Move(dY: -1)},
                    {CompassDirection.SouthWest, () => Move(dY: -1, dX: -1)},
                    {CompassDirection.West, () => Move(dX: -1)}
                };
                Orientation = newDirection;
                for (int i=0; i< distance; i++)
                {
                    Action changePosition = movement[Orientation];
                    changePosition();
                }
            }
        }
        public static class ExtensionMethods
        {
            public static void Print(this Position pos)
            {
                string display = $"X: {pos.X} Y: {pos.Y} Orientation: {pos.Orientation}";
                Console.WriteLine(display);
            }
        }
    }
