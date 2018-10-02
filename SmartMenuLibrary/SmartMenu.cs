using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMenuLibrary
{
    public class SmartMenu
    {
        string[] danskTxt;
        string[] englishTxt;
        int[] callID;
        string userInput = null, userInputSprog = null;
        public void LoadMenu(string path)
        {

            string[] heleTxt = System.IO.File.ReadAllLines(@"..\..\" + path + "");
            danskTxt = heleTxt.Take(heleTxt.Length / 2).ToArray();
            englishTxt = heleTxt.Skip(heleTxt.Length / 2).ToArray();
            callID = new int[danskTxt.Length - 2];
            
            for(int i = 0; i < danskTxt.Length; i++)
            {
                int j = 0;
                if (danskTxt[i].Contains(';'))
                {
                    string[] splitter = danskTxt[i].Split(';');
                    danskTxt[i] = splitter[0];
                    callID[j] = int.Parse(splitter[1]);
                    j++;
                }
            }
        }

        public void Activate()
        {
            Console.WriteLine("Vælg sprog - Choose language: \n Tryk D for Dansk \n Press E for English");

            do
            {
                userInputSprog = Console.ReadLine().ToLower();
                printMenu(userInputSprog);

            } while (userInputSprog != "d" && userInputSprog != "e");

            do
            {
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    printMenu(userInputSprog);
                    Console.WriteLine("\n" + FunctionLibrary.Functions.DoThis());
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    printMenu(userInputSprog);
                    Console.WriteLine("\n" + FunctionLibrary.Functions.DoThat());
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    printMenu(userInputSprog);
                    Console.WriteLine("\n" + FunctionLibrary.Functions.DoSomething(userInput));
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    printMenu(userInputSprog);
                    Console.WriteLine("\n" + FunctionLibrary.Functions.GetTheAnswerToLifeTheUniverseAndEverything());
                }
                else if (userInput == "0")
                {
                    Console.Clear();
                    printMenu(userInputSprog);
                    Console.WriteLine("\nAfslutter program - Stopping program");
                }
                else
                {
                    if (userInputSprog == "d")
                    {
                        Console.Clear();
                        printMenu(userInputSprog);
                        Console.WriteLine("\nDu har ikke valgt et gyldigt menu punkt. Prøv igen");
                    }
                    else if (userInputSprog == "e")
                    {
                        Console.Clear();
                        printMenu(userInputSprog);
                        Console.WriteLine("\nYou have not selected a valid menu point. Try again");
                    }
                }
            } while (userInput != "0");
        }

        public void printMenu(string lang)
        {
            if (lang == "d")
            {
                Console.WriteLine("Du har valgt dansk\n");
                for (int i = 2; i < danskTxt.Length; i++)
                {
                    Console.WriteLine(danskTxt[i]);
                }
                Console.WriteLine("\n" + "(" + danskTxt[1] + ")");
            }
            else if (lang == "e")
            {
                Console.WriteLine("You have chosen English\n");
                for (int i = 2; i < englishTxt.Length; i++)
                {
                    Console.WriteLine(englishTxt[i]);
                }
                Console.WriteLine("\n" + "(" + englishTxt[1] + ")");
            }
            else
            {
                Console.WriteLine("Du har ikke valgt et gyldigt sprog - You have not chosen a viable language");
            }
        }
    }
}
