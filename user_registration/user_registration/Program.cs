using System;
using System.Collections.Generic;

namespace user_management
{
    class Program
    {
        public static List<Register> users { get; set; } = new List<Register>();
        static void Main(string[] args)
        {

            while (true)
            {


                Console.WriteLine();
                Console.WriteLine("/register");
                Console.WriteLine("/login");
                Console.WriteLine();
                Console.WriteLine("Please, choose the command: ");
                string command = Console.ReadLine();


                if (command == "/register")
                {
                    Console.WriteLine("To join us, you must first enter your name(Ps: Name can have a minimum of 3 and a maximum of 30 characters): ");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Later, surname (Ps:The surname can have a minimum of 5 and a maximum of 20 characters ");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("And now email (Ps: There should be a @ sign inside the email): ");
                    string emailAdress = Console.ReadLine();

                    Console.WriteLine("And finally, password (Ps: We have no conditions for this, you are free): ");
                    string userPassword1 = Console.ReadLine();

                    Console.WriteLine("No finally :D, please, write password again: ");
                    string userPassword2 = Console.ReadLine();



                    Register user = GetAddUser(firstName, lastName, emailAdress, userPassword1, userPassword2);




                }
                else if (command == "/login")
                {
                    Console.WriteLine("Please, enter your email: ");
                    string emailAdress = Console.ReadLine();

                    Console.WriteLine("Please, enter your password: ");
                    string userpassword = Console.ReadLine();

                    Login user = GetTrueLogin(users, emailAdress, userpassword);

                }
                else
                {
                    Console.WriteLine("You did not enter the correct command!");
                }
            }


        }
        public static bool IsEmailUnique(string emailAdress)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].EmailAdress == emailAdress)
                {
                    Console.WriteLine("Email already exists! PLease, enter another email!");
                    return false;
                }
            }
            return true;

        }

        public static Login GetTrueLogin(List<Register> users, string userEmail, string userPassword)
        {
            Login user = new Login(userEmail, userPassword);
            if (Login.IsUserEmailTrue(users, userEmail) & Login.IsUserPasswordTrue(users, userPassword))
            {
                Console.WriteLine("Welcome to your account! ");
            }
            else
            {
                Console.WriteLine("User not found!");
            }

            return user;
        }
        public static Register GetAddUser(string firstName, string lastName, string emailAdress, string userPassword1, string userPassword2)
        {
            Register user = new Register(firstName, lastName, emailAdress, userPassword1, userPassword2);
            if (UserValidator.IsRegisterTrue(firstName, lastName, emailAdress, userPassword1, userPassword2) == true && IsEmailUnique(emailAdress) == true)
            {
                users.Add(user);
            }
            else
            {
                Console.WriteLine("Registiration failed! Correct the shown errors and try again!");
            }

            return user;
        }



    }




    class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string UserPassword1 { get; set; }
        public string UserPassword2 { get; set; }

        public Register(string firstName, string lastName, string emailAdress, string userPassword1, string userPassword2)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAdress = emailAdress;
            UserPassword1 = userPassword1;
            UserPassword2 = userPassword2;

        }




    }
    class UserValidator : Register
    {
        public UserValidator(string firstName, string lastName, string emailAdress, string userPassword1, string userPassword2)
            : base(firstName, lastName, emailAdress, userPassword1, userPassword2)

        {

        }
        public static bool IsNameLengthTrue(string firstName)
        {
            if (firstName.Length < 3 || firstName.Length > 30)
            {
                Console.WriteLine("Sorry, the length of the name is not correct!");
                return false;
            }
            else
            {
                return true;
            }


        }

        public static bool IsSurnameLengthTrue(string lastName)
        {
            if (lastName.Length < 5 || lastName.Length > 20)
            {
                Console.WriteLine("Sorry, the length of surname is not correct");
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool IsEmailAdressTrue(string emailAdress)
        {

            foreach (char j in emailAdress)
            {
                if (j == '@')
                {
                    return true;
                }



            }
            Console.WriteLine("Sorry, email format is not true!");
            return false;


        }



        public static bool IsPasswordConfirm(string userPassword1, string userPassword2)
        {
            if (userPassword1 == userPassword2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password not verified!");
                return false;
            }
        }

        public static bool IsRegisterTrue(string firstName, string lastName, string emailAdress, string userPassword1, string userPassword2)
        {
            if (IsNameLengthTrue(firstName) == true & IsSurnameLengthTrue(lastName) == true & IsEmailAdressTrue(emailAdress) == true & IsPasswordConfirm(userPassword1, userPassword2) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    class Login
    {
        public string UserEmail { get; private set; }
        public string UserPassword { get; private set; }

        public Login(string userEmail, string userPassword)
        {
            UserEmail = userEmail;
            UserPassword = userPassword;
        }

        public static bool IsUserEmailTrue(List<Register> users, string userEmail)
        {
            foreach (Register user in users)
            {
                if (user.EmailAdress == userEmail)
                {
                    return true;
                }

            }
            Console.WriteLine("Email not find in database!");
            return false;
        }

        public static bool IsUserPasswordTrue(List<Register> users, string userPassword)
        {
            foreach (Register user in users)
            {
                if (user.UserPassword1 == userPassword)
                {
                    return true;
                }
            }
            Console.WriteLine("Password not find in database!");
            return false;
        }
    }

}
