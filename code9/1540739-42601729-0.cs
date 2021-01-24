    class ARP_Table_entry
    {
       List<string> mysteriousList;
       int pos; 
       public ARP_Table_entry(List<string> mysteriousList, int pos,...)
       {
          this.mysteriousList = mysteriousList;
          this.pos = pos;
          ...
       }
         
        // TODO: add null check/position verification as needed
        string local_inter => mysteriousList[pos];
         // or {get { return mysteriousList[pos];} for C# 5 and below
        ...
