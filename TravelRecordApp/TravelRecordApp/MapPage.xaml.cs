using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        //private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();

           // GetPermissions();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.Zero, 100);

            var position = await locator.GetPositionAsync();

            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);
        }


        /* private async void GetPermissions()
         {
             try
             {
                 var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                 if (status != PermissionStatus.Granted)
                 {
                     if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                     {
                         await DisplayAlert("Need your location", "We need to access your location", "Ok");
                     }

                     var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                     if (results.ContainsKey(Permission.LocationWhenInUse))
                         status = results[Permission.LocationWhenInUse];
                 }

                 if (status == PermissionStatus.Granted)
                 {
                     locationsMap.IsShowingUser = true;
                     hasLocationPermission = true;

                     GetLocation();
                 }
                 else
                 {
                     await DisplayAlert("Location denied", "You didn't give us permission to access location, so we can't show you where you are", "Ok");
                 }
             }
             catch (Exception ex)
             {
                 await DisplayAlert("Error", ex.Message, "Ok");
             }
         }

         protected override async void OnAppearing()
         {
             base.OnAppearing();

             if (hasLocationPermission)
             {
                 var locator = CrossGeolocator.Current;

                 locator.PositionChanged += Locotor_PositionChanged;
                 await locator.StartListeningAsync(TimeSpan.Zero, 100);


             }
             GetLocation();

         }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locotor_PositionChanged;
        }

        void Locotor_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);

            locationsMap.MoveToRegion(span);
        }*/
    }
}