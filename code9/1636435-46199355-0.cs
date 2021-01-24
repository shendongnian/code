    [Test]
    public void ParsingWithCommaDecimalSeparatorShouldWork()
    {
        var ci = new CultureInfo(CultureInfo.CurrentCulture.Name)
                 {
                     NumberFormat =
                     {
                         NumberDecimalSeparator = ","
                         , NumberGroupSeparator = "."
                     }
                 };
        CultureInfo.DefaultThreadCurrentCulture = ci;
        var result = "";
        var thread = new Thread
            ( delegate()
            {
                Console.WriteLine(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                Console.WriteLine(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);
                var t = Template.Parse("{{2.5}}");
                result = t.Render(new Hash(), CultureInfo.InvariantCulture);
            } );
        thread.Start();
        thread.Join();
        Assert.AreEqual(result, "2.5");
    }
