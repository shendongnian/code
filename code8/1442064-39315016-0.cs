    calcs = new []
    {
        new { Key = "TPrintBw", Value = gr.Sum(u => u.TPrintBw) },
        new { Key = "TPrintCol", Value = gr.Sum(u => u.TPrintCol) },
        new { Key = "TCopyBw", Value = gr.Sum(u => u.TCopyBw) },
        new { Key = "TCopyCol", Value = gr.Sum(u => u.TCopyCol) },
        new { Key = "TScan", Value = gr.Sum(u => u.TScan) },
        new { Key = "TFaxBw", Value = gr.Sum(u => u.TFaxBw) },
    }.ToList()
