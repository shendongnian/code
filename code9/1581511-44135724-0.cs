    @using Kendo.Mvc.UI
    @using Kendo.Mvc.UI.Fluent
    @using RoomBooking.Domain
    @{
        ViewData["Title"] = "Home Page";
    }
    
    
    <div class="row">
        <div class="col-md-12">
            <ul id="officeTab" class="nav nav-tabs"></ul>
        </div>
    
    </div>
    
    <div>
        @(Html.Kendo().Scheduler<Meeting>().Name("scheduler").Date(new DateTime(2017, 5, 13))
              .StartTime(new DateTime(2017, 5, 13, 7, 00, 00))
              .Editable(true)
              .Views(views =>
              {
                  views.DayView();
                  views.AgendaView();
              })
              .Height(600)
              .Timezone("Etc/UTC")
              .Group(group => { group.Resources("Rooms"); group.Date(true); })
              .Resources(resource =>
              {
                  //resource.Add(m => m.RoomId).Title("Room").Name("Rooms").DataTextField("Text").DataValueField("Value").DataColorField("Color").BindTo(new[]
                  //{
                  //    new {Text = "Meeting Room 101", Value = 1, Color = "#6eb3fa"},
                  //    new {Text = "Meeting Room 201", Value = 2, Color = "#f58a8a"}
                  //});
                  resource.Add(m => m.RoomId)
                     .Title("Room")
                     .Name("Rooms")
                     .DataTextField("Text")
                     .DataSource(
                         ds => ds.Custom()
                         .Type("aspnetmvc-ajax")
                         .Transport(t => t.Read(r =>
                        r.Action("readRoom", "Room")))
                        .Schema(s => s.Data("Data").Total("Total").Errors("Errors").Model(m =>
                        {
                            m.Id("Value");
                            m.Field("Value", typeof(int));
                            m.Field("Text", typeof(string));
                            m.Field("Color", typeof(string));
                        })
                        ));
              })
              .DataSource(d => d
                  .WebApi()
                  .Model(m =>
                  {
                      m.Id(f => f.RecordId);
                      m.Field(f => f.Title).DefaultValue("No title");
                      m.Field(f => f.Title).DefaultValue("No title");
                  })
                  .Events(events => events.Error("error_handler"))
                  .Read(read => read.Action("Get", "Meeting"))
                  .Create(create => create.Action("Post", "Meeting"))
                  .Destroy(destroy => destroy.Action("Delete", "Meeting", new { recordId = "{0}" }))
                  .Update(update => update.Action("Put", "Meeting", new { recordId = "{0}" }))
              ).Deferred())
    
    
        @section scripts {
            @Html.Kendo().DeferredScripts()
        }
        <script>
            function error_handler(e) {
                var errors = $.parseJSON(e.xhr.responseText);
    
                if (errors) {
                    alert("Errors:\n" + errors.join("\n"));
                }
            }
        </script>
    
    </div>
