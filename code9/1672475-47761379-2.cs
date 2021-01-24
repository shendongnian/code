    public class Game<TScoreBoard> where TScoreBoard : IScoreBoard
    {
        public TScoreBoard Scoreboard { get; }
    }
    public class SomeScoreboardParser : IDtoParser<SomeScoreboard>
    {
        public IDto Parse(SomeScoreboard scoreBoard)
        {
            //Do your parsing here
            return new ScoreboardDto();
        }
    }    
    public interface IDtoParser<TScoreBoard>
        where TScoreBoard : IScoreBoard
    {
        IDto Parse(TScoreBoard scoreBoard);
    }
    public class DtoParserFactory
    {
        public IDtoParser<TScoreBoard> Get<TScoreBoard>() where TScoreBoard : IScoreBoard
        {
            var tScoreboard = typeof(TScoreBoard);            
            //Use a IoC container to get the instance here.
            IDtoParser<TScoreBoard> parser = null;            
            return parser;
        }
    }
    public class SomeScoreboard : IScoreBoard
    {
    }
    public interface IScoreBoard
    {
    }
    public class ScoreboardDto : IDto
    {
    }
    public interface IDto
    {
    }
