        [Test]
        public void OnBriefAssociationCHanged_ShouldRaiseBriefAssociationChangedEvent()
        {
            // Data
            object resultSender = null;
            AssociationEventArgs resultArgs = null;
            AssociationEventArgs testArgs = new AssociationEventArgs();
            // Setup
            BriefAssociation.BriefAssociationChanged += (sender, args) =>
            {
                resultSender = sender;
                resultArgs = args;
            };
            // Test
            BriefAssociation.OnBriefAssociationChanged(testArgs);
            // Analysis
            Assert.IsNull(resultSender);
            Assert.AreSame(resultArgs, testArgs);
        }
