        public interface IHandler
        {
            void Handle(string value);
        }
        public abstract class CellRequestTemplate : IHandler
        {
            protected readonly IHandler _next;
            protected CellRequestTemplate(IHandler next)
            {
                _next = next ?? throw new ArgumentNullException(nameof(next));
            }
            public abstract void Handle(string value);
        }
        public sealed class FirtsRuleForCell : CellRequestTemplate
        {
            public FirtsRuleForCell(IHandler next) : base(value, next) { }
            public override void Handle(string value)
            {
                if(value is number)
                {
                    _next.Handle(value);
                }
                else
                {
                    //print "Wrong cell value";
                }
            }
        }
        public sealed class SecondRuleForCell : CellRequestTemplate
        {
            public SecondRuleForCell(IHandler next) : base(value, next) { }
            public override void Handle(string value)
            {
                //if some validation
                //do something
                //else 
                //
                _next.Handle(value);
            }
        }
        public sealed class EndOfChain : IHandler
        {
            public void Handle(string value)
            {
                throw new InvalidOperationException("End of Chaing, cant handle");
            }
        }
        public interface IHandleCellFactory
        {
            IHandler CreateHandler();
        }
        public sealed class Form1GridHandler : IHandleCellFactory
        {
            public IHandler CreateHandler()
            {
                return new FirtsRuleForCell(new SecondRuleForCell(new EndOfChain()));
            }
        }
        public sealed class Form2GridHandler : IHandleCellFactory
        {
            public IHandler CreateHandler()
            {
                return new SecondRuleForCell(new EndOfChain());
            }
        }
        public abstract class ClientCode
        {
            private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
            {
                // Below I demonstrate pseudo code for brevity
                var valueToHandle = string.Empty; //cell.name.value;
                var handler = new Form1GridHandler().CreateHandler();
                handler.Handle(valueToHandle);
                //continue with Execution code
            }
        }
