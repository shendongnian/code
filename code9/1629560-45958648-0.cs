    [Test]
        public async Task TestRequestHeaderConatainsRequestingSystem()
        {
            // Arrange
            var restRepository = new Mock<IRestRepository<LifeBondResponse>>();
            var client = new HttpClient();
            restRepository
                    .Setup(
                        x => x.GetAsync(
                            It.IsAny<RestBaseRequest>(),
                            It.IsAny<CancellationToken>(),
                            It.IsAny<ILoggingContext>()))
                    .Callback((RestBaseRequest serviceRequest,
                            CancellationToken cancellationToken,
                            ILoggingContext loggingContext) =>
                            {
                              serviceRequest.AmendHeaders(client.DefaultRequestHeaders);
                            }).ReturnsAsync(new Service<LifeBondResponse> { Status = GeneralResponseType.Success, });
            var request = new CustomerRequest<Policy>
            {
                TypeOfRequest = CustomerRetrieveType.PolicyNumber,
                Id = "12345",
                Data = new Policy()
                {
                    PolicyNumber = "123456",
                                    }
            };
            var repository = new LifeBondRepository(this.authoriseService.Object, restRepository.Object);
            // Act
            await repository.GetPolicyAsync(request, new CancellationToken());
            // Assert
            client.DefaultRequestHeaders.Should().NotBeNull();
            client.DefaultRequestHeaders.Any(x => x.Key == "System").Should().Be(true);
            client.DefaultRequestHeaders.GetValues("System").First().Should().Be("Portal");
        }
