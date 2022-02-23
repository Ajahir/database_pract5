using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;

namespace data_tata
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        private List<employeetable> datalist;
        RecyclerView.LayoutManager myLayoutmanager;
        RecyclerView myrecyclerView;
        private employeedatabase myDataBase;
        private employeeAdapter eadapter;
        private ImageView addbtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            myrecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            addbtn = FindViewById<ImageView>(Resource.Id.imageView1);
            addbtn.Click += Addbtn_Click;
            myDataBase = new employeedatabase();
            myDataBase.employeetable();
            Getemployeedetails();
            myLayoutmanager = new LinearLayoutManager(this);
            myrecyclerView.SetLayoutManager(myLayoutmanager);

            eadapter = new employeeAdapter(datalist, this);
            myrecyclerView.SetAdapter(eadapter);
        }

        private List<employeetable> Getemployeedetails()
        {
            myDataBase = new employeedatabase();
            var data = myDataBase.ReadTask();

            datalist = new List<employeetable>();

            datalist.AddRange(data);

            return datalist;
        }

        private void Addbtn_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(InsertActivity));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}