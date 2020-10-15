using CityMail.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;
using System.Security.Cryptography;

namespace City_Mail.Domain
{
    class Register
    {
        
        public string ID { get;  set; }
        public int Capacity { get; set; }
        public int Reach { get;  set; }
        public string RegistrationNumber { get; set; }


        public virtual string AutoGeneratID()
        {
            int startID = 500; //It's just for demo else it can change to biger number
            List<int> keysList = new List<int>();

            List<string> readRegisterDataBase = File.ReadAllLines(FilesPath.registerPath).ToList();

            if (readRegisterDataBase.Count == 0)
            {
                return startID.ToString();
            }
            else
            {
                foreach (string register in readRegisterDataBase)
                {
                    string[] registerSplit = register.Split(",");
                    string[] registerIDSplit = registerSplit[0].Split(" ");
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

            return startID.ToString();
        }

        

        public static void AddCarAndQuadcopterToRegisterDB()
        {

            Dictionary<string, CarRegister> carRegisterDictionary = CarRegister.TransferCarDataBasetoDictionary();

            if (carRegisterDictionary.Count != 0)
            {
                File.WriteAllLines(FilesPath.registerPath, carRegisterDictionary.Select(kvp =>
           string.Format($"{kvp.Value.ID},{kvp.Value.Capacity},{kvp.Value.Reach},{kvp.Value.RegistrationNumber}")));
            }

            Dictionary<string, QuadcopterRegister> QuadcoperRegisterDictionary = QuadcopterRegister.TransferQuadcopterDataBasetoDictionary();
            if (QuadcoperRegisterDictionary.Count != 0)
            {
                File.AppendAllLines(FilesPath.registerPath, QuadcoperRegisterDictionary.Select(kvp =>
            string.Format($"{kvp.Value.ID},{kvp.Value.Capacity},{kvp.Value.Reach},{kvp.Value.RegistrationNumber}")));
            }

        }

        public static Dictionary<string, Register> TransferRegisterDataBasetoDictionary()
        {
            Dictionary<string, Register> registerDictionary = new Dictionary<string, Register>();

            List<string> registerList = File.ReadAllLines(FilesPath.registerPath).ToList();

            foreach (string regiter in registerList)
            {
                string[] regiterSplit = regiter.Split(",");

                Register registerValue = new Register();

                registerValue.ID = regiterSplit[0];
                registerValue.Capacity = int.Parse(regiterSplit[1]);
                registerValue.Reach = int.Parse(regiterSplit[2]);
                registerValue.RegistrationNumber = regiterSplit[3];

                registerDictionary.Add(regiterSplit[0], registerValue);
            }

            return registerDictionary;
        }


        public static void ViewRegistrationListRight()
        {

            Dictionary<int, RegisterPackage> registerPackageDictionary = RegisterPackage.TransferRegisterPackageDataBasetoDictionary();

            if (registerPackageDictionary.ContainsKey(0))
            {
                Console.SetCursorPosition(5, 13);
                Console.WriteLine($@"{"ID",-7}{"Sender",-20}{"Destination",-25}{"Delively",-20} ");
                Console.SetCursorPosition(58, 14);
                Console.WriteLine($"{ "UnitID"}");
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("==============================================================");
            }
            else
            {
                Console.SetCursorPosition(5, 13);
                Console.WriteLine($@"{"ID",-7}{"Sender",-20}{"Destination",-25}{"Delively",-20} ");
                Console.SetCursorPosition(58, 14);
                Console.WriteLine($"{ "UnitID"}");
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("==============================================================");
                int vertical = 17;
                foreach (var registerPackage in registerPackageDictionary.Values)
                {
                    Console.SetCursorPosition(5, vertical);
                    Console.Write($@"{registerPackage.ID,-7}{registerPackage.Sender,-18}{registerPackage.Destination,-15}{registerPackage.RegistrationNumber,20}");
                    vertical++;
                }
            }


            int pos = 17;
            AddCarAndQuadcopterToRegisterDB();
            Dictionary<string, Register> RegisterDictionary = Register.TransferRegisterDataBasetoDictionary();

            if (RegisterDictionary.Count == 0)
            {
                Console.SetCursorPosition(67,13);
                Console.WriteLine($@"{"",3}{"ID",-8}{"Capacity",-11}{"Reach",-8}{"Registration",-10}");
                Console.SetCursorPosition(67, 14);
                Console.WriteLine($"{"(kg)"}     {"(km)"}     {"number"}");
                Console.WriteLine("===========================================");
            }
            else
            {
                Console.SetCursorPosition(70, 13);
                Console.WriteLine($@"{"",3}{"ID",-8}{"Capacity",-11}{"Reach",-8}{"Registration",-10}");
                Console.SetCursorPosition(70, 14);
                Console.WriteLine($"              {"(kg)"}     {"(km)"}     {"number"}");
                Console.SetCursorPosition(70, 15);
                Console.WriteLine("===========================================");
                foreach (var register in RegisterDictionary.Values)
                {
                    Console.SetCursorPosition(70, pos);
                    Console.Write($@" {register.ID,-11}{register.Capacity,-11}{register.Reach,-8}{register.RegistrationNumber,-11}");
                    pos++;
                }
            }

        }

        public static void ViewRegistrationList()
        {
            AddCarAndQuadcopterToRegisterDB();
            Dictionary<string, Register> RegisterDictionary = TransferRegisterDataBasetoDictionary();

            if (RegisterDictionary.Count == 0)
            {
                Console.WriteLine($@"
     {"",7}{"",3}{"ID",-8}{"Capacity",-11}{"Reach",-8}{"Registration",-10}
     {"",7}             {"(kg)"}     {"(km)"}     {"number"}
          
     {"",7}==========================================");
            }
            else
            {
                Console.WriteLine($@"
            {"",3}{"ID",-8}{"Capacity",-11}{"Reach",-8}{"Registration",-10}
                         {"(kg)"}     {"(km)"}     {"number"}
     {"",7}==========================================");
                foreach (var register in RegisterDictionary.Values)
                {
                    Console.Write($@"
      {"",7}{register.ID,-11}{register.Capacity,-11}{register.Reach,-8}{register.RegistrationNumber,-11}");
                }
            }

        }

    }
}
