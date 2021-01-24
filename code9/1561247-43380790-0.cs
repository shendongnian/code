    public class NullEntityVerifier : PropertyValueVerifier
    {
       public NullEntityVerifier(
           Type entityType,
           string propertyName,
           string displayName = null)
          : base(new PropertyValueVerifierArgs(entityType, propertyName, true, displayName)) { }
       public NullEntityVerifier(PropertyValueVerifierArgs verifierArgs)
          : base(verifierArgs) { }
       protected override VerifierResult VerifyValue(object itemToVerify, object valueToVerify, TriggerContext triggerContext, VerifierContext verifierContext)
       {
           var entity = valueToVerify as Entity;
           var msg = $"{this.ApplicableType.Name}.{this.DisplayName} is required.";
           return new VerifierResult(entity != null && !entity.EntityAspect.IsNullEntity, msg);
       }
    }
