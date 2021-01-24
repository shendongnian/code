    public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
    {
        ...
        Task.Run(async () => {
            try
            {
                await DirectToLoadImageAsync(stringURL, my_contacts_view.vImage);
            }
            // Catch any other exceptinons that may have occured
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        });
        ...
    }
