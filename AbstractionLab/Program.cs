using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLab
{
    // Problem 1
    class Point
    {
        private float x, y;
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(float X, float Y)
        {
            x = X; y = Y;
        }
    }
    class Rectangle
    {
        private Point topleft, bottomright;
        public Point TopLeft
        {
            get { return topleft; }
            set { topleft = value; }
        }
        public Point BottomRight
        {
            get { return bottomright; }
            set { bottomright = value; }
        }
        public Rectangle(Point TopLeft, Point BottomRight)
        {
            topleft = TopLeft;
            bottomright = BottomRight;
        }
        public Rectangle(float TopLeftX, float TopLeftY, float BottomRightX, float BottomRightY) 
            : this(new Point(TopLeftX, TopLeftY), new Point(BottomRightX, BottomRightY))
        {

        }
        public bool Contains(Point point)
        {
            if ((topleft.X <= point.X) && (point.X <= bottomright.X)
                && (topleft.Y <= point.Y) && (point.Y <= bottomright.Y))
                return true;
            else return false;
        }
    }
    // Problem 2
    class Student
    {
        private string name;
        private int age;
        private float grade;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { if (value <= 0) age = 1; else age = value; }
        }
        public float Grade
        {
            get { return grade; }
            set { if (value < 0 || value > 10) grade = 0; else grade = value; }
        }
        public Student(string Name, int Age, float Grade)
        {
            name = Name; age = Age; grade = Grade;
        }
        public override string ToString()
        {
            string reviewed;
            if (grade >= 5) reviewed = "Excellent";
            else if (grade >= 4) reviewed = "Average";
            else reviewed = "Weak";
            return name + " is " + age + " years old. " + reviewed + " student.";
        }
    }
    // Problem 3
    class PriceCalculator
    {
        private float priceperday;
        private int numberofday;
        private string season;
        private string discount;

        public float Priceperday
        {
            get { return priceperday; }
            set { if (value < 0) priceperday = 0; else priceperday = value; }
        }
        public int Numberofday
        {
            get { return numberofday; }
            set { if (value < 0) numberofday = 0; else numberofday = value; }
        }
        public string Season
        {
            get { return season; }
            set { season = value; }
        }
        public string Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public PriceCalculator(float Priceperday, int Numberofday, string Season)
        {
            priceperday = Priceperday;
            numberofday = Numberofday;
            season = Season;
            discount = "None";
        }
        public PriceCalculator(float Priceperday, int Numberofday, string Season, string Discount)
            : this(Priceperday, Numberofday, Season)
        {
            discount = Discount;
        }
        public float calc()
        {
            float percentDis = 0;
            int multiSeason = 1;
            switch (discount)
            {
                case "VIP":
                    percentDis = 0.2f;
                    break;
                case "SecondVisit":
                    percentDis = 0.1f;
                    break;
                default:
                    break;
            }
            switch (season)
            {
                case "Spring":
                    multiSeason = 2;
                    break;
                case "Winter":
                    multiSeason = 3;
                    break;
                case "Summer":
                    multiSeason = 4;
                    break;
                default:
                    break;
            }
            return priceperday * numberofday * multiSeason * (1 - percentDis);
        }
    }
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
