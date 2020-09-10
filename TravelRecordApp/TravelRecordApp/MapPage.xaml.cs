using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.MinValue, 100);

            var position = await locator.GetPositionAsync();

            locationsMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(
                new Position(position.Latitude, position.Longitude),
                2, 2));
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            locationsMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(
                new Position(e.Position.Latitude, e.Position.Longitude),
                2, 2));

        }
    }
}