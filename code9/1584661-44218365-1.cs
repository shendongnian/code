    @model List<string>
    <table >
                @{ 
                    for (int i = 1; i <= Model.Count; i++)
                    {
                        if (i % 2 != 0)
                        {
                            @:<tr >
                        }
                        <td style="border:solid;">
                                @Model[i - 1]
                        </td>
    
                         if (i % 2 == 0)
                         {
                             @:</tr>
                         }
                      }
                  }
        </table>
