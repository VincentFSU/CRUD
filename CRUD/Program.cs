using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD
{
    class Program
    {
        public static void Main()
        {
            bool running = true;
            var users = new Dictionary<string, User>();

            Console.WriteLine("Welcome to you user database! \n");
            Console.WriteLine("Please choose one of these menu options: ");

            do
            {
                Console.WriteLine("[ C - Create | R - Read | U - Update | D - Delete | P - Print | Q - Quit ]");
                Console.Write("\nInput: ");

                switch (Console.ReadLine().ToUpper())
                {
                    case "C":
                        CreateUser(users);
                        break;

                    case "R":
                        ReadUser(users);
                        break;

                    case "U":
                        UpdateUser(users);
                        break;

                    case "D":
                        DeleteUser(users);
                        break;

                    case "P":
                        PrintAll(users);
                        break;

                    case "Q":
                        running = false;
                        break;

                    default:
                        break;
                }
            } while (running);
        }

        private static void PrintAll(Dictionary<string, User> users)
        {
            if (users.Any())
            {
                foreach (var user in users.Values.OrderBy(value => value.UserID))
                {
                    Console.WriteLine(user);
                }
            }
            else
            {
                Console.WriteLine("To fill this empty table, enter 'C'.");
            }
        }

        private static void UpdateUser(Dictionary<string, User> users)
        {
            Console.Write("Please enter the user's ID: ");
            string userID = Console.ReadLine();

            if (users.ContainsKey(userID))
            {
                Console.WriteLine("\nCurrent information: " + users[userID]);
                CreateUser(users);
            }
        }

        private static void ReadUser(IDictionary<string, User> users)
        {
            Console.Write("Please enter the user's ID: ");
            string userID = Console.ReadLine();

            if (users.ContainsKey(userID))
            {
                Console.WriteLine("\n" + userID + ": " + users[userID] + "\n");
            }
            else
            {
                Console.WriteLine("\n ***No such user*** \n");
            }
        }

        private static void CreateUser(IDictionary<string, User> users)
        {
            Console.Write("Please enter a prefix: ");
            string prefix = Console.ReadLine();
            Console.Write("Please enter a suffix: ");
            string suffix = Console.ReadLine();

            Console.Write("Please enter an ID: ");
            string userID = null;
            do
            {
                userID = Console.ReadLine();

                if (users.ContainsKey(userID))
                {
                    Console.WriteLine("\nA user with this ID already exists, please try again.\n");
                }
            } while (userID == null || users.ContainsKey(userID));

            var user = new User(prefix, suffix, userID);
            users.Add(userID, user);
            Console.WriteLine("\n" + user + "\n");
        }

        private static void DeleteUser(IDictionary<string, User> users)
        {
            Console.Write("Please enter the user's ID: ");
            string userID = Console.ReadLine();
            Console.WriteLine();

            if(!users.Remove(userID))
            {
                Console.WriteLine("***No such user*** \n");
            }
        }
    }
}
