namespace HotelListing.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;

        public virtual IList<Hotel> Hotels { get; set; }
    }
}
