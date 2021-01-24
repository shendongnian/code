        /// <summary>
        /// This tests asserts that the Lambda function handles the input and calls the mocked service
        /// </summary>
        [Fact()]
        public void TestKinesisMessage()
        {
            // arrange
            string testMessage = "59d6572f028c52057caf13ff";
            string testStream = "testStream";
            IFileUploadService FileUploadService = new AWSFileUploadService(new Mock<IAmazonS3>().Object);
            // create the custom context and attach above mocked FileUploadService from Lazy factory
            var context = new AWSLambdaFileProcessingServiceContext();
            context.FileUploadService = FileUploadService;
            var lambdaFunction = new AWSLambdaFileProcessingService();
            KinesisEvent kinesisEvent = BuildKinesisTestRequest(testMessage, testStream);
            // act & assert
            try
            {
                lambdaFunction.ProcessKinesisMessageById(kinesisEvent, context);
            }
            catch (Exception e)
            {
                // https://stackoverflow.com/questions/14631923/xunit-net-cannot-find-assert-fail-and-assert-pass-or-equivalent
                Assert.True(false, "Error processing Kinesis Message :" + e.StackTrace);
            }
        }
