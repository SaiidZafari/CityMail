using CityMail.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace City_Mail.Domain
{
    class RegisterPackage : Register
    {
        public RegisterPackage(int iD, string sender, string destination, string status, string vehicleID, DateTime registerDate, DateTime deliveryDate)
        {
            ID = iD;
            Sender = sender;
            Destination = destination;
            Status = status;
            RegistrationNumber = vehicleID;
            RegisterDate = registerDate;
            DeliveryDate = deliveryDate;
        }


        public new int ID { get; } = AutoGeneratID();
        public string Sender { get; }
        public string Destination { get; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; }
        public DateTime DeliveryDate { get; }


        public static void StatusCalculation()
        {

            string status = string.Empty;
            Dictionary<int, RegisterPackage> registerPackageDictionary = TransferRegisterPackageDataBasetoDictionary();

            foreach (var package in registerPackageDictionary.Values)
            {

                DateTime dateNow = DateTime.Now;
                DateTime dateDelivery = package.DeliveryDate;

                TimeSpan difference = dateDelivery - dateNow;

                if (difference.Minutes <= 0)
                {
                    status = "Delivered";
                }
                else if (difference.Minutes > 0)
                {
                    status = $"{difference.Minutes } min to Delivery";
                }
                else
                {
                    status = "Comming soon";
                }

                package.Status = status;
            }

            File.WriteAllLines(FilesPath.registerPackagePath, registerPackageDictionary.Select(kvp =>
                        string.Format($"{kvp.Value.ID},{kvp.Value.Sender},{kvp.Value.Destination},{kvp.Value.Status},{kvp.Value.RegistrationNumber},{kvp.Value.RegisterDate},{kvp.Value.DeliveryDate}")));
        }


        public static new int AutoGeneratID()
        {
            int startID = 1000; //It's just for demo else it can change to biger number
            List<int> keysList = new List<int>();

            List<string> readRegisterPackageDataBase = File.ReadAllLines(FilesPath.registerPackagePath).ToList();

            if (readRegisterPackageDataBase.Count == 0)
            {
                return startID;
            }
            else
            {
                foreach (string regiterPackage in readRegisterPackageDataBase)
                {
                    string[] regiterPackageSplit = regiterPackage.Split(",");
                    keysList.Add(Convert.ToInt32(regiterPackageSplit[0]));
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

            return startID;
        }


        public static Dictionary<int, RegisterPackage> TransferRegisterPackageDataBasetoDictionary()
        {
            Register register = new Register();

            Dictionary<int, RegisterPackage> registerPackageDictionary = new Dictionary<int, RegisterPackage>();

            List<string> registerPackageList = File.ReadAllLines(FilesPath.registerPackagePath).ToList();

            foreach (string regiterPackage in registerPackageList)
            {
                string[] regiterSplit = regiterPackage.Split(",");

                RegisterPackage registerValue = new RegisterPackage(int.Parse(regiterSplit[0]), regiterSplit[1], regiterSplit[2], regiterSplit[3], regiterSplit[4], Convert.ToDateTime(regiterSplit[5]), Convert.ToDateTime(regiterSplit[6]));

                registerPackageDictionary.Add(int.Parse(regiterSplit[0]), registerValue);
            }

            return registerPackageDictionary;
        }


        public static void ViewStartDeliveryManagmentList()
        {
            //TransferRegisterPackageDataBasetoDictionary();
            Dictionary<int, RegisterPackage> registerPackageDictionary = TransferRegisterPackageDataBasetoDictionary();

            if (registerPackageDictionary.ContainsKey(0))
            {
                Console.WriteLine($@"
        {"ID",-7}{"Sender",-20}{"Destination",-30} {"VehicleID",-20}                       
        ==============================================================");
            }
            else
            {
                Console.WriteLine($@"
        {"ID",-7}{"Sender",-20}{"Destination",-30}                        
        ==============================================================");
                foreach (var registerPackage in registerPackageDictionary.Values)
                {
                    Console.Write($@"
        {registerPackage.ID,-7}{registerPackage.Sender,-20}{registerPackage.Destination,-30}{registerPackage.RegistrationNumber,-20}");
                }
            }


        }

        public static void ViewPackageList()
        {
            StatusCalculation();
            Dictionary<int, RegisterPackage> registerPackageDictionary = TransferRegisterPackageDataBasetoDictionary();

            if (registerPackageDictionary.Count == 0)
            {
                Console.WriteLine($@"
        {"ID",-7}{"Destination",-25}{"Status",-20}
        ==================================================");
            }
            else
            {
                Console.WriteLine($@"
        {"ID",-7}{"Destination",-25}{"Status",-20}
        ==================================================");
                foreach (var registerPackage in registerPackageDictionary.Values)
                {
                    Console.Write($@"
        {registerPackage.ID,-7}{registerPackage.Destination,-25}{registerPackage.Status,-20}");
                }
            }


        }


        public static void ViewRegistrationStatusList()
        {
            StatusCalculation();
            Dictionary<int, RegisterPackage> registerPackageDictionary = TransferRegisterPackageDataBasetoDictionary();

            if (registerPackageDictionary.Count == 0)
            {
                Console.WriteLine($@"
        {"ID",-7}{"Sender",-25}{"Destination",-25}{"Status",-20}{"Registration",-15}{"Delivery",-15}{"Delivery.",-15}
        {"date",85}{"date",15}{"Unit ID"}
        ========================================================================================================");
            }
            else
            {
                Console.WriteLine($@"
        {"ID",-7}{"Sender",-15}{"Destination",-22}{"Status",-20}{"Registration",-15}{"Delivery",-15}{"Delivery",-15}
        {"date",72}{"date",13}{"Unit ID",16}
        ========================================================================================================");
                foreach (var registerPackage in registerPackageDictionary.Values)
                {
                    Console.Write($@"
        {registerPackage.ID,-7}{registerPackage.Sender,-15}{registerPackage.Destination,-20}{registerPackage.Status,-22}{Convert.ToDateTime(registerPackage.RegisterDate),-15:ddd HH:mm}{registerPackage.DeliveryDate,-15: ddd HH:mm}{registerPackage.RegistrationNumber}");
                }
            }


        }


    }
}
