using HotelListing.Data;

namespace HotelListing.Models
{

    public class CreateHotelDTO
    {
       public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int CountryId { get; set; }       
    }

    public class HotelDTO:CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
