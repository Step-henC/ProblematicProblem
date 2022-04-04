using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProblematicProblem
{
    class Program
    {
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static Random rng = new Random();
        static bool cont = true;
        static void Main(string[] args)
        {

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");


            bool cont = (Console.ReadLine().ToLower() == "yes") ? true : false;
            if (cont == false)
            {
                Console.WriteLine("see ya");
                return;
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine().ToString();
            if (userName.Any(ch => char.IsDigit(ch)))
            {
                Console.WriteLine("Not a name");
                return;

            }

            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = Convert.ToInt32(Console.ReadLine());
            if (userAge < 0)
            {
                Console.WriteLine("Sorry, not a valid age");
                return;
            }
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");

            bool seeList = (Console.ReadLine().ToLower() == "sure") ? true : false;

            if (seeList == true)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(500);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Would you like to add any activities before we generate one? yes/no: ");
            bool addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
            if (addToList == false)
            {
                Program.BufferGraphic();
                Program.RandoGenerate(userAge, userName);
            }


            Console.WriteLine();
            
            string userAddition = "";
            if (addToList == true)
            {
                Console.Write("What would you like to add? ");
                userAddition = Console.ReadLine();

                activities.Add(userAddition);


                Console.WriteLine("Printing new Activity List");

                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;

            }


            
         




        }
        public static bool RandoGenerate(int userAge, string userName)
        {

          
            int randomNumber = rng.Next(activities.Count);
            string randomActivity = activities[randomNumber];
            if (userAge <= 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                Console.WriteLine("Pick something else!");
                activities.Remove(randomActivity);
                randomNumber = rng.Next(activities.Count);
                randomActivity = activities[randomNumber];
            }
            Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
            Console.WriteLine();
            bool decision = (Console.ReadLine().ToLower() == "keep") ? true : false;
            return decision;    

            


        }
        public static void BufferGraphic()
        {
            Console.Write("Connecting to the database");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();
            Console.Write("Choosing your random activity");

            for (int i = 0; i < 9; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }
        }
        
    }
}
