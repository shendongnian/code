    @model ForExample.Models.DataClass
    
    @{
        ViewBag.Title = "Edit: " + Model.Title;
    }
    
    @if(Model != null)
    {
        string message = ViewBag.Message as string;
        if (!string.IsNullOrEmpty(message))
        {      
            if (message.Contains("Successfully"))
            {
                <h3 style="color:green;">@message</h3>
            }
            else
            {
                <h3 style="color:red;">@message</h3>
            }
        }
    }
