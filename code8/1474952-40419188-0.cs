    Func<List<Job>, Job> umbracoHelper = lj => lj.First(); // or any other selection method...
            var listToReturn = new List<JobsModelForDataTable>();
            var listOfJobs = new List<Job>();
            new Mock<IEnumerableWrapperService>().Setup(x => x.Select(listOfJobs, It.IsAny<Func<Job, JobsModelForDataTable>>()))
                                                 .Callback<List<Job>, Func<Job, JobsModelForDataTable>>((j, fj) => fj(umbracoHelper(j)))
                                                 .Returns(listToReturn);
