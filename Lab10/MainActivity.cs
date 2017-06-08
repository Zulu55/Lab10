using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = false, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        int counter = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var contentHeaderTextView = FindViewById<TextView>(Resource.Id.ContentHeaderTextView);
            contentHeaderTextView.Text = GetText(Resource.String.ContentHeader);

            var clickMeButton = FindViewById<Button>(Resource.Id.ClickMeButton);
            var clickCounterTextView = FindViewById<TextView>(Resource.Id.ClickCounterTextView);

            clickMeButton.Click += (s, e) =>
            {
                counter++;
                clickCounterTextView.Text = Resources.GetQuantityString(
                    Resource.Plurals.NumberOfClicks, counter, counter);

                var player = Android.Media.MediaPlayer.Create(this, Resource.Raw.sound);
            };

            Android.Content.Res.AssetManager manager = this.Assets;
            using (var reader = new System.IO.StreamReader(manager.Open("Contenido.txt")))
            {
                contentHeaderTextView.Text = $"\n\n{reader.ReadToEnd()}";
            }
        }
    }
}

