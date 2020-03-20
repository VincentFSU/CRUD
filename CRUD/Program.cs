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

            List<User> userList = new List<User>();

            Console.WriteLine("Welcome to you user database! \n");
            Console.WriteLine("Please choose one of these menu options: ");

            string choice = "null";

            do
            {

                Console.WriteLine("[ C - Create | R - Read | U - Update | D - Delete | P - Print | Q - Quit ]");
                Console.Write("Input: ");

                choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "C" || choice == "c")
                {
                    Console.Write("Please enter a prefix: ");
                    string prefix = Console.ReadLine();
                    Console.Write("Please enter a suffix: ");
                    string suffix = Console.ReadLine();

                    bool validID = false;
                    do
                    {
                        Console.Write("Please enter an ID: ");
                        string userID = Console.ReadLine();

                        validID = !userList.Any(user => user.UserID == userID);
                        if (validID)
                        {
                            var user = new User(prefix, suffix, userID);
                            userList.Add(user);
                            Console.WriteLine("\n" + user + "\n");
                        }
                        else
                        {
                            Console.WriteLine("\nA user with this ID already exists, please try again.\n");
                        }
                    } while (!validID);
                }

                if (choice == "R" || choice == "r")
                {
                    Console.Write("Please enter the user's ID: ");
                    string userID = Console.ReadLine();

                    var user = userList.SingleOrDefault(u => u.UserID == userID);
                    if (user != null)
                    {
                        Console.WriteLine("\n" + userID + ": " + user.ToString() + "\n");
                    }
                    else
                    {
                        Console.WriteLine("\n ***No such user*** \n");
                    }
                }

                if (choice == "U" || choice == "u")
                {

                    Console.Write("Please enter the user's ID: ");
                    string userID = Console.ReadLine();

                    string newPref;
                    string newSuf;
                    string newID;

                    var user = userList.SingleOrDefault(u => u.UserID == userID);
                    if (user != null)
                    {
                        Console.WriteLine("\nCurrent information: " + user.ToString());
                        Console.Write("\nPlease enter the user's new prefix: ");
                        newPref = Console.ReadLine();
                        Console.Write("Please enter the user's new suffix: ");
                        newSuf = Console.ReadLine();

                        var validID = false;
                        do
                        {
                            Console.Write("Please enter the user's new ID: ");
                            newID = Console.ReadLine();

                            validID = !userList.Any(u => u.UserID == newID);
                            if (validID)
                            {
                                user.UserID = newID;
                                user.Prefix = newPref;
                                user.Suffix = newSuf;

                                Console.WriteLine("\nUpdated information: " + user.ToString() + "\n");
                            }
                            else
                            {
                                Console.WriteLine("\nA user with this ID already exists, please try again.\n");
                            }
                        } while (!validID);
                    }                   
                }

                if (choice == "D" || choice == "d")
                {
                    DeleteUser(userList);
                }

                if (choice == "P" || choice == "p")
                {
                    if (userList.Any())
                    {
                        foreach (var user in userList)
                        {
                            Console.WriteLine(user);
                        }
                    }
                    else
                    {
                        Console.WriteLine("To fill this empty table, enter 'C'.");
                    }
                    Console.WriteLine();
                }

                if (choice == "Q" || choice == "q")
                {
                    running = false;
                }

            } while (running);
        }

        private static void DeleteUser(List<User> userList)
        {
            Console.Write("Please enter the user's ID: ");
            string userID = Console.ReadLine();
            Console.WriteLine();

            var originalCount = userList.Count;
            userList.RemoveAll(u => u.UserID == userID);

            if (originalCount == userList.Count)
            {
                Console.WriteLine("***No such user*** \n");
            }
        }
    }
}
