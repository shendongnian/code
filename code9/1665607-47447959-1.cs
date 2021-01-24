	private BabyNameListAdapter Adapter;
 	public void itemClick(View v)
        {
            int position;
            position = (int)v.Tag;
            switch (v.Id)
            {
                case Resource.Id.editNameButton:
                    System.Diagnostics.Debug.Write("editNameButton click"+" position="+position);
                    break;
                case Resource.Id.deleteNameButton:
                    System.Diagnostics.Debug.Write("deleteNameButton click" + " position=" + position);
                    break;
                default:
                    break;
            }
        }
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            System.Diagnostics.Debug.Write("RowView click");
        }
