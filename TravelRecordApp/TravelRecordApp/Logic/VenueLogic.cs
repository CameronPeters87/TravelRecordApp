﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.Generate_Url(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
            }

            return venues;
        }
    }
}