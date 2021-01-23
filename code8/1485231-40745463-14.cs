    class TakeDamageHamster<T> where T : IHamster
    {
        public TakeDamageHamster(IHamster Hamster)
        {
            Console.WriteLine(Hamster.Some);
        }
    }
