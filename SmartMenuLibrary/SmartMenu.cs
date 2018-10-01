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
            label1:
            Console.WriteLine("Vælg sprog - Choose language: \n Tryk D for Dansk \n Press E for English");
            string sprog = Console.ReadLine().ToLower();

            if (sprog == "d")
            {
                Console.WriteLine("Du har valgt dansk\n"); 
                for(int i = 2; i < danskTxt.Length; i++)
                {
                    Console.WriteLine(danskTxt[i]);
                }
                Console.WriteLine("\n" + "(" + danskTxt[1] + ")");
            }
            else if (sprog == "e")
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
                goto label1;
            }
            string menupunkt = Console.ReadLine();
            if (menupunkt == "1")
            {
                Console.WriteLine(FunctionLibrary.Functions.DoThis());
            }
            else if(menupunkt == "2")
            {
                Console.WriteLine(FunctionLibrary.Functions.DoThat());
            }
            else if (menupunkt == "3")
            {
                Console.WriteLine(FunctionLibrary.Functions.DoSomething(menupunkt));
            }
            else if (menupunkt == "4")
            {
                Console.WriteLine(FunctionLibrary.Functions.GetTheAnswerToLifeTheUniverseAndEverything());
            }
            else if (menupunkt == "0")
            {
                Console.WriteLine("Afslutter program - Stoping program");
            }
            else
            {
                if (sprog == "d")
                {
                    Console.WriteLine("Du har ikke valgt et gyldigt mune punkt");
                }
                else if (sprog == "e")
                {
                    Console.WriteLine("You have not selected a valid menu point");
                }
            }
        }
    }
}
