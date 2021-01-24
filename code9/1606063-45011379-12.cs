        public class ChemicalHolder : RecyclerView.ViewHolder
        {
            public ImageView Image { get; private set; }
            public TextView Caption { get; private set; }
            public ChemicalHolder(View itemView) : base(itemView)
            {
                Image = itemView.FindViewById<ImageView>(Resource.Id.chemImage);
                Caption = itemView.FindViewById<TextView>(Resource.Id.chemName);
            }
        }
