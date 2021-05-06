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
        public List<string[]> Branch;

        public OperationList()
        {
            Operations = new List<Operation>();
            Branch = new List<string[]>();
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
            foreach (var VARIABLE in Branch)
            {
                if(VARIABLE[0] == parent)
                    list.Add(VARIABLE[1]);
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


        public static void BranchXmlWrite(List<string[]> branch)
        {
            XmlSerializer formater = new XmlSerializer(typeof(List<string[]>));
            using (FileStream fs = new FileStream("Branch.xml", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, branch);
            }
        }

        public static List<Operation> OperationsXmlRead()
        {
            List<Operation> temp = new List<Operation>();
            XmlSerializer formater = new XmlSerializer(typeof(List<Operation>));
            using (FileStream fs = new FileStream("Operations.xml", FileMode.OpenOrCreate))
            {
                temp = (List<Operation>)formater.Deserialize(fs);
            }

            return temp;
        }


        public static List<string[]> BranchXmlRead()
        {
            List<string[]> temp;
            XmlSerializer formater = new XmlSerializer(typeof(List<string[]>));
            using (FileStream fs = new FileStream("Branch.xml", FileMode.OpenOrCreate))
            {
                temp = (List<string[]>)formater.Deserialize(fs);
            }

            return temp;
        }

    }
}
