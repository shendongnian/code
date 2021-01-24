    public abstract class Rule<TDmModel, TMiddle, TDb> : IRule<TDmModel, TDb>
        where TDmModel : IDmModel
        where TDb : IDbModel
    public class RuleA : Rule<DmModel, Middle, DbMode>
    public class RuleB : RuleA
    ...
    var ruleB = (IRule<IDmModel, IDbModel>)new RuleB();
