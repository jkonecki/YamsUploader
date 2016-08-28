using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Etg.Yams.Storage;

namespace DeployRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var param= args[0];

            Console.WriteLine("Param provided: "+param+ ". Completed");
        }
    }
}
