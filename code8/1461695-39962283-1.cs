    public abstract class BaseRuleMessage<T> : BaseBaseRuleMessage
        where T : BaseRuleMessage<T>
    {
        public abstract Func<T, bool> CompileRule(Rule r, T msg);
        protected override object DeserializeToType(ClientEventQueueMessage message)
        {
            return JsonConvert.DeserializeObject(message.Payload, typeof(T));
        }
        protected BaseRuleMessage()
        {
            RulesCompleted = new List<int>();
        }
        public override bool ExecuteRule(Rule rule, object msg)
        {
            var message = (T) msg;
            if (message == null)
            {
                throw new InvalidOperationException();
            }
            return CompileRule(rule, message).Invoke(message);
        }
    }
