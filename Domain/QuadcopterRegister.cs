using CityMail.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace City_Mail.Domain
{
    class QuadcopterRegister : Register
    {
        public QuadcopterRegister(int capacity, int reach, string transponderID)
        {
            ID = AutoGeneratID();
            Capacity = capacity;
            Reach = reach;
            RegistrationNumber = transponderID;
        }
        public QuadcopterRegister(string iD, int capacity, int reach, string transponderID)
        {
            ID = iD;
            Capacity = capacity;
            Reach = reach;
            RegistrationNumber = transponderID;
        }

        public QuadcopterRegister(string iD)
        {
            ID = AutoGeneratID();
        }

        //public string RegistrationNumber { get; set; }



        public override string AutoGeneratID()
        {
            int startID = 9000; //It's just for demo else it can change to biger number
            List<int> keysList = new List<int>();

            List<string> readRegisterDataBase = File.ReadAllLines(FilesPath.quadcopterPath).ToList();

            if (readRegisterDataBase.Count == 0)
            {
                return "quad" + startID.ToString();
            }
            else
            {
                foreach (string register in readRegisterDataBase)
                {
                    string[] registerSplit = register.Split(",");
                    string[] registerIDSplit = registerSplit[0].Split("quad", StringSplitOptions.None);
                    keysList.Add(Convert.ToInt32(registerIDSplit[1]));
                }

                if (keysList.Max() == 0)
                {
                    startID = startID + 1;
                }
                else
                {
                    startID = keysList.Max() + 1;
                }
            }

            return "quad" + startID.ToString();
        }


        public static Dictionary<string, QuadcopterRegister> TransferQuadcopterDataBasetoDictionary()
        {
            Dictionary<string, QuadcopterRegister> quadcopterDictionary = new Dictionary<string, QuadcopterRegister>();

            List<string> quadcopterList = File.ReadAllLines(FilesPath.quadcopterPath).ToList();

            foreach (string quadcopter in quadcopterList)
            {
                string[] quadcopterSplit = quadcopter.Split(",");

                QuadcopterRegister quadcopterValue = new QuadcopterRegister(quadcopterSplit[0], int.Parse(quadcopterSplit[1]), int.Parse(quadcopterSplit[2]), quadcopterSplit[3]);

                quadcopterDictionary.Add(quadcopterSplit[0], quadcopterValue);
            }

            return quadcopterDictionary;
        }


        public static void AddQuadcopterRegistrationToDBList(string iD, int capacity, int reach, string transponderID)
        {
            Dictionary<string, QuadcopterRegister> addListToFileDictionary = new Dictionary<string, QuadcopterRegister>();

            QuadcopterRegister addQuadcopterToList = new QuadcopterRegister(iD, capacity, reach, transponderID);

            addListToFileDictionary.Add(iD, addQuadcopterToList);
            File.AppendAllLines(FilesPath.quadcopterPath, addListToFileDictionary.Select(kvp =>
            string.Format($"{kvp.Value.ID}, {kvp.Value.Capacity},{kvp.Value.Reach},{kvp.Value.RegistrationNumber}")));

        }


        public override void ViewRegistrationList()
        {
            Dictionary<string, QuadcopterRegister> quadcopterRegistarion = TransferQuadcopterDataBasetoDictionary();

            if (quadcopterRegistarion.Count == 0)
            {
                Console.WriteLine($@"
             {"",3}{"ID",-8}{"Capacity",-11}{"Reach",-8}{"Registration",-10}
             {"(Quad)",-12}{"(kg)",-9}{"(km)",-11}{"number"}
            ==========================================");
            }
            else
            {
                Console.WriteLine($@"
            {"",3}{"ID",-8}{"Capacity",-11}{"Reach",-8}{"Registration",-10}
             {"(Quad)",-12}{"(kg)",-9}{"(km)",-11}{"number"}
            ==========================================");
                foreach (var register in quadcopterRegistarion.Values)
                {
                    Console.Write($@"
            {register.ID,-11}{register.Capacity,-11}{register.Reach,-8}{register.RegistrationNumber,-11}");
                }
            }
            
        }
    }


}
