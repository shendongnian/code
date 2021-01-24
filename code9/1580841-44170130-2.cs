    public static void SetValueWithVerification(IStructuralObject so, DataEntityProperty property, object newValue)
    {
        if (so.VerifierEngine != null && so.VerifierEngine.Enabled && so.EntityGroup.VerificationEnabled)
        {
            if ((property.MemberMetadata.VerifierSetterOptions & VerifierSetterOptions.BeforeSet) > 0)
            {
                so.ValidatePropertyBeforeSet(property, newValue);
            }
            so.SetValueWithChangeNotification(property, newValue);
            if ((property.MemberMetadata.VerifierSetterOptions & VerifierSetterOptions.AfterSet) > 0)
            {
                so.ValidatePropertyAfterSet(property, newValue);
            }
        }
        else
        {
            so.SetValueWithChangeNotification(property, newValue);
        }
    }
