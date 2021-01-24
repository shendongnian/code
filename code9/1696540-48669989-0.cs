    @{
      var userId = WorkContext.CurrentUser.Id;
      var field = (ContentPickerField)Model.ContentField;
      var contentItem = field.ContentItems.FirstOrDefault(item => item.As<CommonPart>().Owner.Id == userId);
    }
    
    @if(contentItem != null) {
      <div>
        @Display(contentItem.ContentManager.BuildDisplay(contentItem, "Detail"))
      </div>
    }
