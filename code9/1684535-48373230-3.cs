	[TestMethod]
	public void Varias_Pruebas() {
		NinjectKernel.Init();
		var business1 = NinjectKernel.Kernel.Get<ITest__Business>();
		var business2 = NinjectKernel.Kernel.Get<ITest__Business>();
		// Different business objects.
		Assert.AreNotEqual(business1, business2);
		Assert.AreNotSame(business1, business2);
		// Different ConnectionUtil objects.
		Assert.AreNotEqual(business1.ConnectionUtil, business1.ConnectionUtil2);
		Assert.AreNotSame(business1.ConnectionUtil, business1.ConnectionUtil2);
		Assert.AreNotEqual(business1.ConnectionUtil, business1.ConnectionUtil2);
		Assert.AreNotSame(business1.ConnectionUtil, business1.ConnectionUtil2);
		Assert.AreNotEqual(business1.ConnectionUtil2, business1.ConnectionUtil3);
		Assert.AreNotSame(business1.ConnectionUtil2, business1.ConnectionUtil3);
		// Different repositories objects.
		Assert.AreNotEqual(business1.repo1, business1.repo1_2);
		Assert.AreNotSame(business1.repo1, business1.repo1_2);
		Assert.AreNotEqual(business1.repo1, business2.repo1);
		Assert.AreNotSame(business1.repo1, business2.repo1);
		Assert.AreNotEqual(business1.repo2, business1.repo2_2);
		Assert.AreNotSame(business1.repo2, business1.repo2_2);
		Assert.AreNotEqual(business1.repo2, business2.repo2);
		Assert.AreNotSame(business1.repo2, business2.repo2);
		// ConnectionUtils are shared between parameters with the same connString value of the connection attribute.
		Assert.AreEqual(business1.ConnectionUtil, business1.repo1.ConnectionUtil);
		Assert.AreSame(business1.ConnectionUtil, business1.repo1.ConnectionUtil);
		Assert.AreEqual(business1.ConnectionUtil, business1.repo1_2.ConnectionUtil);
		Assert.AreSame(business1.ConnectionUtil, business1.repo1_2.ConnectionUtil);
		Assert.AreEqual(business1.ConnectionUtil2, business1.repo2.ConnectionUtil);
		Assert.AreSame(business1.ConnectionUtil2, business1.repo2.ConnectionUtil);
		Assert.AreEqual(business1.ConnectionUtil2, business1.repo2_2.ConnectionUtil);
		Assert.AreSame(business1.ConnectionUtil2, business1.repo2_2.ConnectionUtil);
		 Assert.AreEqual(business1.ConnectionUtil3, business1.repo3.ConnectionUtil);
		Assert.AreSame(business1.ConnectionUtil3, business1.repo3.ConnectionUtil);
		// No ConnectionUtils are shared between parameters with different connString value from the connection attribute.
		Assert.AreNotEqual(business1.ConnectionUtil, business1.repo2.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil, business1.repo2.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil, business1.repo2_2.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil, business1.repo2_2.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil2, business1.repo1.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil2, business1.repo1.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil2, business1.repo1_2.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil2, business1.repo1_2.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil2, business1.repo3.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil2, business1.repo3.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil3, business1.repo1.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil3, business1.repo1.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil3, business1.repo1_2.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil3, business1.repo1_2.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil3, business1.repo2.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil3, business1.repo2.ConnectionUtil);
		Assert.AreNotEqual(business1.ConnectionUtil3, business1.repo2_2.ConnectionUtil);
		Assert.AreNotSame(business1.ConnectionUtil3, business1.repo2_2.ConnectionUtil);
	}
