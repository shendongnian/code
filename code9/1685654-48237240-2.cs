    protected void Page_Load(object sender, EventArgs e)
    {
        lvCpus.DataSource = GetCpus();
        lvCpus.DataBind();
    }
    private IEnumerable<Cpu> GetCpus()
    {
        yield return new Cpu { Id = 1, Price = 5 };
        yield return new Cpu { Id = 2, Price = 10 };
        yield return new Cpu { Id = 3, Price = 15 };
        yield return new Cpu { Id = 4, Price = 15 };
        yield return new Cpu { Id = 5, Price = 20 };
    }
