    <td>
     @{
         var oneItem = Model.FirstOrDefault(x => x.Id == Model.ThisAlbumId);
         //Notice that I used "Model" and not "model". The difference is huge!
         if (oneItem != null)
         {
            Html.Raw(oneItem.AlbumId);
         }
      }
    </td>
