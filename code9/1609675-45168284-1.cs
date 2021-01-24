        protected override void TakeTurn(Action<TurnAction> response)
        {
            base.TakeTurn(response);
        }
    }
    public class SomeTest2 : NonPlayerControl
    {
        protected override TurnAction TurnResponse()
        {
            throw new NotImplementedException();
        }
        protected override void TakeTurn(Action<TurnAction> response)
        {
            base.TakeTurn(response);
        }
    }
    public class SomeTest3 : CreatureBehaviour
    {
        protected override void TakeTurn(Action<TurnAction> response)
        {
            throw new NotImplementedException();
        }
    }
    ....
    var t1 = new SomeTest1();
            var t2 = new SomeTest2();
            var t3 = new SomeTest3();
            var creatureStearing = new CreatureStearing();
            creatureStearing.Turn(t1);
            creatureStearing.Turn(t2);
            creatureStearing.Turn(t3); // 'Cannot resolve method 'compile error here
