namespace FlightBooking.Settings
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string FlightCollectionName { get; set; }
        public string BookingCollectionName { get; set; }
    }
}
