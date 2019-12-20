

namespace AirAsiaAutomation.Models
{
    public class SearchHotelPageData
    {
        public string Destination;
        public string CheckInDate;
        public string CheckOutDate;

        public SearchHotelPageData(string destination, string checkIn, string checkOut)
        {
            Destination = destination;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
        }
    }
}
