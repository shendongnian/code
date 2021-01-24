    using System;
    
    public class Name { }
    public class SpadesName : Name { }
    
    public class Color { }
    public class BlackColor : Color { }
    
    public class Rank { }
    public class AceRank : Rank { }
    
    public interface IPlayingCard<out TName, out TColor, out TRank>
    //where TName : Name, new()
    //where TColor : Color, new()
    //where TRank : Rank, new()
    { }
    
    public class PlayingCard<TName, TColor, TRank> : IPlayingCard<Name, Color, Rank> 
        where TName : Name, new()
        where TColor : Color, new()
        where TRank : Rank, new()
    { }
    
    
    public class DeckOfCards
    {
        public IPlayingCard<Name, Color, Rank>[] cards;
    
        public DeckOfCards() { }
    
        public void BuildDeckOfCards()
        {
            this.cards = new IPlayingCard<Name, Color, Rank>[52];
    
            Type[] fpcTypeArgs = { typeof(SpadesName), typeof(BlackColor), typeof(AceRank) };
            Type fpcType = typeof(PlayingCard<,,>);
            Type constructable = fpcType.MakeGenericType(fpcTypeArgs);
    
            // the problem is here.. this will not cast.
            // how do I create an object using reflection and cast it to the generic base type PlayingCard<Name, Color, Rank>
            var fpc = Activator.CreateInstance(constructable);
            this.cards[0] = (IPlayingCard<Name, Color, Rank>)fpc;
        }
    }
