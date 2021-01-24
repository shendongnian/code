    @{
        List<Chart> chartsAll = Session["GetAllChart"] as List<Chart>;
    }
    
    
    <div class="col-md-4">
        <section id="showChart">
    
            @if (chartsAll != null)
            {
                int i = 1;
                foreach (var aChart in chartsAll)
                {
                    string name = string.Format("~/Content/Chart{0}.png", i++);
                    aChart.Save(name);
                    <img src="@Url.Content(name)" alt="@name" />
                }
            }
    
        </section>
    </div>
