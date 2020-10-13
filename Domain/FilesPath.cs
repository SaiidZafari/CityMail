using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityMail.Domain
{
    class FilesPath
    {
        public static string userPath = Path.GetFullPath(@"..\..\..\DataBase\UserInformation.txt");
        public static string carPath = Path.GetFullPath(@"..\..\..\DataBase\Car.txt");
        public static string quadcopterPath = Path.GetFullPath(@"..\..\..\DataBase\Quadcopter.txt");
        public static string registerPath = Path.GetFullPath(@"..\..\..\DataBase\Register.txt");
        public static string registerPackagePath = Path.GetFullPath(@"..\..\..\DataBase\RegisterPackage.txt");
    }
}
