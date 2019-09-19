using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLab
{
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
}
