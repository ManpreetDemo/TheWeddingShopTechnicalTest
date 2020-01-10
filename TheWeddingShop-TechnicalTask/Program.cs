using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeddingShop_TechnicalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Requirement : Solve Mars Rover Problem ***\n");
            Console.WriteLine(new String('-', 80));
            while (true) // Continue the game untill the user does want to anymore...
            {
                SolveMarsRoverProblem();
                while (true) // Continue asking until a correct answer is given.
                {
                    Console.Write("Do you want to play again [Y/N]?");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                        break; // Exit the inner while-loop and continue in the outer while loop.
                    if (answer == "N")
                        return; // Exit the Main-method.
                }
            }
        }

        private static void SolveMarsRoverProblem()
        {
            try
            {
                Console.WriteLine("Enter max points (i.e. 5 5):");
                var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

                Console.WriteLine("Enter start position - X Y Direction (i.e. 1 2 N):");
                var startPositions = Console.ReadLine().Trim().ToUpper().Split(' '); 
                Position position = new Position();

                if (startPositions.Count() == 3)
                {
                    position.X = Convert.ToInt32(startPositions[0]);
                    position.Y = Convert.ToInt32(startPositions[1]);
                    position.Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
                }

                Console.WriteLine("Enter moves (i.e. LMLMLMLMM):");
                var moves = Console.ReadLine().ToUpper();

                position.StartMoving(maxPoints, moves);

                Console.WriteLine("Result: ");
                Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
