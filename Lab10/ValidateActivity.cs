using Android.App;
using Android.OS;
using Android.Widget;
using SALLab10;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/Icon")]
    public class ValidateActivity : Activity
    {
        EditText EmailText;
        EditText PasswordText;
        Button ValidateButton;
        TextView MessageText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Validate);

            EmailText = FindViewById<EditText>(Resource.Id.EmailText);
            PasswordText = FindViewById<EditText>(Resource.Id.PasswordText);
            ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            MessageText = FindViewById<TextView>(Resource.Id.MessageText);

            ValidateButton.Click += ValidateButton_Click;
        }

        private async void ValidateButton_Click(object sender, System.EventArgs e)
        {
            var serviceClient = new ServiceClient();
            var studentEmail = EmailText.Text;
            var password = PasswordText.Text;
            var myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);
            MessageText.Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
        }
    }
}