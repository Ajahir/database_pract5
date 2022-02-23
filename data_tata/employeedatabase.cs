using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace data_tata
{
    class employeedatabase
    {

        public static string DBname = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);

        SQLiteConnection sqliteConnection;

        public employeedatabase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sqliteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }
        }

        public void employeetable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<employeetable>();
                Console.WriteLine("Succefully Table Created!....");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }

        }

        public bool InstertData(employeetable task)
        {
            long result = sqliteConnection.Insert(task);
            if (result == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Succefully Inserted Data ");
                return true;
            }
        }
        public employeetable GetByUserId(int studentId)
        {
            var userId = sqliteConnection.Table<employeetable>().Where(u => u.Id == studentId).FirstOrDefault();

            return userId;
        }

            public employeetable GetByUserName(string studentName)
            {
                var user = sqliteConnection.Table<employeetable>().Where(u => u.Name == studentName).FirstOrDefault();

                return user;

            }

            public employeetable GetByUserSurName(string studentSurName)
            {
                var userSurName = sqliteConnection.Table<employeetable>().Where(u => u.Surname == studentSurName).FirstOrDefault();

                return userSurName;

            }
          public employeetable GetByUserDepartment(string studentDepartment) { 

            var userdepartment = sqliteConnection.Table<employeetable>().Where(u => u.Department == studentDepartment).FirstOrDefault();

            return userdepartment;

        }
        public employeetable GetByUserSalary(int studentsalary)
        {
            var usersalary = sqliteConnection.Table<employeetable>().Where(u => u.salary == studentsalary).FirstOrDefault();

            return usersalary;
        }


        public List<employeetable> ReadTask()
        {
            try
            {
                var taskdata = sqliteConnection.Table<employeetable>().ToList();
                return taskdata;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }


        }
        public bool UpdateStudents(employeetable students)
        {

            long result = sqliteConnection.Update(students);


            if (result == 1)
            {


                Console.WriteLine("Succefully Updated Data ");
                return true;
            }
            else
            {
                Console.WriteLine("Not any action perform ");
                return false;

            }


        }

        public bool DeleteStudents(employeetable data)
        {


            long result = sqliteConnection.Delete(data);
            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Deleted Data ");
                return true;
            }


        }
    }

}