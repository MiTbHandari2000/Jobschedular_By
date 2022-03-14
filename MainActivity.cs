using Android.App;
using Android.App.Job;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
namespace Jobschedular_By
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button startuploadBT, stopUploadBT;
        private JobInfo.Builder _jobInfoBuilder;
        private JobScheduler _jobSchedular;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _jobSchedular = (JobScheduler)GetSystemService(JobSchedulerService);
            UIReference();
            UIClickEvent();
        }

        private void UIClickEvent()
        {
            startuploadBT.Click += StartuploadBT_Click;
            stopUploadBT.Click += StopUploadBT_Click;
        }

        private void StopUploadBT_Click(object sender, EventArgs e)
        {
            _jobSchedular.Cancel(jobId: 1);
            Toast.MakeText(this, text: $"Job Stopped", ToastLength.Short).Show();
        }

        private void StartuploadBT_Click(object sender, EventArgs e)
        {
            CreateJobInfoBuilder();

            JobInfo jobInfo = _jobInfoBuilder.Build();
            var scheduleResult = _jobSchedular.Schedule(jobInfo);

            if (JobScheduler.ResultSuccess == scheduleResult)
            {

                Toast.MakeText(this, text: "Job Scheduled successfully", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, text: "Job Failed", ToastLength.Short).Show();
            }
        }

        private void CreateJobInfoBuilder()
        {
            _jobInfoBuilder = this.CreateJobBuilderUsingjobId<Uploadimage>(jobId: 1)
                          .SetRequiredNetworkType(NetworkType.Unmetered)
                          .SetPeriodic(15 * 60 * 1000);
        }

        private void UIReference()
        {
            startuploadBT = FindViewById<Button>(Resource.Id.startuploadButton);
            stopUploadBT = FindViewById<Button>(Resource.Id.StopUploadButton);
        }
    }








}


















































