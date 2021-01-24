    @using System.ComponentModel.DataAnnotations
    @using WebApplication1.Models
    @model YogaViewModel
    @{
        var now = DateTime.Now;
        var yogaTimes = Enum.GetValues(typeof(YogaTime)).Cast<int>().Where(t => t > now.Hour * 60 + now.Minute).Cast<YogaTime>();
        var selectList = new List<SelectListItem>();
        foreach (var yogaTime in yogaTimes)
        {
            var memberInfo = typeof(YogaTime).GetMember(yogaTime.ToString());
            if (memberInfo.Length == 0) { continue; }
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Length == 0) { continue; }
            var displayAttribute = attributes[0] as DisplayAttribute;
            if (displayAttribute == null) { continue; }
            selectList.Add(new SelectListItem
            {
                Value = ((int)yogaTime).ToString(),
                Text = displayAttribute.Name
            });
        }
    }
    <div class="col-sm-6" style="padding-left: 0px; padding-right: 0px;">
        @Html.DropDownListFor(m => m.StartTime, selectList, new { @class = "form-control selectpicker", @name = "StartTime" })
    </div>
