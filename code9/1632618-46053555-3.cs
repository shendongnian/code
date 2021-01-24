    @model DemoApp.Models.Rootobject
    
    @{
        Layout = null;
    }
    
    <div>
        @foreach (var webinar in Model.Webinars)
        {
            <h3>@webinar.Title</h3>
            <ul>
                <li>@webinar.Categories[0].TimeZone</li>
            </ul>
        }
    </div>
