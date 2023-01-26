using System.Text.RegularExpressions;

namespace noteApp
{
    internal class Program : Tools
    {
        

        public static User Registration(List<User> users)
        {
            Console.WriteLine("REGISTER");
            Console.WriteLine("========");

            Console.Write("Username: ");
            string rUsername = Console.ReadLine();

            Console.Write("\nPassword: ");
            string rPassword = Console.ReadLine();

            if (isUserExist(rUsername, users))
            {
                return new User(null, null);
            }

            return new User(rUsername, rPassword);
        }
        public static User GetUser(string username, List<User> users)
        {
            foreach (var u in users)
            {
                if (u.Username == username)
                {
                    return u;
                }
            }

            return new User(null, null);
        }
        public static bool isUserExist(string username, List<User> users)
        {
            foreach (var u in users)
            {
                if (u.Username == username) return true;
            }

            return false;
        }
        public static bool isUserExist(User user, List<User> users)
        {
            foreach (var u in users)
            {
                if (user.Username == u.Username) return true;
            }

            return false;
        }

        public static void AddNote(string note, User currentUser)
        {
            currentUser.Notes.Add(note);
        }

        public static void Main(string[] args)
        {
            List<User> users = new List<User>();
            
            User currentUser = null;
            bool isLoggedIn = false;

            while (true)
            {
                if (users.Count == 0)
                {
                    users.Add(Registration(users));
                    Success("Succesful registration!");
                    Console.Clear();
                    continue;
                }

                if (!isLoggedIn)
                {
                    Console.WriteLine("LOGIN MENU");
                    Console.WriteLine("==========");

                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");

                    Console.Write("\n> ");
                    string loginMenuChoice = Console.ReadLine();
                    Console.Clear();

                    switch (loginMenuChoice)
                    {
                        case "1":
                            Console.WriteLine("LOGIN");
                            Console.WriteLine("=====");

                            Console.Write("Username: ");
                            string lUsername = Console.ReadLine();

                            Console.Write("\nPassword: ");
                            string lPassword = Console.ReadLine();

                            User lUser = GetUser(lUsername, users);

                            if (lUser.Username == null)
                            {
                                Error("Invalid username / password");
                                Console.Clear();
                                continue;
                            }

                            if (lUser.Username == lUsername && lUser.PasswordMatch(lPassword))
                            {
                                isLoggedIn = true;
                                currentUser = lUser;
                                Success($"Welcome, {lUser.Username}!");
                                Console.Clear();
                            }
                            else
                            {
                                Error("Invalid username / password");
                                Console.Clear();
                                continue;
                            }
                            continue;

                        case "2":
                            User newRegisteredUser = Registration(users);
                            
                            if (newRegisteredUser.Username != null)
                            {
                                users.Add(newRegisteredUser);
                                Success("Succesful registration!");
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                Error("User already exist!");
                                Console.Clear();
                                continue;
                            }

                        default:
                            Error("Invalid selection!");
                            Console.Clear();
                            continue;
                    }

                    
                }

                Console.WriteLine("MENU");
                Console.WriteLine("====");
                Console.WriteLine("1. Notes");
                Console.WriteLine("2. Add note");
                Console.WriteLine("3. Remove note");
                Console.WriteLine("4. Exit");

                string menuChoice = Console.ReadLine();
                Console.Clear();

                switch (menuChoice)
                {
                    case "1":
                        currentUser.ListNotes();

                        Console.WriteLine("\nPress [ENTER] to return.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;

                    case "2":
                        Console.Write("Note: ");
                        string note = Console.ReadLine();

                        AddNote(note, currentUser);
                        Announcement("Added note!");
                        Console.Clear();
                        continue;

                    case "3":
                        currentUser.removeNote();
                        Console.Clear();
                        continue;

                    case "4":
                        isLoggedIn = false;
                        continue;

                    default:
                        Error("Invalid selection!");
                        Console.Clear();
                        continue;
                }
            }
        }
    }
}