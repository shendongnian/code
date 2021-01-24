    public class DtoParserFactory
    {
        private Dictionary<Type, IDtoParser> _parsers = new Dictionary<Type, IDtoParser>();
        public void Register(Type type, IDtoParser parser)
        {
            _parsers.Add(type, parser);
        }
        public IDtoParser GetParser(IScoreBoard scoreBoard)
        {
            var type = scoreBoard.GetType();
            var parser = _parsers[type];
            return parser;
        }
    }
    public class SomeScoreboardParser : BaseScoreBoardParser<SomeScoreboard, ScoreboardDto>
    {
        public override ScoreboardDto Parse(SomeScoreboard scoreBoard)
        {
            return new ScoreboardDto();
        }
    }
    public abstract class BaseScoreBoardParser<TScoreBoard, TDto> : IDtoParser<TScoreBoard, TDto> where TScoreBoard : IScoreBoard where TDto: IDto
    {
        public abstract TDto Parse(TScoreBoard scoreBoard);
        public IDto Parse(IScoreBoard scoreBoard)
        {
            return Parse((TScoreBoard)scoreBoard);
        }
    }
    public interface IDtoParser<TScoreBoard, TDto> : IDtoParser
        where TScoreBoard : IScoreBoard
        where TDto : IDto
    {
        TDto Parse(TScoreBoard scoreBoard);
    }
    public interface IDtoParser
    {
        IDto Parse(IScoreBoard scoreBoard);
    }
    
    public class ScoreboardDto : IDto
    {
    }
    public interface IDto
    {
    }
