using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var ibLogo = FindViewById<ImageButton>(Resource.Id.ibLogo);

            ibLogo.Click += async (s, e) =>
            {
                var client = new SALLab13.ServiceClient();
                string email = "";
                string password = "";
                var Result = await client.ValidateAsync(this, email, password);

                Android.App.AlertDialog.Builder Builder =
                    new AlertDialog.Builder(this);

                AlertDialog Alert = Builder.Create();
                Alert.SetTitle("Resultado de la verificación");
                Alert.SetIcon(Resource.Drawable.Icon);

                Alert.SetMessage(
                    $"{Result.Status}\n{Result.FullName}\n{Result.Token}");

                Alert.SetButton("Ok", (se, ev) => { });

                Alert.Show();
            };
        }
    }
}