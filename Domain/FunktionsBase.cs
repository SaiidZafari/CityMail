using CityMail.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace City_Mail.Domain
{
    class FunktionsBase
    {

        public static bool CaseOneOneAddCar()
        {
            string answer = string.Empty;
            bool doAgain = false;
            bool doExit = false;
            string carID = string.Empty;
            Register carRegister = new CarRegister(carID);

            do
            {
                Dictionary<string, CarRegister> carDictionary = CarRegister.TransferCarDataBasetoDictionary();
                Console.Clear();
                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Car Register <<",42} ");
                Console.SetCursorPosition(0, 5);
                Console.WriteLine($@"
                        ID :                            Capacity (kg) :

        Registration Number:                               Reach (km) : 
            ABC123 / ABC12D   ");

                Console.SetCursorPosition(90, 24);
                Console.WriteLine($" {"To exit write ZZZ000"}");

                Console.SetCursorPosition(0, 15);
                carRegister.ViewRegistrationList();

                //string carID = string.Empty;
                //Register register = new CarRegister(carID);
                Console.SetCursorPosition(29, 6);
                Console.WriteLine($"{carRegister.AutoGeneratID()}");

                Regex registrationNumberRegex = new Regex(@"[a-zA-Z][a-zA-Z][a-zA-Z][0-9][0-9][0-9a-zA-Z]$");
                string registrationNumber = string.Empty;
                do
                {
                    Console.SetCursorPosition(29, 8);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(29, 8);
                    registrationNumber = Console.ReadLine().ToUpper();
                    Console.SetCursorPosition(29, 8);
                    Console.WriteLine($"{registrationNumber}");

                    foreach (var carValue in carDictionary.Values)
                    {
                        if (carValue.RegistrationNumber != registrationNumber)
                        {
                            continue;

                        }
                        else
                        {
                            Console.SetCursorPosition(20, 11);
                            Console.WriteLine("This transponder ID is already registered!");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(20, 11);
                            Console.WriteLine("                                             ");
                            registrationNumber = "WrongID";
                        }

                    }
                } while (!registrationNumberRegex.IsMatch(registrationNumber));

                if (registrationNumber == "ZZZ000")
                {

                    doAgain = false;
                }
                else
                {
                    doExit = true;
                }


                while (doExit)
                {

                    int capacity = CapacityInput(72, 6);

                    int reach = ReachInput(72, 8);

                    Console.SetCursorPosition(8, 13);
                    Console.Write($"Would you confirm the information above? Y/N : ");
                    answer = Console.ReadKey().KeyChar.ToString();
                    Console.SetCursorPosition(8, 13);
                    Console.Write("                                                  ");
                    if (answer.ToUpper() == "Y")
                    {
                        CarRegister.AddCarRegistrationToDBList(carRegister.AutoGeneratID(), capacity, reach, registrationNumber);
                        //CarRegister.AddCarRegistrationToDBList(carID, capacity, reach, registrationNumber);
                        Console.SetCursorPosition(0, 15);
                        carRegister.ViewRegistrationList();

                        Console.SetCursorPosition(8, 13);
                        Console.Write("Delivery unit registered !");
                        Thread.Sleep(2000);

                        doExit = false;
                        doAgain = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(8, 13);
                        Console.Write($"Do you wish to add a car? Y/N : ");
                        answer = Console.ReadKey().KeyChar.ToString().ToUpper();
                        Console.SetCursorPosition(8, 13);
                        Console.Write("                                       ");

                        if (answer == "Y")
                        {
                            doAgain = true;
                            doExit = false;
                        }
                        else { doAgain = false; }
                    }
                }

            } while (doAgain);

            return true;
        }

        public static bool CaseOneOneAddQuadcopter()
        {
            string answer = string.Empty;
            bool doAgain = false;
            bool doExit = false;
            string iD = string.Empty;
            Register quadcopterRegister = new QuadcopterRegister(iD);
            do
            {
                Dictionary<string, QuadcopterRegister> quadcopterDictionary = QuadcopterRegister.TransferQuadcopterDataBasetoDictionary();
                Console.Clear();
                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Quadcopter Register <<",45} ");
                Console.SetCursorPosition(0, 5);
                Console.WriteLine($@"
                        ID :                            Capacity (kg) :

            Transponder ID :                               Reach (km) : 
                    A12B34   ");

                Console.SetCursorPosition(90, 24);
                Console.WriteLine($" {"To exit write Z00Z00"}");

                Console.SetCursorPosition(0, 15);
                quadcopterRegister.ViewRegistrationList();

                string quadcopterID = string.Empty;
                Register register = new QuadcopterRegister(quadcopterID);
                Console.SetCursorPosition(29, 6);
                Console.WriteLine($"{register.AutoGeneratID()}");

                Regex registrationNumberRegex = new Regex(@"[a-zA-Z][0-9][0-9][a-zA-Z][0-9][0-9]$");
                string transponderID = string.Empty;
                do
                {
                    Console.SetCursorPosition(29, 8);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(29, 8);
                    transponderID = Console.ReadLine().ToUpper();
                    Console.SetCursorPosition(29, 8);
                    Console.WriteLine(transponderID);
                    foreach (var quadcopterValue in quadcopterDictionary.Values)
                    {
                        if (quadcopterValue.RegistrationNumber == transponderID)
                        {
                            Console.SetCursorPosition(20, 11);
                            Console.WriteLine("This transponder ID is already registered!");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(20, 11);
                            Console.WriteLine("                                             ");
                            transponderID = "WrongID";
                        }

                    }

                } while (!registrationNumberRegex.IsMatch(transponderID));

                if (transponderID == "Z00Z00")
                {

                    doAgain = false;
                }
                else
                {
                    doExit = true;
                }


                while (doExit)
                {


                    int capacity = CapacityInput(72, 6);

                    int reach = ReachInput(72, 8);

                    Console.SetCursorPosition(8, 13);
                    Console.Write($"Would you confirm the information above? Y/N : ");
                    answer = Console.ReadKey().KeyChar.ToString();
                    Console.SetCursorPosition(8, 13);
                    Console.Write("                                                  ");
                    if (answer.ToUpper() == "Y")
                    {
                        QuadcopterRegister.AddQuadcopterRegistrationToDBList(register.AutoGeneratID(), capacity, reach, transponderID);
                        Console.SetCursorPosition(0, 15);
                        quadcopterRegister.ViewRegistrationList();

                        Console.SetCursorPosition(8, 13);
                        Console.Write("Delivery unit registered !");
                        Thread.Sleep(2000);

                        doExit = false;
                        doAgain = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(8, 13);
                        Console.Write($"Do you wish to add a quadcopter? Y/N : ");
                        answer = Console.ReadKey().KeyChar.ToString().ToUpper();
                        Console.SetCursorPosition(8, 13);
                        Console.Write("                                       ");

                        if (answer == "Y")
                        {
                            doAgain = true;
                            doExit = false;
                        }
                        else { doAgain = false; }
                    }
                }

            } while (doAgain);

            return true;
        }


        // Search for any registared 

        /// <summary>
        /// This Method will find Item with enter of ID 
        /// Furthermore you will get possiblity to Edit and Delete the Item
        /// </summary>
        public static void CaseOneSearch()
        {

            bool toExit = false;
            bool moreChange = false;
            Register register = new Register();
            do
            {
                Dictionary<string, Register> regiterDictionary = Register.TransferRegisterDataBasetoDictionary();
                Dictionary<string, CarRegister> carRegiterDictionary = CarRegister.TransferCarDataBasetoDictionary();
                Dictionary<string, QuadcopterRegister> quadcopterRegiterDictionary = QuadcopterRegister.TransferQuadcopterDataBasetoDictionary();
                Dictionary<int, RegisterPackage> deleteControlDictionery = RegisterPackage.TransferRegisterPackageDataBasetoDictionary();

                Console.Clear();
                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Search Register <<",43} ");

                Console.SetCursorPosition(0, 4);
                Console.WriteLine($@" 
        Please Enter ID of the Item you wish to find : 
                              car(8)123 / quad(9)123 ");

                Console.SetCursorPosition(0, 10);
                register.ViewRegistrationList();

                Console.SetCursorPosition(90, 24);
                Console.WriteLine("Enter (car9999) to Exit");

                Regex clientIDRegex = new Regex(@"^(car|quad)[8-9][0-9][0-9][0-9]$");
                string clientID = string.Empty;

                do
                {
                    regiterDictionary = Register.TransferRegisterDataBasetoDictionary();
                    carRegiterDictionary = CarRegister.TransferCarDataBasetoDictionary();
                    quadcopterRegiterDictionary = QuadcopterRegister.TransferQuadcopterDataBasetoDictionary();

                    Console.SetCursorPosition(55, 5);
                    Console.WriteLine("                           ");
                    Console.SetCursorPosition(55, 5);
                    clientID = Console.ReadLine().ToLower();
                    
                } while (!clientIDRegex.IsMatch(clientID));

                if (clientID == "car9999") { toExit = false; }

                else if (regiterDictionary.ContainsKey(clientID))
                {
                    Console.SetCursorPosition(90, 24);
                    Console.WriteLine("                           ");
                    Console.SetCursorPosition(70, 5);
                    Console.Write($@" Your insert Id fund in system!");
                    Console.SetCursorPosition(70, 9);
                    Console.Write($@" {"ID :",22} {regiterDictionary[clientID].ID,-10}");
                    Console.SetCursorPosition(70, 11);
                    Console.Write($@" {"Capacity :",22} {regiterDictionary[clientID].Capacity,-7}{"kg"}");
                    Console.SetCursorPosition(70, 13);
                    Console.Write($@" {"Reach :",22} {regiterDictionary[clientID].Reach,-7}{"km"}");
                    Console.SetCursorPosition(70, 15);
                    Console.Write($@" {"Registration Number :",22} {regiterDictionary[clientID].RegistrationNumber,-10}");

                    int options = Options("1. Edit", "2. Delete", "3. Exit");
                    Option option = (Option)options;

                    switch (option)
                    {
                        case Option.Edit:

                            do
                            {
                                int editOptions = Options("1.Capacity", "2.Reach", "");
                                EditOption editOption = (EditOption)editOptions;
                                switch (editOption)
                                {
                                    case EditOption.Capacity:
                                        int newCapacity = CapacityInput(94, 11);

                                        if (carRegiterDictionary.ContainsKey(clientID))
                                        {
                                            carRegiterDictionary[clientID].Capacity = newCapacity;

                                            WriteAllCarDictionaryToFile(carRegiterDictionary);
                                        }
                                        else
                                        {
                                            quadcopterRegiterDictionary[clientID].Capacity = newCapacity;

                                            WriteAllQuadDictionaryToFile(quadcopterRegiterDictionary);
                                        }
                                        break;
                                    case EditOption.Reach:
                                        int newReach = ReachInput(94, 13);
                                        if (carRegiterDictionary.ContainsKey(clientID))
                                        {
                                            carRegiterDictionary[clientID].Reach = newReach;
                                            WriteAllCarDictionaryToFile(carRegiterDictionary);
                                        }
                                        else
                                        {
                                            quadcopterRegiterDictionary[clientID].Reach = newReach;
                                            WriteAllQuadDictionaryToFile(quadcopterRegiterDictionary);
                                        }
                                        break;
                                }

                                Console.SetCursorPosition(70, 18);
                                Console.WriteLine("                                             ");
                                Console.SetCursorPosition(70, 18);
                                Console.Write("Do you want to make more changes? Y/N : ");

                                Regex yesOrNoRegex = new Regex(@"[YN]$");
                                string answer = string.Empty;
                                do
                                {
                                    answer = Console.ReadKey().KeyChar.ToString();

                                } while (!yesOrNoRegex.IsMatch(answer.ToUpper()));

                                Console.SetCursorPosition(70, 18);
                                Console.WriteLine("                                             ");

                                if (answer.ToUpper() == "Y")
                                {
                                    moreChange = true;
                                }
                                else
                                {
                                    moreChange = false;
                                }

                                toExit = true;
                            } while (moreChange);

                            break;

                        case Option.Delete:         // delete function control

                            bool vehicleExist = false;

                            foreach (var vehicle in deleteControlDictionery.Values)
                            {
                                if (vehicle.RegistrationNumber == clientID)
                                {
                                    Console.SetCursorPosition(70, 18);
                                    Console.WriteLine("                                             ");
                                    Console.SetCursorPosition(70, 18);
                                    Console.WriteLine(" STOP! This vehicle is under production.");
                                    Thread.Sleep(3000);
                                    vehicleExist = true;
                                }
                                else { continue; }
                            }

                            if (vehicleExist)
                            {

                                toExit = true;
                                break;
                            }

                            Console.SetCursorPosition(70, 18);
                            Console.WriteLine("                                             ");
                            Console.SetCursorPosition(70, 18);
                            Console.Write("Are you sue you want to delete this? Y/N : ");

                            Regex yOrNRegex = new Regex(@"[YN]$");
                            string answers = string.Empty;
                            do
                            {
                                answers = Console.ReadKey().KeyChar.ToString();

                            } while (!yOrNRegex.IsMatch(answers.ToUpper()));

                            if (answers.ToUpper() == "Y")
                            {
                                Console.SetCursorPosition(70, 18);
                                Console.WriteLine("                                             ");

                                if (carRegiterDictionary.ContainsKey(clientID))
                                {
                                    carRegiterDictionary.Remove(clientID);

                                    WriteAllCarDictionaryToFile(carRegiterDictionary);
                                }
                                else
                                {
                                    quadcopterRegiterDictionary.Remove(clientID);

                                    WriteAllQuadDictionaryToFile(quadcopterRegiterDictionary);
                                }
                            }
                            
                            toExit = true;
                            break;
                        case Option.Exit:
                            break;
                        default:
                            break;
                    }


                }
                else
                {
                    Console.SetCursorPosition(70, 5);
                    Console.Write(" Your insert ID didin't fund in system!");
                    Thread.Sleep(2000);
                    toExit = true;
                }

            } while (toExit);



            //Console.ReadLine();
        }

        private static void WriteAllCarDictionaryToFile(Dictionary<string, CarRegister> carRegiterDictionary)
        {
            File.WriteAllLines(FilesPath.carPath, carRegiterDictionary.Select(kvp => string.Format($@"{kvp.Value.ID},{kvp.Value.Capacity},{kvp.Value.Reach},{kvp.Value.RegistrationNumber}")));
        }

        private static void WriteAllQuadDictionaryToFile(Dictionary<string, QuadcopterRegister> quadcopterRegiterDictionary)
        {
            File.WriteAllLines(FilesPath.quadcopterPath, quadcopterRegiterDictionary.Select(kvp => string.Format($@"{kvp.Value.ID},{kvp.Value.Capacity},{kvp.Value.Reach},{kvp.Value.RegistrationNumber}")));
        }


        /// <summary>
        /// Reciving input for Capacity and set position where you need it to be
        /// </summary>
        /// <param name="positionH"></param>
        /// <param name="positopnV"></param>
        /// <returns></returns>
        public static int CapacityInput(int positionH, int positopnV)
        {
            Regex capacityRegex = new Regex(@"(\d*)\d$");
            string capacityString = string.Empty;
            do
            {
                Console.SetCursorPosition(positionH, positopnV);
                Console.WriteLine("                ");
                Console.SetCursorPosition(positionH, positopnV);
                capacityString = Console.ReadLine();
            } while (!capacityRegex.IsMatch(capacityString));
            Console.SetCursorPosition(positionH, positopnV);
            Console.WriteLine($"{capacityString,-5}  kg");
            int capacity = int.Parse(capacityString);
            return capacity;
        }


        /// <summary>
        /// Reciving input for Reeach and set position where you need it to be
        /// </summary>
        /// <param name="positionH"></param>
        /// <param name="positopnV"></param>
        /// <returns></returns>
        public static int ReachInput(int positionH, int positopnV)
        {
            Regex reachRegex = new Regex(@"(\d*)\d$");
            string reachString = string.Empty;
            do
            {
                Console.SetCursorPosition(positionH, positopnV);
                Console.WriteLine("                ");
                Console.SetCursorPosition(positionH, positopnV);
                reachString = Console.ReadLine();
            } while (!reachRegex.IsMatch(reachString));
            Console.SetCursorPosition(positionH, positopnV);
            Console.WriteLine($"{reachString,-5}  km");
            int reach = int.Parse(reachString);

            return reach;
        }

        /// <summary>
        /// This method used to offer several option to client and return the option 
        /// </summary>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        /// <param name="option3"></param>
        /// <returns></returns>
        public static int Options(string option1, string option2, string option3)
        {
            Console.SetCursorPosition(70, 20);
            Console.Write($@" {"You can choose one of these options below : "} ");
            Console.SetCursorPosition(70, 22);
            Console.Write($@" {option1,-11} {option2,-12} {option3,-10}");

            Regex clientOptionRegex = new Regex(@"[1-3]");
            string clientOption = string.Empty;
            do
            {
                Console.SetCursorPosition(115, 20);
                Console.WriteLine("   ");
                Console.SetCursorPosition(115, 20);
                clientOption = Console.ReadKey().KeyChar.ToString();
            } while (!clientOptionRegex.IsMatch(clientOption));
            int option = int.Parse(clientOption) - 1;

            return option;
        }
        /// <summary>
        /// This Method Cover Regiter Package with function for Delete and Exit
        /// </summary>
        public static void RegistrerPackage()
        {
            bool doAgain = false;
            string status = "Comming Soon";
            do
            {
                Dictionary<string, Register> regiterDictionary = Register.TransferRegisterDataBasetoDictionary();
                Dictionary<int, RegisterPackage> packageToDeleteDictionary = RegisterPackage.TransferRegisterPackageDataBasetoDictionary();
                Console.Clear();
                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Register Package <<",45} ");

                Console.SetCursorPosition(7, 3);
                Console.WriteLine($"{"1.Registar",-12}{"2.Delete",-10}{"3.Exit",-8}");
                Console.SetCursorPosition(7, 4);
                Console.WriteLine("Please choose one of these options above:");

                Register.ViewRegistrationListRight();


                Regex optionRegex = new Regex(@"[1-3]$");
                string option = string.Empty;
                do
                {
                    Console.SetCursorPosition(49, 4);
                    Console.WriteLine("             ");
                    Console.SetCursorPosition(49, 4);
                    option = Console.ReadKey().KeyChar.ToString();
                } while (!optionRegex.IsMatch(option));

                if (option == "3")
                {
                    break;
                }

                else if (option == "2")
                {
                    Console.SetCursorPosition(7, 8);
                    Console.Write("Please enter ID you wish to Delete: ");

                    Regex deleteIDRegex = new Regex(@"[1][0-9][0-9][0-9]$");
                    string deleteID = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(43, 8);
                        Console.WriteLine("                ");
                        Console.SetCursorPosition(43, 8);
                        deleteID = Console.ReadLine();
                        if (!packageToDeleteDictionary.ContainsKey(int.Parse(deleteID)))
                        {
                            Console.SetCursorPosition(7, 9);
                            Console.Write($"This ID {deleteID} Is not onthe List !");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(7, 9);
                            Console.Write($"                                        ");
                            deleteID = "xxxx";
                        }
                    } while (!deleteIDRegex.IsMatch(deleteID));

                    Console.SetCursorPosition(7, 9);
                    Console.Write($"Would you confirm Delete ID number: {deleteID}? Y/N : ");

                    Regex answersRegex = new Regex(@"[YN]$");
                    string answers = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(55, 9);
                        Console.WriteLine("           ");
                        Console.SetCursorPosition(55, 9);
                        answers = Console.ReadLine().ToUpper();
                    } while (!answersRegex.IsMatch(answers));
                    if (answers == "Y")
                    {
                        packageToDeleteDictionary.Remove(int.Parse(deleteID));

                        SaveToRegiterPackageFile(packageToDeleteDictionary);                        

                        Console.SetCursorPosition(7, 10);
                        Console.Write($"ID number: {deleteID} deleted !                                   ");
                        Thread.Sleep(2000);
                        doAgain = true;
                    }
                    else
                    {
                        doAgain = true;
                    }

                }

                else
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine($@"
                      Sender:  

                 Destination: 

             Delivery UnitID:     ");



                    int packageID = RegisterPackage.AutoGeneratID();

                    Regex nameRegex = new Regex(@"^[a-zA-Z]\w+\s[a-zA-Z]\w+$");
                    string name = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(30, 6);
                        Console.WriteLine("                               ");
                        Console.SetCursorPosition(30, 6);
                        name = Console.ReadLine();
                    } while (!nameRegex.IsMatch(name));

                    var nameArray = name.Split();
                    nameArray[0] = nameArray[0].Substring(0, 1).ToUpper() + nameArray[0].Substring(1, nameArray[0].Length - 1).ToLower();
                    nameArray[1] = nameArray[1].Substring(0, 1).ToUpper() + nameArray[1].Substring(1, nameArray[1].Length - 1).ToLower();

                    name = nameArray[0] + " " + nameArray[1];
                    Console.SetCursorPosition(30, 6);
                    Console.WriteLine(name);


                    Regex distinationRegex = new Regex(@"^[a-zA-Z].+");
                    string distination = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(30, 8);
                        Console.WriteLine("                                                ");
                        Console.SetCursorPosition(30, 8);
                        distination = Console.ReadLine();
                    } while (!distinationRegex.IsMatch(distination));

                    Regex clientIDRegex = new Regex(@"^(car|quad)[8-9][0-9][0-9][0-9]$");
                    string deliveryUnitID = string.Empty;

                    do
                    {
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine("                                                             ");
                        Console.SetCursorPosition(30, 10);
                        deliveryUnitID = Console.ReadLine().ToLower();
                        if (!regiterDictionary.ContainsKey(deliveryUnitID))
                        {
                            Console.SetCursorPosition(30, 10);
                            Console.WriteLine("Wrong UnitID! Please try again...");
                            Thread.Sleep(2000);
                            deliveryUnitID = "Wrong Unit";
                        }
                    } while (!clientIDRegex.IsMatch(deliveryUnitID));


                    Console.SetCursorPosition(10, 11);
                    Console.Write("Will you verify the information above ? Y/N :");

                    Regex answerRegex = new Regex(@"[YN]$");
                    string answer = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(57, 11);
                        Console.WriteLine("           ");
                        Console.SetCursorPosition(57, 11);
                        answer = Console.ReadLine().ToUpper();
                    } while (!answerRegex.IsMatch(answer));
                    Console.SetCursorPosition(10, 11);
                    Console.Write("                                                  ");
                    if (answer == "Y")
                    {
                        DateTime date1 = DateTime.Now;
                        DateTime date2 = DateTime.Now.AddHours(6);
                        //string status = RegisterPackage.StatusCalculation();
                        status = "Commin Soon";
                        



                        Dictionary<int, RegisterPackage> registerPackageDeictionary = new Dictionary<int, RegisterPackage>();
                        RegisterPackage registerPackage = new RegisterPackage(packageID, name, distination, status, deliveryUnitID, date1, date2);
                        registerPackageDeictionary.Add(packageID, registerPackage);

                        File.AppendAllLines(FilesPath.registerPackagePath, registerPackageDeictionary.Select(kvp =>
                        string.Format($"{kvp.Value.ID},{kvp.Value.Sender},{kvp.Value.Destination},{kvp.Value.Status},{kvp.Value.RegistrationNumber},{kvp.Value.RegisterDate},{kvp.Value.DeliveryDate}")));
                        Console.SetCursorPosition(10, 11);
                        Console.Write("Package registered");
                        Thread.Sleep(2000);
                        doAgain = true;

                    }
                    else
                    {
                        doAgain = true;
                    }
                }
                Console.SetCursorPosition(0, 14);
                RegisterPackage.ViewStartDeliveryManagmentList();


            } while (doAgain);

        }


        public static void ListPackage()
        {
            bool doAgain = false;

            do
            {
                Dictionary<int, RegisterPackage> packageToDeleteDictionary = RegisterPackage.TransferRegisterPackageDataBasetoDictionary();
                Console.Clear();
                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> List Package <<",41} ");

                Console.SetCursorPosition(7, 4);
                //Console.WriteLine($"{"1.Edit",-12}{"2.Delete",-15}{"3.Exit",-8}");
                Console.WriteLine($"{"1.Delete",-15}{"2.Exit",-8}");
                Console.SetCursorPosition(7, 5);
                Console.WriteLine("Please choose one of these options above:");


                Console.SetCursorPosition(0, 11);
                //RegisterPackage.ViewRegistrationStatusList();
                RegisterPackage.ViewPackageList();



                Regex optionRegex = new Regex(@"[1-3]");
                string option = string.Empty;
                do
                {
                    Console.SetCursorPosition(49, 5);
                    Console.WriteLine("             ");
                    Console.SetCursorPosition(49, 5);
                    option = Console.ReadKey().KeyChar.ToString();
                } while (!optionRegex.IsMatch(option));

                if (option == "2")
                {
                    break;
                }

                else if (option == "1")
                {
                    Console.SetCursorPosition(7, 8);
                    Console.Write("Please enter ID you wish to Delete: ");

                    Regex deleteIDRegex = new Regex(@"[1][0-9][0-9][0-9]$");
                    string deleteID = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(43, 8);
                        Console.WriteLine("                ");
                        Console.SetCursorPosition(43, 8);
                        deleteID = Console.ReadLine();
                        if (!packageToDeleteDictionary.ContainsKey(int.Parse(deleteID)))
                        {
                            Console.SetCursorPosition(7, 9);
                            Console.Write($"This ID {deleteID} Is not onthe List !");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(7, 9);
                            Console.Write($"                                        ");
                            deleteID = "xxxx";
                        }
                    } while (!deleteIDRegex.IsMatch(deleteID));

                    Console.SetCursorPosition(7, 9);
                    Console.Write($"Would you confirm Delete ID number: {deleteID}? Y/N : ");

                    Regex answersRegex = new Regex(@"[YN]");
                    string answers = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(55, 9);
                        Console.WriteLine("           ");
                        Console.SetCursorPosition(55, 9);
                        answers = Console.ReadLine().ToUpper();
                    } while (!answersRegex.IsMatch(answers));
                    if (answers == "Y")
                    {
                        packageToDeleteDictionary.Remove(int.Parse(deleteID));

                        SaveToRegiterPackageFile(packageToDeleteDictionary);
                        
                        Console.SetCursorPosition(7, 10);
                        Console.Write($"ID number: {deleteID} deleted !                                   ");
                        Thread.Sleep(2000);
                        doAgain = true;
                    }
                    else
                    {
                        doAgain = true;
                    }

                }

                Console.SetCursorPosition(0, 14);
                RegisterPackage.ViewStartDeliveryManagmentList();


            } while (doAgain);
        }


        public static void StartDeliveryPackages()
        {
            bool doAgain = false;

            do
            {
                Dictionary<int, RegisterPackage> packageToDeleteDictionary = RegisterPackage.TransferRegisterPackageDataBasetoDictionary();
                Console.Clear();
                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Package Management <<",45} ");

                Console.SetCursorPosition(7, 4);
                //Console.WriteLine($"{"1.Edit",-12}{"2.Delete",-15}{"3.Exit",-8}");
                Console.WriteLine($"{"1.Delete",-15}{"2.Exit",-8}");
                Console.SetCursorPosition(7, 5);
                Console.WriteLine("Please choose one of these options above:");


                Console.SetCursorPosition(0, 11);
                RegisterPackage.ViewRegistrationStatusList();




                Regex optionRegex = new Regex(@"[1-3]");
                string option = string.Empty;
                do
                {
                    Console.SetCursorPosition(49, 5);
                    Console.WriteLine("             ");
                    Console.SetCursorPosition(49, 5);
                    option = Console.ReadKey().KeyChar.ToString();
                } while (!optionRegex.IsMatch(option));

                if (option == "2")
                {
                    break;
                }

                else if (option == "1")
                {
                    Console.SetCursorPosition(7, 8);
                    Console.Write("Please enter ID you wish to Delete: ");

                    Regex deleteIDRegex = new Regex(@"[1][0-9][0-9][0-9]$");
                    string deleteID = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(43, 8);
                        Console.WriteLine("                ");
                        Console.SetCursorPosition(43, 8);
                        deleteID = Console.ReadLine();
                        if (!packageToDeleteDictionary.ContainsKey(int.Parse(deleteID)))
                        {
                            Console.SetCursorPosition(7, 9);
                            Console.Write($"This ID {deleteID} Is not onthe List !");
                            Thread.Sleep(2000);
                            Console.SetCursorPosition(7, 9);
                            Console.Write($"                                        ");
                            deleteID = "xxxx";
                        }
                    } while (!deleteIDRegex.IsMatch(deleteID));

                    Console.SetCursorPosition(7, 9);
                    Console.Write($"Would you confirm Delete ID number: {deleteID}? Y/N : ");

                    Regex answersRegex = new Regex(@"[YN]");
                    string answers = string.Empty;
                    do
                    {
                        Console.SetCursorPosition(55, 9);
                        Console.WriteLine("           ");
                        Console.SetCursorPosition(55, 9);
                        answers = Console.ReadLine().ToUpper();
                    } while (!answersRegex.IsMatch(answers));
                    if (answers == "Y")
                    {
                        packageToDeleteDictionary.Remove(int.Parse(deleteID));
                        SaveToRegiterPackageFile(packageToDeleteDictionary);

                        Console.SetCursorPosition(7, 10);
                        Console.Write($"ID number: {deleteID} deleted !                                   ");
                        Thread.Sleep(2000);
                        doAgain = true;
                    }
                    else
                    {
                        doAgain = true;
                    }

                }

                Console.SetCursorPosition(0, 14);
                RegisterPackage.ViewStartDeliveryManagmentList();


            } while (doAgain);
        }

        private static void SaveToRegiterPackageFile(Dictionary<int, RegisterPackage> packageToDeleteDictionary)
        {
            File.WriteAllLines(FilesPath.registerPackagePath, packageToDeleteDictionary.Select(kvp =>
                                    string.Format($"{kvp.Value.ID},{kvp.Value.Sender},{kvp.Value.Destination},{kvp.Value.Status},{kvp.Value.RegistrationNumber},{kvp.Value.RegisterDate},{kvp.Value.DeliveryDate}")));
        }
    }

    public enum Option
    {
        Edit,
        Delete,
        Exit
    }

    public enum EditOption
    {
        Capacity,
        Reach
    }
}
