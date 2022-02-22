using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using DATABASEPRACTICE1.Model;
using System;
using System.Collections.Generic;

namespace DATABASEPRACTICE1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText mytaskedts;
        private Button myaddB;
        private RecyclerView myrecyclerView;
        private TaskDataBase mytaskDataBase;
        private List<TasksData> mytaskdatastore;
        public RecyclerView.LayoutManager myviewManager;
        private TaskAdapter mytaskAdapter;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mytaskDataBase = new TaskDataBase();
            mytaskDataBase.TaskTable();

            mytaskedts = FindViewById<EditText>(Resource.Id.addtaskedt);
            myaddB = FindViewById<Button>(Resource.Id.addB);
            myrecyclerView = FindViewById<RecyclerView>(Resource.Id.dataView);
           
           
           
         
            myaddB.Click += MyaddB_Click;
            


        }

        private void MyaddB_Click(object sender, EventArgs e)
        {
            TasksData mytask = new TasksData();
            mytask.taskName = mytaskedts.Text;

            var isDataInsertedCheck = mytaskDataBase.InsertTask(mytask);
            if(isDataInsertedCheck == true)
            {

                Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();

            }
            else
            {

                Toast.MakeText(this, "No action performed", ToastLength.Short).Show();


            }

            ReadDataTaskData();

            myviewManager = new LinearLayoutManager(this);
            myrecyclerView.SetLayoutManager(myviewManager);

            mytaskAdapter = new TaskAdapter(mytaskdatastore, this);
            myrecyclerView.SetAdapter(mytaskAdapter);
        }

        private List<TasksData> ReadDataTaskData()
        {
            var data = mytaskDataBase.ReadTask();
            mytaskdatastore = new List<TasksData>();
            mytaskdatastore.AddRange(data);

            return mytaskdatastore;



            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}