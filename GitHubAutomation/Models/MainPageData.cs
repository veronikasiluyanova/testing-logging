

namespace AirAsiaAutomation.Models
{
    public class MainPageData
    {
        public string DeparturePlace { get; }
        public string ArrivalPlace { get; }
        public string LeaveDate { get; }
        public string ReturnDate { get; }

        public MainPageData (string departure, string arrival, string leaveDate, string returnDate)
        {
            DeparturePlace = departure;
            ArrivalPlace = arrival;
            LeaveDate = leaveDate;
            ReturnDate = returnDate;
        }        
    }
}
