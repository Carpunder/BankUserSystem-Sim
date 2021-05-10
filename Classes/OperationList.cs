using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KursRSPO.Classes
{
    [Serializable]
    public class OperationList
    {
        public List<Operation> Operations;
        public List<Branch> Branches;

        public OperationList()
        {
            Operations = new List<Operation>()
            {
                new(1, "Мобильный телефон")
            };

            Branches = new List<Branch>()
            {
                new ("Мобильный телефон", "Life :)"),
                new ("Мобильный телефон", "МТС"),
                new ("Мобильный телефон", "A1")
            };

        }

        public List<string> GetNameList()
        {
            List<string> list = new List<string>();
            foreach (var VARIABLE in Operations)
            {
                list.Add(VARIABLE.Name);
            }

            return list;
        }

        public List<string> GetBranchList(string parent)
        {
            List<string> list = new List<string>();
            foreach (var VARIABLE in Branches)
            {
                if(VARIABLE.parent == parent)
                    list.Add(VARIABLE.branch);
            }

            return list;
        }

        public static void OperationsXmlWrite(List<Operation> operations)
        {
            XmlSerializer formater = new XmlSerializer(typeof(List<Operation>));
            using (FileStream fs = new FileStream("Operations.xml", FileMode.OpenOrCreate))
            { 
                formater.Serialize(fs, operations);
            }
        }


        public static void BranchXmlWrite(List<Branch> branch)
        {
            XmlSerializer formater = new XmlSerializer(typeof(List<Branch>));
            using (FileStream fs = new FileStream("Branch.xml", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, branch);
            }
        }

        public static List<Operation> OperationsXmlRead()
        {
            List<Operation> temp = new List<Operation>();
            XmlSerializer formater = new XmlSerializer(typeof(List<Operation>));
            using (FileStream fs = new FileStream("Operations.xml", FileMode.Open))
            {
                temp = (List<Operation>)formater.Deserialize(fs);
            }

            return temp;
        }


        public static List<Branch> BranchXmlRead()
        {
            List<Branch> temp;
            XmlSerializer formater = new XmlSerializer(typeof(List<Branch>));
            using (FileStream fs = new FileStream("Branch.xml", FileMode.Open))
            {
                temp = (List<Branch>)formater.Deserialize(fs);
            }

            return temp;
        }

    }
}
