using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;

namespace NeuralA
{
    class Program
    {
        static void Main(string[] args)
        {
             do
             {
                 Game.setMemory("");
                 Game.playRound();
                 Console.WriteLine("Play another round?");
             } while (Console.ReadLine().Equals("y"));
         }
     }
 }