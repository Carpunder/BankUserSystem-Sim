using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    class Operation
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string type
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
        public double amount
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
            this.type = type;
            this.amount = amount;
        }

    }
}
