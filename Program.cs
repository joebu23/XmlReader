using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlReader.Services;

namespace XmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlReader = new XmlReaderService("../../StyleCop.xml");
            var totalStyleCopCount = xmlReader.GetTotalStyleCopErrors();

            var errorTotal = 0;
            foreach (var total in totalStyleCopCount.Projects)
            {
                Console.WriteLine(total.Name);
                Console.WriteLine(total.ErrorCount);
                errorTotal += total.ErrorCount;
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("Total for StyleCop: " + errorTotal);

            //var xmlReader2 = new XmlReaderService("../../FxCop.xml");
            //var totalFxCopCount = xmlReader2.GetTotalFxCopErrors();


            Console.ReadKey();
        }
    }
}
