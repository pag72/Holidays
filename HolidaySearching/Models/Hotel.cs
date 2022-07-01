﻿using System.Text.Json.Serialization;

namespace HolidaySearch.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonPropertyName("price_per_night")]
        public int PricePerNight { get; set; }
        [JsonPropertyName("local_airports")]
        public List<string> LocalAirports { get; set; }
        public int Nights { get; set; }

        public Hotel() {
            Name = string.Empty;
            LocalAirports = new List<string>();
        }
    }
}