using System;

namespace Lab4CSharp
{
    /// <summary>
    ///  Top-level statements 
    ///  Код програми (оператори)  вищого рівня
    /// </summary>
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab4 C# ");
            AnyFunc();

            Console.WriteLine("Problems 1 ");
            AnyFunc();

            //  приклад класів
            UserClass cl = new UserClass(" UserClass top-level ");
            Lab4CSharp.UserClass cl2 = new Lab4CSharp.UserClass(" UserClass namespace Lab4CSharp ");
            Console.WriteLine(cl + "   " + cl2 + "   ");

            // Вправа 2
            // Створення масиву об'єктів базового класу Person
            Person[] people = new Person[]
            {
                new Student { Name = "John", Age = 20, StudentID = "S12345", Major = "Computer Science" },
                new Student { Name = "Alice", Age = 21, StudentID = "S23456", Major = "Mathematics" },
                new Teacher { Name = "Mr. Smith", Age = 35, Department = "Computer Science", Subject = "Programming" },
                new Teacher { Name = "Ms. Johnson", Age = 40, Department = "Mathematics", Subject = "Calculus" },
                new DepartmentHead { Name = "Dr. Brown", Age = 50, Department = "Computer Science", Subject = "Computer Science", YearsOfExperience = 20 },
                new DepartmentHead { Name = "Dr. White", Age = 55, Department = "Mathematics", Subject = "Mathematics", YearsOfExperience = 25 }
            };

            // Виведення масиву впорядкованого за віком
            Console.WriteLine("People sorted by age:");
            Array.Sort(people, (x, y) => x.Age.CompareTo(y.Age));
            foreach (var person in people)
            {
                person.Show();
            }
        }

        /// <summary>
        /// 
        ///  Top-level statements must precede namespace and type declarations.
        /// At the top-level methods/functions can be defined and used
        /// На верхньому рівні можна визначати та використовувати методи/функції
        /// </summary>
        static void AnyFunc()
        {
            Console.WriteLine(" Some function in top-level");
        }
    }

    /// <summary>
    /// 
    /// Top-level statements must precede namespace and type declarations.
    /// Оператори верхнього рівня мають передувати оголошенням простору імен і типу.
    /// Створення класу(ів) або оголошенням простору імен є закіченням  іструкцій верхнього рівня
    /// 
    /// </summary>
    class UserClass
    {
        public string UserName { get; set; }

        public UserClass(string userName)
        {
            UserName = userName;
        }
    }

    internal class Person
    {
        public string Name { get; set; } = string.Empty; // Initialize to avoid null reference
        public int Age { get; set; }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    internal class Student : Person
    {
        public string StudentID { get; set; } = string.Empty; // Initialize to avoid null reference
        public string Major { get; set; } = string.Empty; // Initialize to avoid null reference

        public override void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Student ID: {StudentID}, Major: {Major}");
        }
    }

    internal class Teacher : Person
    {
        public string Department { get; set; } = string.Empty; // Initialize to avoid null reference
        public string Subject { get; set; } = string.Empty; // Initialize to avoid null reference

        public override void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Subject: {Subject}");
        }
    }

    internal class DepartmentHead : Teacher
    {
        public int YearsOfExperience { get; set; }

        public override void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Subject: {Subject}, Years of Experience: {YearsOfExperience}");
        }
    }
}
