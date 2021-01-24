    [Test]
    public void WindowTest() {
        Assert.That(ThrowsSomething("dave"), Is.EqualTo(-1));
        Assert.Throws<ArgumentNullException>(() => ThrowsSomething(null));
    }
