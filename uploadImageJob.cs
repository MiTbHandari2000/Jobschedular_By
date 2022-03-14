using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Jobschedular_By
{

    public static class Jobschedular_By
    {

        public static JobInfo.Builder CreateJobBuilderUsingjobId<T>(this Context context, int jobId) where T : JobService
        {
            Class javaClass = Class.FromType(typeof(T));
            ComponentName componentName = new ComponentName(context, javaClass);
            return new JobInfo.Builder(jobId, componentName);
        }
    }
}