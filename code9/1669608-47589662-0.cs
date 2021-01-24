    abstract class BaseController
    {
        virtual GameEvent ReadNextEvent();
    }
    class PlayerController : BaseController
    {
        override GameEvent ReadNextEvent
        {
            return userInterface.ReadNextEvent();
        }
    }
    class NonPlayerController : BaseController
    {
        override GameEvent ReadNextEvent
        {
            artificialIntelligenceEngine.Think();
            return artificialIntelligenceEngine.ReadNextEvent();
        }
    }
    abstract class Character<T> where T : BaseController
    {
        protected T controller;
        abstract ProcessEvents();
    }
    class KnightCharacter<T> : Character<T>
    {
        override ProcessEvents()
        {
            var e = controller.ReadNextEvent();
            switch (e.Action)
            {
                1 : SwingSword(); break;
                2 : LiftShield(); break;
                3 : Yell("None shall pass!"); break;
            }
        }
    }
    class Program 
    {
        void Example()
        {
            var playerKnight = new KnightCharacter<PlayerController>();
            var aiKnight = new KnightCharacter<NonPlayerController>();
        }
    }
