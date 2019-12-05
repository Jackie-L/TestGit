using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => { Console.WriteLine("123");});
            
            Console.WriteLine("{0}====================================");
            Console.ReadKey();
        }

    }
}
