namespace HomeWebServer.Entities
{
    public class Device
    {
        public required Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MACAddress { get; set; }
        public string DeviceType { get; set; }
        public DateTime RegisterDateTime { get; set; }

    }
}
