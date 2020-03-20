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

            //ask for input over and over until the user quits
            do
            {

                Console.WriteLine("[ C - Create | R - Read | U - Update | D - Delete | P - Print | Q - Quit ]");
                Console.Write("Input: ");

                //user menu choice
                choice = Console.ReadLine();
                Console.WriteLine();

                //add a new user to the system
                if (choice == "C" || choice == "c")
                {
                    Console.Write("Please enter a prefix: ");
                    string prefix = Console.ReadLine();
                    Console.Write("Please enter a suffix: ");
                    string suffix = Console.ReadLine();

                    var validID = false;
                    do
                    {
                        Console.Write("Please enter an ID: ");
                        string userID = Console.ReadLine();

                        validID = !userList.Any(user => user.UserID == userID);
                        if (validID)
                        {
                            userList.Add(new User(prefix, suffix, userID));
                            Console.WriteLine("\n" + userList.Last().ToString() + "\n");
                        }
                        else
                        {
                            Console.WriteLine("\nA user with this ID already exists, please try again.\n");
                        }
                    } while (!validID);


                //read information of an existing user
                if (choice == "R" || choice == "r")
                {
                    //prompt to enter in the user's id to match to an existing one
                    Console.Write("Please enter the user's ID: ");
                    string userID = Console.ReadLine();

                    //counter which will increment with each matching instance
                    int count = 0;

                    //if a user with the same id as the entered one exists, return it's information
                    foreach (User user in userList)
                    {
                        if (user.getUserID() == userID)
                        {
                            count++;
                            Console.WriteLine("\n" + userID + ": " + user.ToString() + "\n");
                        }
                    }

                    //if no user is found (i.e. count is 0), return error
                    if (count == 0)
                    {
                        Console.WriteLine("\n ***No such user*** \n");
                    }
                }

                //update a users information
                if (choice == "U" || choice == "u")
                {

                    //enter the users id
                    Console.Write("Please enter the user's ID: ");
                    string userID = Console.ReadLine();

                    //declare new values
                    string newPref;
                    string newSuf;
                    string newID;

                    //is the newID available?
                    bool idAvailable = true;

                    //when the user's id is matched, take input to determine new
                    //values for prefix, suffix, and id
                    foreach (User user in userList)
                    {
                        if (user.getUserID() == userID)
                        {
                            Console.WriteLine("\nCurrent information: " + user.ToString());
                            Console.Write("\nPlease enter the user's new prefix: ");
                            newPref = Console.ReadLine();
                            Console.Write("Please enter the user's new suffix: ");
                            newSuf = Console.ReadLine();
                            do
                            {
                                //id is initially available with each run of loop
                                idAvailable = true;

                                //enter new id
                                Console.Write("Please enter the user's new ID: ");
                                newID = Console.ReadLine();

                                //checks to see if the user id is already in use (i.e. if there are duplicates)
                                foreach (User us in userList)
                                {

                                    if (us.getUserID() == newID && newID != userID)
                                    {
                                        Console.WriteLine("\nA user with this ID already exists, please try again.\n");
                                        idAvailable = false;
                                    }
                                }
                            } while (!idAvailable);
                            {
                                user.setPrefix(newPref);
                                user.setSuffix(newSuf);
                                user.setUserID(newID);
                                Console.WriteLine("\nUpdated information: " + user.ToString() + "\n");
                            }
                        }
                    }
                }

                //delete a user of matching id
                if (choice == "D" || choice == "d")
                {
                    //enter the user id
                    Console.Write("Please enter the user's ID: ");
                    string userID = Console.ReadLine();
                    Console.WriteLine();

                    //counter that increments with each matching id
                    int count = 0;

                    //when a matching id is found, remove the element at the ith index
                    for (int i = 0; i < userList.Count; i++)
                    {
                        if (userList[i].getUserID() == userID)
                        {
                            count++;
                            userList.RemoveAt(i);
                        }
                    }

                    //if no matching id is found, return error
                    if (count == 0)
                    {
                        Console.WriteLine("***No such user*** \n");
                    }
                }

                //print all the information in the database
                if (choice == "P" || choice == "p")
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        Console.WriteLine(userList[i].ToString());
                    }

                    if (userList.Count == 0)
                    {
                        Console.WriteLine("To fill this empty table, enter 'C'.");
                    }

                    Console.WriteLine();
                }

                //quit the program
                if (choice == "Q" || choice == "q")
                {
                    running = false;
                }

            } while (running);
            { }
        }
    }
}
