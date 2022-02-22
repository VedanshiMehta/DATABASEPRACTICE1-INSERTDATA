using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using DATABASEPRACTICE1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATABASEPRACTICE1
{
    class TaskAdapter : RecyclerView.Adapter
    {
        public List<TasksData> mytaskdatastore;
        public Context context;
      

        public TaskAdapter(List<TasksData> mytaskdatastore, Context context)
        {
            this.mytaskdatastore = mytaskdatastore;
            this.context = context;
        }

        public override int ItemCount => mytaskdatastore.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TaskViewHolder taskholder = holder as TaskViewHolder;
            taskholder.BindData(mytaskdatastore[position]);
            taskholder.mycheckBox.CheckedChange += (s, e) =>
            {
                Toast.MakeText(context, mytaskdatastore[position].taskName +" is completed", ToastLength.Short).Show();
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.dataviewlist, parent, false);
            return new TaskViewHolder(view);
        }
    }
    class TaskViewHolder : RecyclerView.ViewHolder
    {
        public CheckBox mycheckBox;
        public TaskViewHolder(View itemView) : base(itemView)
        {
            mycheckBox = itemView.FindViewById<CheckBox>(Resource.Id.checkBox1);
        }

        internal void BindData(TasksData tasksData)
        {
            mycheckBox.Text = tasksData.taskName;
        }
    }
}