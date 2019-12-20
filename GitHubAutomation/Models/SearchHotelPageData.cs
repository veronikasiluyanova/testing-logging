

namespace AirAsiaAutomation.Models
{
    public class SearchHotelPageData
    {
        public string Destination { get; }
        public string CheckInDate { get; }
        public string CheckOutDate { get; }

        public SearchHotelPageData(string destination, string checkIn, string checkOut)
        {
            Destination = destination;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
        }
    }
}
