using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralA
{
    class Game
    {
        static String[] options = { "rock", "paper", "scissors" };
        static String memory;
        static double[] probability = { 1 / 3.0, 1 / 3.0, 1 / 3.0 };
        static double weightIncrement = 1 / 5.0;
        static double weightAccel = 1 / 5.0;
        static Random r = new Random();

        static int determineWinner(String c1, String c2)
        {
            switch (c1)
            {
                case "rock":
                    if (c2.Equals("rock"))
                        return 0;
                    else if (c2.Equals("paper"))
                        return 1;
                    else
                        return -1;
                case "paper":
                    if (c2.Equals("rock"))
                        return -1;
                    else if (c2.Equals("paper"))
                        return 0;
                    else
                        return 1;
                default:
                    if (c2.Equals("rock"))
                        return 1;
                    else if (c2.Equals("paper"))
                        return -1;
                    else
                        return -0;
            }
        }

        public static void setMemory(String s)
        {
            memory = s;
        }

        static String compPick()
        {
            double d = r.NextDouble();
            if (d < probability[0])
            {
                return "rock";
            }
            else if (d < probability[0] + probability[1])
            {
                return "paper";
            }
            else
            {
                return "scissors";
            }
        }

        public static void playRound()
        {
            Console.WriteLine("Enter a move:");
            String compMove = compPick();
            String playerMove = Console.ReadLine();
            int winTracker = determineWinner(compMove, playerMove);

            if (compMove.Equals(memory))
            {
                weightIncrement += weightAccel;
            }
            else
            {
                weightIncrement = 0.2;
            }

            if (winTracker == -1)
            {
                Console.WriteLine("Computers wins with a pick of " + compMove);
                switch (compMove)
                {
                    case "rock":
                        probability[0] += weightIncrement;
                        probability[1] -= weightIncrement / 2;
                        probability[2] -= weightIncrement / 2;
                        break;
                    case "paper":
                        probability[1] += weightIncrement;
                        probability[0] -= weightIncrement / 2;
                        probability[2] -= weightIncrement / 2;
                        break;
                    default:
                        probability[2] += weightIncrement;
                        probability[0] -= weightIncrement / 2;
                        probability[1] -= weightIncrement / 2;
                        break;
                }
            }
            else if (winTracker == 1)
            {
                Console.WriteLine("Player wins agains the computer's move of " + compMove);
                switch (compMove)
                {
                    case "rock":
                        probability[0] -= weightIncrement;
                        probability[1] += weightIncrement / 2;
                        probability[2] += weightIncrement / 2;
                        break;
                    case "paper":
                        probability[1] -= weightIncrement;
                        probability[0] += weightIncrement / 2;
                        probability[2] += weightIncrement / 2;
                        break;
                    default:
                        probability[2] -= weightIncrement;
                        probability[0] += weightIncrement / 2;
                        probability[1] += weightIncrement / 2;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Tie: both players selected " + compMove);
            }
        }
    }
}