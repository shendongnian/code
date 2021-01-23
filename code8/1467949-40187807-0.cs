    [Test]
    public void TestProcessing() {
        var feedData = Substitute.For<IFeedData>();
        feedData.GetFeedData("HHH").Returns(new FeedEntity(...)); 
        // Configure substitute to return a real FeedEntity. 
        // Alternatively, return a substitute IFeedEntity as described above
        var subject = new FeedProcessor(feedData);
        subject.ProcessFeedData();
        // assert correct processing  
    }
