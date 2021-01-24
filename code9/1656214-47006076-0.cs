    public CompanyViewHolder(View itemView, Action<int> listener) : base(itemView)
    {
        companyImageView = itemView.FindViewById<ImageView>(Resource.Id.company_image);
        companyNameView = itemView.FindViewById<TextView>(Resource.Id.company_name);
        itemView.Click += (sender, e) => listener (base.LayoutPosition);
    }
