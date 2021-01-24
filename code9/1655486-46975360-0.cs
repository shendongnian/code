    [TestMethod]
    public void SaveCategoriesAsync_When_Then()
    {
        A.CallTo(() => this.articleRepository.GetArticles(A<IList<long>>._)).Returns(new List<ArticleModel>());
        Func<Task> func = async () => await this.testee.SaveCategoriesAsync(new List<int>());
        func.ShouldThrow<Exception>();
    }
