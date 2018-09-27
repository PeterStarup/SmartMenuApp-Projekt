using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMenuLibrary
{
    public class SmartMenu
    {
        public void LoadMenu(string path)
        {
            //splitter et array op i to lige store arrays
            string[] testarray = { "bla", "bla1", "bla2", "bla3" };

            string[] danskArray = testarray.Take(testarray.Length / 2).ToArray();
            string[] engelskArray = testarray.Skip(testarray.Length / 2).ToArray();


            string[] heleTxt = System.IO.File.ReadAllLines(@"c:..\..\" + path + "");
            string[] danskTxt = new string[heleTxt.Length / 2];
            string[] englishTxt = new string[heleTxt.Length / 2];

            for(int i = 0; i < heleTxt.Length; i++)
            {
                if(heleTxt[i] == "Dansk:")
                {
                    for(int j = 0; j < danskTxt.Length; j++)
                    {
                        danskTxt[j] = heleTxt[i];
                    }
                }
                if(heleTxt[i] == "English:")
                {
                    for(int l = 0; l < englishTxt.Length; l++)
                    {
                        englishTxt[l] = heleTxt[i];
                    }
                }
            }
            Console.WriteLine(danskTxt[0]);
        }
        public void Activate()
        {
            // Implement ...
        }
    }
}
