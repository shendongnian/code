    Index.cshtml
    
    @{
        ViewBag.Title = "Index";
    }
    @model List<TwilioVideos.Controllers.HomeController.Recording>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    @*<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>*@
    <h2>&nbsp;&nbsp;&nbsp;Twilio Recorded Videos List</h2>
    <br />
    @if (Model != null)
    {
        int i = 1;
        <table class="table table-bordered table-striped" style="    margin: 10px;" >
            <thead>
    
                <tr class="bg-success">
                    <th>S.no</th>
                    <th>Date</th>
                    <th>type</th>
                    <th>videos</th>
                    <th>status</th>
                </tr>
            </thead>
    
            @foreach (var item in Model)
            {
                if(@item.type=="video")
                {
                  
                    
                <tr class="bg-info">
                    <td>&nbsp;&nbsp;@i</td>
                    <td>@item.date_created</td>
                    <td>@item.type</td>
                    <td>
                       
                        <video width="200" poster="/Images/mp4.jpg" controls>
                             <source src="@item.links.media" type="video/mp4">
                           
                        </video>
                       
                       
                    </td>
                    <td>@item.status</td>
                </tr>
                    i++;
            }
            }
        </table>
    }
    
    
    Home controller.cs
    
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Twilio.Clients;
    using Twilio.Exceptions;
    using Twilio.Http;
    using Twilio.Jwt.AccessToken;
    using Twilio.Rest.Video.V1.Room;
    using System.Text;
    using System.Net.Http.Headers;
    using System.IO;
    
    
    
    namespace TwilioVideos.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
    
            public class GroupingSids
            {
                public string participant_sid { get; set; }
                public string room_sid { get; set; }
            }
    
            public class Links
            {
                public string media { get; set; }
            }
    
            public class Recording
            {
                public string status { get; set; }
                public GroupingSids grouping_sids { get; set; }
                public string url { get; set; }
                public string container_format { get; set; }
                public string account_sid { get; set; }
                public string room_sid { get; set; }
                public string codec { get; set; }
                public string source_sid { get; set; }
                public string sid { get; set; }
                public int duration { get; set; }
                public string date_created { get; set; }
                public string type { get; set; }
                public int size { get; set; }
                public Links links { get; set; }
            }
    
            public class Meta
            {
                public int page { get; set; }
                public int page_size { get; set; }
                public string first_page_url { get; set; }
                public object previous_page_url { get; set; }
                public string url { get; set; }
                public object next_page_url { get; set; }
                public string key { get; set; }
            }
    
            public class RootObject
            {
                public List<Recording> recordings { get; set; }
                public Meta meta { get; set; }
            }
    
    
    
    
    
    
           
    
         
          
    
            private static Request BuildFetchRequest(FetchRoomRecordingOptions options, ITwilioRestClient client)
            {
               
    
              
    
                 return new Request(
                    Twilio.Http.HttpMethod.Get,
                    Twilio.Rest.Domain.Video,
                   "/v1/Recordings",
                    client.Region,
                   queryParams: options.GetParams()
                );
    
            }
    
    
    
    
    
    
            /*try */
    
            public ActionResult Index()
            {
                
                var options = new FetchRoomRecordingOptions(Roomsid, "");
                Twilio.TwilioClient.Init("SK0aXXXXXXXXXXXXXXXXXXXXXXXX", "q7XXXXXXXXXXXXXXXXXXXXXXXXX", "ACXXXXXXXXXXXXXXXXXXXXXXXX");
                var client = Twilio.TwilioClient.GetRestClient();
    
    
    
    
    
    
    
              
                var response = client.Request(BuildFetchRequest(options, client));
                var o = JsonConvert.DeserializeObject<RootObject>(response.Content);
                List<Recording> cd = new List<Recording>();
                cd = o.recordings.ToList();
                return View(cd);
            }
    
    
           
         
         
    
        }
    }
