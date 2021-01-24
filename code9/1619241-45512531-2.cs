    class Program
    {
        static void Main(string[] args)
        {
            var key1 = new DoorKey("1234");
            var key2 = new DoorKey("4321");
            var rubberChicken = new RubberChicken();
            var door = new Door();
            var world = new World();
            Debug.Assert(!world.IsDropTarget(door, rubberChicken));
            Debug.Assert(world.IsDropTarget(door, key1));
            world.ActOn(door, key2);
            world.ActOn(door, key1);
            Console.ReadLine();
        }
    }
