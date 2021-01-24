    <table> 
    @{
                if (Models.GetAttachment.lst.Count > 0)
                {
                      for (int m = 0; m < Models.GetAttachment.lst.Count; m++)
                    {
                    <tr>
                        
                        <td>
                            @Html.ActionLink("Download", "Download","Home", new { id = Models.GetAttachment.lst.Coun[m].id })
                        </td>
                    </tr>
                    }
                }
    
    
      }
    </table>
