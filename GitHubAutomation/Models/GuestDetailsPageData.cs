
using AirAsiaAutomation.Services;

namespace AirAsiaAutomation.Models
{
    public class GuestDetailsPageData
    {
        public string GivenName { get; }
        public string Surname { get; }
        public string Email { get; }
        public string MobilePhone { get; }

        public GuestDetailsPageData(string name, string surname, string email)
        {
            GivenName = name;
            Surname = surname;
            Email = email;
        }
    }
}
