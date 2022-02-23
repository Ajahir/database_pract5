using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data_tata
{
    class employeeAdapter : RecyclerView.Adapter
    {
        private List<employeetable> datalist;
        public Context context;
        employeedatabase eDB;
        employeetable employeeU;

        public override int ItemCount => datalist.Count;
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DataViewholder Dataholder = holder as DataViewholder;
            Dataholder.BindData(datalist[position]);
            Dataholder.update.Click += (s, e) =>
            {
                Intent i = new Intent(context, typeof(updateActivity));
                i.PutExtra("StudentDetails", datalist[position].Id);
                context.StartActivity(i);
               

            };
            Dataholder.delete.Click += (s, e) =>
            {

                eDB = new employeedatabase();
                employeeU = eDB.GetByUserId(datalist[position].Id);
                if (employeeU != null)
                {
                    var isDeleted = eDB.DeleteStudents(employeeU);
                    if (isDeleted == true)
                    {
                        Toast.MakeText(context, "Data Deleted Succesfully", ToastLength.Short).Show();
                    }

                    else
                    {

                        Toast.MakeText(context, "No action performed", ToastLength.Short).Show();

                    }
                }
                Intent i = new Intent(Application.Context, typeof(MainActivity));
                context.StartActivity(i);
            };
        }

       
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.updatedeleteAct, parent, false);
            return new DataViewholder(view);
        }


        public employeeAdapter(List<employeetable> datalist, Context context)
        {
            this.datalist = datalist;
            this.context = context;
        }

    }
    internal class DataViewholder : RecyclerView.ViewHolder
    {
        public TextView employeeName;
        public TextView employeeSurName;
        public TextView employeedepartment;
        public TextView employeeSalary;
        public LinearLayout linear;
        public Button delete;
        public Button update;
        public DataViewholder(View itemView) : base(itemView)
        {
            employeeName = itemView.FindViewById<TextView>(Resource.Id.nameview);
            employeeSurName = itemView.FindViewById<TextView>(Resource.Id.surnameview);
            employeedepartment = itemView.FindViewById<TextView>(Resource.Id.departmentview);
            employeeSalary = itemView.FindViewById<TextView>(Resource.Id.salaryview);
            update = itemView.FindViewById<Button>(Resource.Id.update);
            linear = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            delete = itemView.FindViewById<Button>(Resource.Id.delete);
        }

        internal void BindData(employeetable employeetable)
        {
            employeeName.Text = employeetable.Name;
            employeeSurName.Text = employeetable.Surname;
            employeedepartment.Text = employeetable.Department; ;
            employeeSalary.Text = employeetable.salary.ToString();
        }
    }
}
















