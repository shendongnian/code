    public  abstract class CreatureBehaviour
    {
        protected abstract void TakeTurn(Action<TurnAction> response);
    }
    public class PlayerControl : CreatureBehaviour
    {
        private Action<TurnAction> responseCallback;
        protected override void TakeTurn(Action<TurnAction> response)
        {
            responseCallback = response;
        }
        internal void TurnByPlayer(Action<TurnAction> response)
        {
            TakeTurn(response);
        }
        // Various UI callbacks that can send something to "responseCallback" when appropriate.
    }
    public abstract class NonPlayerControl : CreatureBehaviour
    {
        protected abstract TurnAction TurnResponse();
        protected override void TakeTurn(Action<TurnAction> response)
        {
            response(TurnResponse());
        }
        internal void TurnByNonPlayer(Action<TurnAction> response)
        {
            TakeTurn(response);
        }
    }
    public sealed class CreatureStearing
    {
        public void Turn(PlayerControl control)
        {
            control.TurnByPlayer((action) => {});
        }
        public void Turn(NonPlayerControl control)
        {
            control.TurnByNonPlayer(action => {});
        }
    }
