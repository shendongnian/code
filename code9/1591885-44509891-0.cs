    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using System;
    using System.Collections.Generic;
    
    namespace Zrelya.Fragments
    {
        public class OnSelectedEventArgs : EventArgs
        {
            public ORM.Plan Plan { get; set; }
    
            public OnSelectedEventArgs( ORM.Plan plan )
            {
                Plan = plan;
            }
        }
    
        public class ViewPlans : FragmentSuper
        {
            private Context mContext;
            private ORM.DBRep dbr;
    
            private static Adapters.Plan Adapter;
            private static ListView listView;
    
            public EventHandler<OnSelectedEventArgs> OnSelected;
    
            public ViewPlans(Context context)
            {
                mContext = context;
            }
    
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Create your fragment here
    
                dbr = new ORM.DBRep();
            }
    
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                // Use this to return your custom view for this Fragment
                var view = inflater.Inflate(Resource.Layout.ViewPlans, container, false);
                listView = view.FindViewById<ListView>(Resource.Id.listView);
    
                
                List<ORM.Plan> plansList = dbr.GetPlans();
                Adapter = new Adapters.Plan(mContext, plansList);
    
    
                listView.Adapter = Adapter;
    
    
                listView.ItemClick += (o, e) =>
                {
                    int id = plansList[e.Position].Id;
    
                    var plan = plansList[e.Position];
    
                    DialogViewPlan(plan);
                };
    
                return view;
            }
    
            private void DialogViewPlan(ORM.Plan plan)
            {
                if (plan != null)
                {
                    FragmentTransaction transaction = Activity.FragmentManager.BeginTransaction();
                    Helpers.DialogViewPlan dialog = new Helpers.DialogViewPlan(Activity, plan);
                    dialog.Show(transaction, "dialog");
                    dialog.OnDelete += delegate
                    {
                        Adapter = new Adapters.Plan(mContext, dbr.GetPlans());
                        listView.Adapter = Adapter;
                    };
                    dialog.OnSave += delegate
                    {
                        Adapter = new Adapters.Plan(mContext, dbr.GetPlans());
                        listView.Adapter = Adapter;
                    };
    
                }
            }
        }
    }
