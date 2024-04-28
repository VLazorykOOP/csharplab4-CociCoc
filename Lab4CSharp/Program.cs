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
            
           

            // Приклад створення об'єктів класу VectorInt
            Console.WriteLine("Exercise 2 ");
            VectorInt vec1 = new VectorInt(3, 5); // Vector of size 3 initialized with value 5
            VectorInt vec2 = new VectorInt(3); // Vector of size 3 initialized with zeros
            vec2.Input(); // Input values for vec2 from user

            Console.WriteLine("Vector 1: ");
            vec1.Output();
            Console.WriteLine("Vector 2: ");
            vec2.Output();

            VectorInt vec3 = vec1 + vec2; // Adding two vectors
            Console.WriteLine("Vector 3 (Sum): ");
            vec3.Output();

            ++vec1; // Increment all elements of vec1
            Console.WriteLine("Vector 1 after increment: ");
            vec1.Output();

            Console.WriteLine("Number of vectors created: " + VectorInt.GetNumVec());

            // Приклад класів Person, Student, Teacher, DepartmentHead
            Person[] people = new Person[]
            {
                new Student { Name = "John", Age = 20, StudentID = "S12345", Major = "Computer Science" },
                new Student { Name = "Alice", Age = 21, StudentID = "S23456", Major = "Mathematics" },
                new Teacher { Name = "Mr. Smith", Age = 35, Department = "Computer Science", Subject = "Programming" },
                new Teacher { Name = "Ms. Johnson", Age = 40, Department = "Mathematics", Subject = "Calculus" },
                new DepartmentHead { Name = "Dr. Brown", Age = 50, Department = "Computer Science", Subject = "Computer Science", YearsOfExperience = 20 },
                new DepartmentHead { Name = "Dr. White", Age = 55, Department = "Mathematics", Subject = "Mathematics", YearsOfExperience = 25 }
            };

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

    // Клас VectorInt з операціями векторних обчислень
    class VectorInt
    {
        private int[] IntArray; // масив
        private uint size; // розмір вектора
        private int codeError; // код помилки
        private static uint num_vec; // кількість векторів

        // Конструктори
        public VectorInt()
        {
            size = 1;
            IntArray = new int[size];
            IntArray[0] = 0;
            codeError = 0;
            num_vec++;
        }

        public VectorInt(uint s)
        {
            size = s;
            IntArray = new int[size];
            for (uint i = 0; i < size; ++i)
            {
                IntArray[i] = 0;
            }
            codeError = 0;
            num_vec++;
        }

        public VectorInt(uint s, int init_value)
        {
            size = s;
            IntArray = new int[size];
            for (uint i = 0; i < size; ++i)
            {
                IntArray[i] = init_value;
            }
            codeError = 0;
            num_vec++;
        }

        // Деструктор
        ~VectorInt()
        {
            num_vec--;
        }

        // Методи
        public void Input()
        {
            for (uint i = 0; i < size; ++i)
            {
                Console.WriteLine("Enter element " + i + ": ");
                IntArray[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void Output()
        {
            for (uint i = 0; i < size; ++i)
            {
                Console.Write(IntArray[i] + " ");
            }
            Console.WriteLine();
        }

        public void Assign(int value)
        {
            for (uint i = 0; i < size; ++i)
            {
                IntArray[i] = value;
            }
        }

        public static uint GetNumVec()
        {
            return num_vec;
        }

        // Властивості
        public uint Size
        {
            get { return size; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Індексатор
        public int this[uint index]
        {
            get
            {
                if (index >= size)
                {
                    codeError = -1;
                    return IntArray[0];
                }
                return IntArray[index];
            }
            set
            {
                if (index < size)
                {
                    IntArray[index] = value;
                }
            }
        }

        // Перевантаження унарних операцій
        public static VectorInt operator ++(VectorInt vec)
        {
            for (uint i = 0; i < vec.size; ++i)
            {
                ++vec.IntArray[i];
            }
            return vec;
        }

        // Перевантаження бінарних операцій
        public static VectorInt operator +(VectorInt vec1, VectorInt vec2)
        {
            uint newSize = (vec1.size > vec2.size) ? vec1.size : vec2.size;
            VectorInt result = new VectorInt(newSize);
            for (uint i = 0; i < newSize; ++i)
            {
                result.IntArray[i] = vec1[i] + vec2[i];
            }
            return result;
        }
    }
}
