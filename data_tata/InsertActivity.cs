using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data_tata
{
    [Activity(Label = "InsertActivity")]
    public class InsertActivity : Activity
    {
        private Button btn;
        private EditText myName;
        private EditText mySurname;
        private EditText myDepartment;
        private EditText mySalary;
        private Button Addbtn;
        employeedatabase Tdb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.insertAct);
            Addbtn = FindViewById<Button>(Resource.Id.addbutton);
            Addbtn.Click += Addbtn_Click;
            myName = FindViewById<EditText>(Resource.Id.Nameedit);
            mySurname = FindViewById<EditText>(Resource.Id.Surnameedit);
            myDepartment = FindViewById<EditText>(Resource.Id.Departmentedit);
            mySalary = FindViewById<EditText>(Resource.Id.SalaryEdit);
            Tdb = new employeedatabase();
            Tdb.employeetable();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            employeetable studs = new employeetable();
            studs.Name = myName.Text;
            studs.Department = myDepartment.Text;
            studs.Surname = mySurname.Text;
            studs.salary = int.Parse(mySalary.Text);



            bool checkinsert = Tdb.InstertData(studs);
            if (checkinsert == true)
            {

                Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();

            }
            else
            {

                Toast.MakeText(this, "No action performed", ToastLength.Short).Show();


            }
            StartActivity(typeof(MainActivity));
        }
    }
}