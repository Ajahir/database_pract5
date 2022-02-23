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
    [Activity(Label = "updateActivity")]
    public class updateActivity : Activity
    {
        public TextView employeeName;
        public TextView employeeSurName;
        public TextView employeedepartment;
        public TextView employeeSalary;
        Button update_btn;
        employeedatabase eDB;
        employeetable employeeU;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.update);
            update_btn = FindViewById<Button>(Resource.Id.updatebtn);
            employeeName = FindViewById<TextView>(Resource.Id.updatename);
            employeeSurName = FindViewById<TextView>(Resource.Id.updateSurname);
            employeedepartment =FindViewById<TextView>(Resource.Id.updateDepartment);
            employeeSalary = FindViewById<TextView>(Resource.Id.updateSalary);
            update_btn.Click += Update_btn_Click;
            if (Intent.Extras != null)
            {

                int message = Intent.Extras.GetInt(key: "StudentDetails", 0);

                if (message != 0)
                {
                    eDB = new employeedatabase();

                    employeeU = eDB.GetByUserId(message);

                    employeeName.Text = employeeU.Name;
                    employeeSurName.Text = employeeU.Surname;
                    employeedepartment.Text = employeeU.Department;
                    employeeSalary.Text = employeeU.salary.ToString();
                }
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (employeeU != null)
            {

                employeeU.Name = employeeName.Text;
                 employeeU.Surname = employeeSurName.Text;
                employeeU.Department = employeedepartment.Text;
                employeeU.salary= int.Parse(employeeSalary.Text);

                bool isUpdated = eDB.UpdateStudents(employeeU);

                if (isUpdated == true)
                {
                    Toast.MakeText(this, "Data Updated Succesfully", ToastLength.Short).Show();
                }

                else
                {

                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                }
            }
            StartActivity(typeof(MainActivity));
        }
    }
}