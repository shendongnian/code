    public class ExpandableListViewAdapter : BaseExpandableListAdapter,IFilterable
    {
      ...
      //this adapter's applied expandablelistview
      private ExpandableListView _exListView;
      //the index for last opened group
      private int _lastExpandGroupPosition;
      
      public ExpandableListViewAdapter(Context context, List<string> listGroup, Dictionary<string, List<string>> listChild)
      {
         this.context = context;
         this.listGroup = listGroup;
         this.listChild = listChild;
         _filter = new GroupFilter(this);
      }
      //create a constructor to accept the expandablelistview and reuse the original constructor
      public ExpandableListViewAdapter(Context context, List<string> listGroup, Dictionary<string, List<string>> listChild, ExpandableListView exListview) : this(context, listGroup, listChild)
      {
          _exListView = exListview;
      }
      //override OnGroupExpanded to collapse the last opened group
      public override void OnGroupExpanded(int groupPosition)
      {
          if (groupPosition != _lastExpandGroupPosition)
          {
              _exListView.CollapseGroup(_lastExpandGroupPosition);
                
          }
          _lastExpandGroupPosition = groupPosition;
      }
     ...
    }
