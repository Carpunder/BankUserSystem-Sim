using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    class User
    {
        private string userType
        {
            get => userType;
            set
            {
                if (value.Equals("Физическое") || value.Equals("Юридическое"))
                    userType = value;
                else
                {
                    throw new ArgumentException("Физическое или Юридическое");
                }
            }
        }
        private string vatin
        {
            get => vatin;
            set
            {
                if (userType == "Физическое" && Regex.IsMatch(value, @"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$"))
                {
                    vatin = value;
                }
                else
                {
                    throw new ArgumentException("Неверный формат");
                }
                if (userType == "Юридическое" &&
                    Regex.IsMatch(value, @"^[0-9]([0-9]|[А-Я])([0-9]|[А-Я])([0-9]|[А-Я])([0-9]|[А-Я])([0-9]|[А-Я])([0-9]|[А-Я])([0-9]|[А-Я])[0-9]$"))
                {
                    vatin = value;
                }
                else
                {
                    throw new ArgumentException("Неверный формат");
                }
            }
        }
        private string login
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
        private string password
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
        private string firstName
        {
            get => firstName;
            set { firstName = value; }
        }
        private string middleName
        {
            get => middleName;
            set { middleName = value; }
        }
        private string lastName
        {
            get => lastName;
            set { lastName = value; }
        }
        private string passport
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
        private string phoneNumber
        {
            get => phoneNumber;
            set
            {
                if (Regex.IsMatch(value, @"^+375(44|25|33|29)[0-9][0-9][0-9][0-9][0-9][0-9][0-9]"))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Неверный формат");
                }
            }

        }
        private double balance
        {
            get => balance;
            set { balance = value; }
        }

        public User(){}

        public User(string userType, string vatin, string login, string password, string passport, string phoneNumber)
        {
            this.userType = userType;
            this.vatin = vatin;
            this.login = login;
            this.password = password;
            this.passport = passport;
            this.phoneNumber = phoneNumber;
        }

        public User(string userType, string vatin, string login, string fio, string password, string passport, string phoneNumber)
        {
            var temp = fio.Split(' ');
            this.userType = userType;
            this.vatin = vatin;
            this.login = login;
            firstName = temp[1];
            middleName = temp[0];
            lastName = temp[2];
            this.password = password;
            this.passport = passport;
            this.phoneNumber = phoneNumber;
        }



    }
}