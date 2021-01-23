    calcs = new List<KeyValuePairDto<string, int>>
    {
        new KeyValuePairDto<string, int> { Key = "TPrintBw", Value = gr.Sum(u => u.TPrintBw) },
        new KeyValuePairDto<string, int> { Key = "TPrintCol", Value = gr.Sum(u => u.TPrintCol) },
        new KeyValuePairDto<string, int> { Key = "TCopyBw", Value = gr.Sum(u => u.TCopyBw) },
        new KeyValuePairDto<string, int> { Key = "TCopyCol", Value = gr.Sum(u => u.TCopyCol) },
        new KeyValuePairDto<string, int> { Key = "TScan", Value = gr.Sum(u => u.TScan) },
        new KeyValuePairDto<string, int> { Key = "TFaxBw", Value = gr.Sum(u => u.TFaxBw) },
    }
