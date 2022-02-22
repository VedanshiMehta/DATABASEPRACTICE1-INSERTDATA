using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DATABASEPRACTICE1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace DATABASEPRACTICE1
{
    class TaskDataBase
    {
        public static string DBName = "SQLite.db3";
        public static string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBName);

        SQLiteConnection sqliteconnection;

        public TaskDataBase()
        {
            try {

                Console.WriteLine(DataPath);
                sqliteconnection = new SQLiteConnection(DataPath);
                Console.WriteLine("Database created sucessfully");


            }
            catch(Exception ex)
            {

                Console.WriteLine("Database Exception:" + ex);
            }
           
            
        }

        public void TaskTable()
        {
            try {

                var creatdata = sqliteconnection.CreateTable<TasksData>();
                Console.WriteLine("Table created successfully" + creatdata);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Table creation Exception:" + ex);
            }


        }

   
        public bool InsertTask(TasksData tasksdata)
        {

            long result = sqliteconnection.Insert(tasksdata);

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

        public List<TasksData> ReadTask()
        {
            try {
                var taskdata = sqliteconnection.Table<TasksData>().ToList();
                return taskdata;

            }catch(Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }
           

        }
    }
}