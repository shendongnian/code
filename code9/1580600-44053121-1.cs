    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Newtonsoft.Json;
    
    namespace Dribl.Droid
    {
        [Activity(Label = "Surveys", Theme = "@style/CustomActionBarTheme")]
        public class Surveys : Activity
        {
            LinearLayout surveysBtn;
            LinearLayout availabilityBtn;
            LinearLayout inboxBtn;
            LinearLayout dashboardBtn;
    
            //Button backBtn;
    
            private List<String> surveys;
            private ListView surveyListview;
            private List<Survey> survey; // notice the survey list here
            private ArrayAdapter<string> adapter; // notice adapter here
    
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Surveys);
                //add the action bar to the layout 
                ActionBar.SetCustomView(Resource.Layout.action_bar);
                ActionBar.SetDisplayShowCustomEnabled(true);
    
                //action bar nav
                surveysBtn = FindViewById<LinearLayout>(Resource.Id.SurveyLayout);
                surveysBtn.Click += surveyBtn_Click;
                inboxBtn = FindViewById<LinearLayout>(Resource.Id.InboxLayout);
                inboxBtn.Click += InboxBtn_Click;
                availabilityBtn = FindViewById<LinearLayout>(Resource.Id.availabilityLayout);
                availabilityBtn.Click += availabilityBtn_Click;
                dashboardBtn = FindViewById<LinearLayout>(Resource.Id.dashboardLayout);
                dashboardBtn.Click += dashboardBtn_Click;
                surveyListview = FindViewById<ListView>(Resource.Id.surveyListView);
                surveyListview.ItemClick += SurveyListview_ItemClick;
    
    
                WebClient client = new WebClient();
                System.Uri uri = new System.Uri("http://dribl.com/api/getAllMySurveys");
                NameValueCollection parameters = new NameValueCollection();
    
    
                parameters.Add("token", GlobalVariables.token);
    
                client.UploadValuesAsync(uri, parameters);
                client.UploadValuesCompleted += client_UploadValuesCompleted;
            }
    
            //listview row click // notice we get the selected survey string here using click event arguments 
            String survey_ID;
            private void SurveyListview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                 var selectedSurvey = survey.ElementAt(e.Position); // first approach or var selectedSurvey = survey[e.Position];
                //var selectedSurvey = adapter.GetItemAtPosition(e.Position); // second approach get selected survey string
                
                // do something with the selectedSurvey
                Intent intent = new Intent(this, typeof(muscleCondition));
                intent.PutExtra("survey_id", selectedSurvey.getId()); //pass survey id here
                StartActivity(intent); 
            }
    
            void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
            {
                string json = Encoding.UTF8.GetString(e.Result);
                survey = JsonConvert.DeserializeObject<List<Survey>>(json);
    
                //get the list view create a string to store and add to the list view based on the json return
                surveyListview = FindViewById<ListView>(Resource.Id.surveyListView);
                surveys = new List<string>();
    
                for (int c = 0; c < survey.Count; c++)
                {                   
                    surveys.Add(survey[c].id + "." + " " + "[" + survey[c].type + "]" + " " + "Date: " + survey[c].created_at);
                }
    
                adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, surveys);
    
                surveyListview.Adapter = adapter;
            }
    
            void surveyBtn_Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(Surveys));
                this.StartActivity(intent);
                this.Finish();
            }
    
            void dashboardBtn_Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(dashboard));
                this.StartActivity(intent);
                this.Finish();
            }
    
            void availabilityBtn_Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(Availability));
                this.StartActivity(intent);
                this.Finish();
            }
    
            void InboxBtn_Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(MsgInbox));
                this.StartActivity(intent);
                this.Finish();
            }
        }
    
        public class Survey
        {
            public int id { get; set; }
            public string type   { get; set; }
            public string created_at { get; set;}
        }
    }
