using System;

namespace Praktinis3
{
    public class Person
    {
        static public string Name;
        static public string Surname;
        static public string Login;
        static public int Id;
        static public DateTime BDate;
        static public bool Authorized = false, Admin = false, Seller = false;

        public static int GetAge() => (int)((DateTime.Now - BDate).TotalDays / 365);
        public static string GetName() => Name;
        public static string GetSurname() => Surname;
        public static int GetDays()
        {
            DateTime nextBday = new DateTime(DateTime.Now.Year, BDate.Month, BDate.Day);
            if (DateTime.Today > nextBday)
                nextBday = nextBday.AddYears(1);
            return (nextBday - DateTime.Today).Days;

        }
    }
}
