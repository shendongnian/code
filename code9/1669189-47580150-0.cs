    public Command NewModelB
    {
        get
        {
            return new Command(() =>
            {
                db.Write(() =>
                {
                    ModelA.ModelBs.Add(new ModelB
                    {
                        Name = "B",
                        InProgress = true
                    });
                });
            });
        }
    }
    public Command SaveModelA
    {
        get
        {
            return new Command(async () =>
            {
                db.Write(() =>
                {
                    var toCommit = ModelA.ModelBs.Where(m => m.InProgress);
                    foreach (var modelB in toCommit)
                    {
                        modelB.InProgress = false;
                    }
                });
                await CoreMethods.PopPageModel();
            });
        }
    }
    protected override void ViewIsDisappearing(object sender, EventArgs e)
    {
        base.ViewIsDisappearing(sender, e);
        db.Write(() =>
        {
            var toDelete = ModelA.ModelBs.Where(m => m.InProgress).ToArray();
            foreach (var modelB in toDelete)
            {
                db.Remove(modelB);
            }
        });
    }
