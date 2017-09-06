using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using VideoLibrary;
using System.IO;
using System.Net;

namespace YoutubeDownloaderAndroid
{
     
[Activity(Label = "YoutubeDownloaderAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        async void func()
        {

        }
        WebClient client = new WebClient();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            string url = "https://www.youtube.com/watch?v=9uDgJ9_H0gg";
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(url);
   
            string title = video.Title;
            string fileExtension = video.FileExtension;
            string fullName = video.FullName;

//video.GetBytesAsync();
            button.Text = title;
        
            button.Click += delegate {
              //  byte[] bytes = video.GetBytes();
         //   Task<byte[]> bytess=    video.GetBytesAsync();
                string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                //System.IO.File.WriteAllBytes(path, bytes);
           
                File.WriteAllBytes(path +"/"+ video.FullName, video.GetBytes());
                button.Text = video.Uri;
            };
            
            
        }
        
    }
}

