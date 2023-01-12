namespace HotelListing.Models
{

    public class CreateCountryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string shortName { get; set; } = string.Empty;
    }
    public class CountryDTO:CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }

 
}
