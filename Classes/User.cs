using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    [Table("Users")]
    public class User
    {
        public static int userId;
        [Key]
        public int id { get; set; }
        public DateTime registerDate { get; set; }
        public int admin { get; set; }
        public string type;
        public string Type
        {
            get => type;
            set
            {
                if (value.Equals("Физическое") || value.Equals("Юридическое"))
                    type = value;
                else
                {
                    throw new ArgumentException("Физическое или Юридическое");
                }
            }
        }

        public string vatin;
        public string Vatin
        {
            get => vatin;
            set
            {
                if (Regex.IsMatch(value, @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$"))
                {
                    vatin = value;
                }
                else
                {
                    throw new ArgumentException("Неверный формат");
                }
            }
        }

        public string login;
        public string Login
        {
            get => login;
            set
            {
                if (value.Length > 3)
                    login = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }

        public string password;
        public string Password
        {
            get => password;
            set
            {
                if (value.Length > 3)
                    password = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }

        public string firstName;
        public string FirstName
        {
            get => firstName;
            set { firstName = value; }
        }

        public string middleName;
        public string MiddleName
        {
            get => middleName;
            set { middleName = value; }
        }

        public string lastName;
        public string LastName
        {
            get => lastName;
            set { lastName = value; }
        }

        public string passport;
        public string Passport
        {
            get => passport;
            set
            {
                if (Regex.IsMatch(value,
                    @"^[1-6]([0][1-9]|[[1-2][0-9]|[3][0-1]])([0][1-9]|[1][0-2])([0-9][0-9])(A|B|C|K|E|M|H)[0-9][0-9][0-9](PB|BA|BI)[0-9]$"))
                {
                    passport = value;
                }
                else
                {
                    throw new ArgumentException("Неверный формат");
                }
            }
        }

        public string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (Regex.IsMatch(value, @"(44|25|33|29)[0-9][0-9][0-9][0-9][0-9][0-9][0-9]$"))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Неверный формат");
                }
            }

        }

        public double balance;
        public double Balance
        {
            get => balance;
            set { balance = value; }
        }

        public User(){}

        public User(string userType, string vatin, string login, string password, string passport, string phoneNumber)
        {
            Type = userType;
            Vatin = vatin;
            Login= login;
            Password = password;
            Passport = passport;
            PhoneNumber = phoneNumber;
            registerDate = DateTime.UtcNow;
        }

    }
}