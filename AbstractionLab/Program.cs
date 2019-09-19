using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLab
{
    class Program
    {
        // Problem 0
        public void printRow (int numRow)
        {
            for (int row = 1; row <= (numRow * 2 - 1) ; row++)
            {
                for (int space = 1; space <= Math.Abs(numRow - row); space++)
                    Console.Write(" ");
                for (int symbol = 1; symbol <= numRow - Math.Abs(numRow - row); symbol++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        // Problem 1
        public Rectangle inputRectangle()
        {
            Console.WriteLine("Please enter the coordinates of the top left and bottom right corner of the Rectangle!");
            bool isInput = false;
            float[] convertedIn = new float[4];
            while (!isInput)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                if (inputs.Length != 4)
                {
                    Console.WriteLine("Please enter only 4 values!");
                    continue;
                }
                int pos = 0;
                foreach (string input in inputs)
                {
                    try
                    {
                        convertedIn[pos] = float.Parse(input);
                        isInput = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("You have entered non-numeric characters");
                        isInput = false;
                        break;
                    }
                    pos++;
                }
            }
            return new Rectangle(convertedIn[0], convertedIn[1], convertedIn[2], convertedIn[3]);
        }
        public void testContains(Rectangle rectangle)
        {
            Console.Write("Enter numbers of your tests: ");
            bool isInput = false;
            int numTest = 0;
            while (!isInput)
            {
                try
                {
                    numTest = Int32.Parse(Console.ReadLine());
                    isInput = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("You have entered non-numeric characters");
                }
            }
            for(int count = 1; count <= numTest; count++)
            {
                bool isDone = false;
                float X, Y;
                Point point;
                while (!isDone)
                {
                    string[] input = Console.ReadLine().Split(' ');
                    try
                    {
                        X = float.Parse(input[0]);
                        Y = float.Parse(input[1]);
                        isDone = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("You have entered non-numeric characters");
                        continue;
                    }
                    point = new Point(X, Y);
                    Console.WriteLine(rectangle.Contains(point));
                }
            }
        }
        // Problem 2
        public void studentSystem()
        {
            List<Student> students = new List<Student>();
            bool isQuit = false;
            while (!isQuit)
            {
                Console.Write("Enter command: ");
                string[] input = Console.ReadLine().Split(' ');
                string Name;
                int Age;
                float Grade;
                switch (input[0])
                {
                    case "Create":
                    case "create":
                        Name = input[1];
                        try
                        {
                            Age = Int32.Parse(input[2]);
                            Grade = float.Parse(input[3]);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("You have entered non-numeric characters");
                            continue;
                        }
                        students.Add(new Student(Name, Age, Grade));
                        break;
                    case "Show":
                    case "show":
                        Name = input[1];
                        if (students.Exists(x => x.Name == Name))
                            Console.WriteLine(students.Find(x => x.Name == Name).ToString());
                        else Console.WriteLine("Not found");                        
                        break;
                    case "Exit":
                    case "exit":
                        isQuit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
        // Problem 3
        public void hotelReservation()
        {
            bool isQuit = false;
            Console.WriteLine("Enter the reservation: ");
            while (!isQuit)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "Exit" || input[0] == "exit") break;
                float Priceperday;
                int Numberofday;
                string Season;
                string Discount = "None";
                try
                {
                    Priceperday = float.Parse(input[0]);
                    Numberofday = Int32.Parse(input[1]);
                    Season = input[2];
                    if (input.Length == 4) Discount = input[3];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Reservation!");
                    continue;
                }
                PriceCalculator calculator = new PriceCalculator(Priceperday, Numberofday, Season, Discount);
                Console.WriteLine(calculator.calc());
            }
        }
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            // Problem 0
            //int numRow = int.Parse(Console.ReadLine());
            //myProgram.printRow(numRow);

            // Problem 1
            //Rectangle rectangle = myProgram.inputRectangle();
            //myProgram.testContains(rectangle);

            // Problem 2
            //myProgram.studentSystem();

            // Problem 3
            //myProgram.hotelReservation();
            Console.ReadLine();
        }
    }
}
