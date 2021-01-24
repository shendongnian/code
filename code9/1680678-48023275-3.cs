    using (Entities context = new Entities())
    {
        log.Info("Database connected successfully");
        log.Info("GET_AMBIGUITYANALYSIS_RESULT procedure called");
        var result = JsonConvert.DeserializeObject<Ambiguityanalysis>(context.GET_AMBIGUITYANALYSIS_RESULT());
        return result;
    }
    public class StoryData
    {
        public int UserStoryId { get; set; }
    }
    public class Ambiguityanalysis
    {
        public List<StoryData> StoryData { get; set; }
    }
