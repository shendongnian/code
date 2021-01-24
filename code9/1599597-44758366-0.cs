    [Test]
    public void should_raise_event()
    {
        BriefAssociation.BriefAssociationChangedEvent += BriefAssociationChanged;
        bool result = BriefAssociation.HasListener(null);
        Assert.True(result);
    }
    public void BriefAssociationChanged(Object obj, AssociationEventArgs associationEventArgs)
    { }
