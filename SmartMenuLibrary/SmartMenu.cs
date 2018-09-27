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
            string[] danskTxt = heleTxt.Take(heleTxt.Length / 2).ToArray();
            string[] englishTxt = heleTxt.Skip(heleTxt.Length / 2).ToArray();

            Console.WriteLine(danskTxt[1]);
            Console.WriteLine(englishTxt[3]);
        }
        public void Activate()
        {
            // Implement ...
        }
    }
}
