    @using (var e1 = Model.Date1.Reverse().GetEnumerator())
    {
      using (var e2 = Model.Date2.Reverse().GetEnumerator())
      {
        while (e1.MoveNext() && e2.MoveNext())
        {
             var item1 = e1.Current;
             var item2 = e2.Current;  
             <tr>
                 <td> item1.theDate </td>
                 <td> item1.theCount </td>
                 <td> item2.theCount </td>
             </tr>
        }
      }
    }
