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

namespace DATABASEPRACTICE1.Model
{
    [Table("TASK_DONE")]
    class TasksData
    {
        [Column("Task_name")]
        public string taskName { get; set; }
        
        [PrimaryKey,AutoIncrement]
        public int taskId { get; set; }
    }
}