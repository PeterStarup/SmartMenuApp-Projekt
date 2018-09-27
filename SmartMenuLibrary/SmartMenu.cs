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
            //splitter et array op i to lige store arrays
            /*
            string[] testarray = { "bla", "bla1", "bla2", "bla3" };

            string[] danskArray = testarray.Take(testarray.Length / 2).ToArray();
            string[] engelskArray = testarray.Skip(testarray.Length / 2).ToArray();
            */

            string[] heleTxt = System.IO.File.ReadAllLines(@"c:..\..\" + path + "");
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
                Console.WriteLine("Du har valgt dansk\n"); /*vi skal have lavet så man kan hente de to string fra loadmenu metoden*/
                for(int i = 2; i < danskTxt.Length; i++)
                {
                    Console.WriteLine(danskTxt[i]);
                }
                Console.WriteLine("\n" + "(" + danskTxt[1] + ")");
            }
            else if (sprog == "e")
            {
                Console.WriteLine("You have chosen English\n"); /*vi skal have lavet så man kan hente de to string fra loadmenu metoden*/
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
