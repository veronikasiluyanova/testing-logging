

namespace AirAsiaAutomation.Models
{
    public class MainPageData
    {
        public string DeparturePlace;
        public string ArrivalPlace;
        public string LeaveDate;
        public string ReturnDate;

        public MainPageData (string departure, string arrival, string leaveDate, string returnDate)
        {
            DeparturePlace = departure;
            ArrivalPlace = arrival;
            LeaveDate = leaveDate;
            ReturnDate = returnDate;
        }        
    }
}
