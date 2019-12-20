
using AirAsiaAutomation.Services;

namespace AirAsiaAutomation.Models
{
    public class GuestDetailsPageData
    {
        public string GivenName;
        public string Surname;
        public string Email;
        public string MobilePhone;

        public GuestDetailsPageData(string name, string surname, string email)
        {
            GivenName = name;
            Surname = surname;
            Email = email;
        }
    }
}
