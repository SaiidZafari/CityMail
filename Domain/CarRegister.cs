using City_Mail.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace CityMail.Domain
{
    class CarRegister : Register
    {
        
        public CarRegister(int capacity, int reach, string carRegistrationNumber) 
        {            
            ID = AutoGeneratID();
            Capacity = capacity;
            Reach = reach;
            RegistrationNumber = carRegistrationNumber;
        }
        public CarRegister(string iD, int capacity, int reach, string carRegistrationNumber)
        {
            ID = iD;
            Capacity = capacity;
            Reach = reach;
            RegistrationNumber = carRegistrationNumber;
        }

        public CarRegister(string iD)
        {
            ID = AutoGeneratID();
        }

        public CarRegister(int capacity)
        {
            Capacity = capacity;
        }

        //public string RegistrationNumber { get; set; }


        public override string AutoGeneratID()
        {
            int startID = 8000; //It's just for demo else it can change to biger number
            List<int> keysList = new List<int>();

            List<string> readRegisterDataBase = File.ReadAllLines(FilesPath.carPath).ToList();

            if (readRegisterDataBase.Count == 0)
            {
                return "car" + startID.ToString();
            }
            else
            {
                foreach (string register in readRegisterDataBase)
                {
                    string[] registerSplit = register.Split(",");
                    string[] registerIDSplit = registerSplit[0].Split("car", StringSplitOptions.None);
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

            return "car" + startID.ToString();
        }


        public static Dictionary<string, CarRegister> TransferCarDataBasetoDictionary()
        {
            Dictionary<string, CarRegister> carDictionary = new Dictionary<string, CarRegister>();

            List<string> carList = File.ReadAllLines(FilesPath.carPath).ToList();

            foreach (string car in carList)
            {
                string[] carSplit = car.Split(",");

                CarRegister carValue = new CarRegister(carSplit[0], int.Parse(carSplit[1]), int.Parse(carSplit[2]), carSplit[3]);
               
                carDictionary.Add(carSplit[0], carValue);
            }

            return carDictionary;
        }


        public static void AddCarRegistrationToDBList(string iD, int capacity, int reach, string carRegistrationNumber)
        {
            Dictionary<string, CarRegister> addListToFileDictionary = new Dictionary<string, CarRegister>();

            CarRegister addCarToList = new CarRegister(iD, capacity, reach, carRegistrationNumber);

            addListToFileDictionary.Add(iD, addCarToList);
            File.AppendAllLines(FilesPath.carPath, addListToFileDictionary.Select(kvp =>
            string.Format($"{kvp.Value.ID}, {kvp.Value.Capacity},{kvp.Value.Reach},{kvp.Value.RegistrationNumber}")));

        }

       


        public static void ViewCarRegistrationList()
        {
            Dictionary<string, CarRegister> CarRegistarion = TransferCarDataBasetoDictionary();

            if (CarRegistarion.Count == 0)
            {
                Console.WriteLine($@"
            {"",3}{"ID",-9}{"Capacity",-11}{"Reach",-8}{"Registration",-10}
                         {"(kg)"}     {"(km)"}     {"number"}
            ===========================================");
            }
            else
            {
                Console.WriteLine($@"
            {"",3}{"ID",-9}{"Capacity",-11}{"Reach",-8}{"Registration",-10}
                         {"(kg)"}     {"(km)"}     {"number"}
            ===========================================");
            foreach (var register in CarRegistarion.Values)
            {
                Console.Write($@"
            {register.ID,-12}{register.Capacity,-11}{register.Reach,-8}{register.RegistrationNumber,-11}");
            }
            }
            
            
        }
        
        


    }


}
