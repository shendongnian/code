    // Horrible name, do change it to something more appropriate
    public abstract class BaseBaseRuleMessage
    {
        public IList<int> RulesCompleted { get; set; }
        public IEnumerable<Rule> FilterRules(RuleGroup ruleGroup)
        {
            return ruleGroup.Rules.Where(item =>
                    !RulesCompleted.Any(r => r.Equals(item.Id)));
        }
        public BaseBaseRuleMessage DeserializeToBaseBaseRuleMessage(ClientEventQueueMessage message)
        {
            return (BaseBaseRuleMessage) DeserializeToType(message);
        }
        protected abstract object DeserializeToType(ClientEventQueueMessage message);
        public abstract bool ExecuteRule(Rule rule, object msg);
    }
