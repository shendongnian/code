    using System;
    struct Index
    {
        public int i;
        public int j;
    }
    public class Node
    {
        public int Value { get; set; }
        public ConsoleColor Color { get; set; }
        public Node(int value, ConsoleColor color = ConsoleColor.White)
        {
            Value = value;
            Color = color;
        }
    }
    public class Maze
    {
        private readonly int _size;
        private Node[,] _maze;
        private Index _currentIndex;
        public Maze(int size)
        {
            _size = size;
            _maze = new Node[_size, _size];
        }
        private void Initialize()
        {
            int k = 1;
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    _maze[i, j] = new Node(k++);
            _maze[0, 0].Color = ConsoleColor.Red;
        }
        private void Print()
        {
            Console.WriteLine("Use the direction keys to move starting at (0,0). I'll not move until you enter a valid direction.\nYou can only move within the maze.\nYou cannot move to a red spot.\n\nPress ESC to quit.\n\n");
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Node node = _maze[i, j];
                    Console.ForegroundColor = node.Color;
                    Console.Write(string.Format("{0:00}",node.Value));
                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void Run()
        {        
            Initialize();
            Print();
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
                ValidateMove(key);
                Console.Clear();
                Print();
            } while (key != ConsoleKey.Escape);
        }
        private void ValidateMove(ConsoleKey key)
        {
            Index tmp = _currentIndex;
            switch (key)
            {
                 case ConsoleKey.UpArrow:
                    --tmp.i;
                    if(Validate(tmp))
                    {
                        _maze[tmp.i, tmp.j].Color = ConsoleColor.Red;
                        _currentIndex = tmp;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    ++tmp.i;
                    if (Validate(tmp))
                    {
                        _maze[tmp.i, tmp.j].Color = ConsoleColor.Red;
                        _currentIndex = tmp;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    --tmp.j;
                    if (Validate(tmp))
                    {
                        _maze[tmp.i, tmp.j].Color = ConsoleColor.Red;
                        _currentIndex = tmp;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    ++tmp.j;
                    if (Validate(tmp))
                    {
                        _maze[tmp.i, tmp.j].Color = ConsoleColor.Red;
                        _currentIndex = tmp;
                    }
                    break;
                default:
                    break;
            }
        }
        private bool Validate(Index index) => (index.i < _size && index.i >= 0 && index.j < _size && index.j >= 0 && _maze[index.i, index.j].Color != ConsoleColor.Red);
        
        public static void Main()
        {
            Maze maze = new Maze(5);
            maze.Run();
        }
    }
