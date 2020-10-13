using City_Mail.Domain;
using CityMail.Domain;
using System;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;

namespace CityMail
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

                User.UserAccessControl();
                bool toExit2 = true;
                do
                {

                    Console.Clear();
                    Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Central Menu <<",42} ");
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine($@"
                    1. Delivery units

                    2. Register package

                    3. List packages

                    4. Start delivery

                    5. Logout

                    Pleae press one of the number of your choice in this menu: ");

                    int menuNumber = MenuNumber(new Regex(@"[1-5]"), 79, 17);

                    Menu menu = (Menu)menuNumber - 1;

                    switch (menu)
                    {
                        case Menu.DeliveryUnits:

                            bool toExit = false;
                            bool toExit1 = true;

                            do
                            {

                                Console.Clear();
                                Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Delivery Units <<",42} ");
                                Console.SetCursorPosition(0, 6);
                                Console.WriteLine($@"
                    1. Register

                    2. Search

                    3. Exit

                    Pleae press one of the number of your choice in this menu: ");
                                int menuNumberDeliveryUnits = MenuNumber(new Regex(@"[1-3]"), 79, 13);
                                CaseOne caseOne = (CaseOne)menuNumberDeliveryUnits - 1;
                                switch (caseOne)
                                {
                                    case CaseOne.Register:
                                        //bool toExit = false;
                                        do
                                        {

                                            Console.Clear();
                                            Console.WriteLine($@"
                            {"City Mail",37}
                            {">> Register <<",40} ");
                                            Console.SetCursorPosition(0, 6);
                                            Console.WriteLine($@"
                    1. Car

                    2. Quadcopter 

                    3. Exit

                    Pleae press one of the number of your choice in this menu: ");
                                            int menuNumberRegister = MenuNumber(new Regex(@"[1-3]"), 79, 13);
                                            CaseOneOne caseOneOne = (CaseOneOne)menuNumberRegister - 1;
                                            switch (caseOneOne)
                                            {
                                                case CaseOneOne.Car:
                                                    FunktionsBase.CaseOneOneCar();
                                                    break;
                                                case CaseOneOne.Quadcopter:
                                                    FunktionsBase.CaseOneOneQuadcopter();
                                                    break;
                                                case CaseOneOne.Exit:
                                                    toExit = false;
                                                    break;
                                            }


                                        } while (toExit);
                                        break;
                                    case CaseOne.Search:
                                        FunktionsBase.CaseOneSearch();
                                        break;
                                    case CaseOne.Exit:
                                        toExit1 = false;
                                        break;
                                }

                            } while (toExit1);


                            break;
                        case Menu.RegisterPackage:
                             FunktionsBase.RegistrerPackage();
                            break;
                        case Menu.ListPackages:
                            FunktionsBase.ListPackage();                            
                            break;
                        case Menu.StartDelivery:
                            FunktionsBase.StartDeliveryPackages();
                            break;
                        case Menu.Logout:
                            toExit2 = false;
                            break;
                        default:
                            break;
                    }


                    //Console.ReadLine();

                } while (toExit2);

            } while (true);
           

            //Console.ReadLine();
        }

        private static int MenuNumber(Regex regexMenuNumber, int positionH, int positionV)
        {
            string menuNumber = string.Empty;
            do
            {
                Console.SetCursorPosition(positionH, positionV);
                Console.WriteLine(" ");
                Console.SetCursorPosition(positionH, positionV);
                menuNumber = Console.ReadKey().KeyChar.ToString();

            } while (!regexMenuNumber.IsMatch(menuNumber));
            return Convert.ToInt32(menuNumber);
        }
    }

    public enum Menu
    {
        DeliveryUnits,
        RegisterPackage,
        ListPackages,
        StartDelivery,
        Logout
    }

    public enum CaseOne
    {
        Register,
        Search,
        Exit

    }

    public enum CaseOneOne
    {
        Car,
        Quadcopter,
        Exit

    }
}
