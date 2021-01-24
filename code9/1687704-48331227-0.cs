    public interface ISomethingRepository
    {
        IEnumerable<ThingWithDataInIt> GetThings();
        void SaveAsTraining(ThingWithDataInIt thing);
        void SaveAsTest(ThingWithDataInIt thing);
    }
