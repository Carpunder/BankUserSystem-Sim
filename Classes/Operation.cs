using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    public class Operation
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string Name
        {
            get => name;
            set { name = value; }
        }
        public string type { get; set; }
        public string Type
        {
            get => type;
            set
            {
                if (value == "Перевод" || value == "Пополнение" || value == "Оплата")
                    type = value;
                else
                {
                    throw new ArgumentException("wrong type of operation");
                }
            }
        }
        public double amount { get; set; }
        public double Amount
        {
            get => amount;
            set
            {
                if (value > 0)
                    amount = value;
                else
                {
                    throw new Exception("value > 0");
                }
            }
        }

        public Operation() {}

        public Operation(int user_id, string name, string type, double amount)
        {
            this.user_id = user_id;
            this.name = name;
            Type = type;
            Amount = amount;
        }

    }
}
