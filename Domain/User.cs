using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CityMail.Domain
{
    class User
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User(int userID, string userName, string password)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
        }

        public int UserID { get; } = AutoGeneratUserID();
        public string UserName { get; }
        public string Password { get; }


        static int AutoGeneratUserID()
        {
            int startID = 100; //It's just for demo else it can change to biger number
            List<int> keysList = new List<int>();

            List<string> readUsersDataBase = File.ReadAllLines(FilesPath.userPath).ToList();

            if (readUsersDataBase.Count == 0)
            {
                return startID;
            }
            else
            {
                foreach (string room in readUsersDataBase)
                {
                    string[] roomSplit = room.Split(",");
                    keysList.Add(Convert.ToInt32(roomSplit[0]));
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

        public static Dictionary<int, User> TransferUsersDataBasetoDictionary()
        {
            Dictionary<int, User> usersDictionary = new Dictionary<int, User>();
            List<string> usersList = File.ReadAllLines(FilesPath.userPath).ToList();
            foreach (var user in usersList)
            {
                string[] userSplit = user.Split(",");
                User userValues = new User(int.Parse(userSplit[0]), userSplit[1], userSplit[2]);

                usersDictionary.Add(int.Parse(userSplit[0]), userValues);
            }
            return usersDictionary;
        }

        public static bool UserAccessControl()
        {
            Dictionary<int, User> userDictionery = User.TransferUsersDataBasetoDictionary();
            bool doAgain = false;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(48, 1);
                Console.WriteLine($"{"City Mail"} \n\n\tFor Access To Centrall Menu, Please Enter UserName And Password ");
                Console.SetCursorPosition(0, 8);
                Console.WriteLine($@"
                              UserName : 

                              Password :");

                //Console.SetCursorPosition(0, 16);
                Console.SetCursorPosition(0, 26);
                Console.WriteLine($"\tPleas Enter {"Exit"} If you wish to close this Application!");

                Regex regexUserName = new Regex(@"\w+");
                Regex regexPassword = new Regex(@"[a-zA-Z0-9!()]+");
                string userName;
                string password;

                do
                {
                    Console.SetCursorPosition(41, 9);
                    Console.WriteLine("             ");
                    Console.SetCursorPosition(41, 9);
                    userName = Console.ReadLine();      // This line must be active 
                    //userName = "admin";
                    if (userName.ToUpper() == "EXIT")
                    {
                        Console.Clear();
                        //string[] goodbye = "G O O D B Y E !".Split(" ");
                        string[] goodbye = "H,A,V,E, ,A, ,N,I,C,E, ,D,A,Y,!".Split(",");
                        int i = 0;
                        int pos = 48;
                        string goodBye = null;
                        foreach (var word in goodbye)
                        {
                            System.Threading.Thread.Sleep(200);
                            pos += i;
                            goodBye = goodBye + word;
                            Console.SetCursorPosition(48, 10);
                            Console.WriteLine(goodBye);
                            i++;
                        }
                        System.Threading.Thread.Sleep(2000);
                        Console.SetCursorPosition(2, 25);
                        Environment.Exit(0);
                    }
                } while (!regexUserName.IsMatch(userName));


                do
                {
                    Console.SetCursorPosition(41, 11);
                    Console.WriteLine("             ");
                    Console.SetCursorPosition(41, 11);
                    password = Console.ReadLine();      // This line must be active 
                    //password = "admin";
                } while (!regexPassword.IsMatch(password));

                foreach (var userInfo in userDictionery.Values)
                {
                    if (userName == userInfo.UserName && password == userInfo.Password)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 9);
                        Console.WriteLine($@"
                                        Access Granted

                              You will transfer to Central Menu {"\n\n\n"}");

                        doAgain = false;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(41, 11);
                        Console.WriteLine($"Access Denied!\n\n {"Please try again ...",58}");

                        doAgain = true;
                        continue;
                    }
                }

                System.Threading.Thread.Sleep(2000);

            } while (doAgain);

            return doAgain;
        }

    }

}
