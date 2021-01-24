        [TestMethod]
        public void SetTreatmentInProgressTest()
        {
            var inProgress = true;
            TreatmentStatus resultStatus = null;
            _mockEventAggregator.Setup(x => x.Publish(It.IsAny<TreatmentStatus>(), Execute.OnUIThread))
                                .Callback<object,Action<Action>>((t,s) => resultStatus = (TreatmentStatus)t);
            _treatmentRoomModel.SetTreatmentInProgress(inProgress);
            Assert.IsNotNull(resultStatus);
            Assert.IsTrue(resultStatus.IsInProgress);
            Assert.IsTrue(_treatmentRoomModel.IsTreatmentInProgress);
        }
