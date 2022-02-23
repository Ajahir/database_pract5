using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data_tata
{
    [Table("employee_table")]
    class employeetable
    {
            [Column("employee_Name")]
            public string Name { get; set; }


            [Column("employee_Surname")]
            public string Surname { get; set; }

            [Column("employee_department")]
           
            public string Department { get; set; }

            [Column("employee_Salary")]
            public int salary { get; set; }

           [PrimaryKey, AutoIncrement]
            public int Id { get; set; }



        }
    }

