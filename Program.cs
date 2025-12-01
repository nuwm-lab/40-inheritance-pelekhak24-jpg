using System;
using System.Linq;

namespace VectorMatrixApp
{
    // Завдання 2: Створити клас "одновимірний вектор розмірності 4"
    public class Vector4
    {
        // 5. Дотримання принципу інкапсуляції: поле приватне
        // 4. Code Convention: приватні поля іменуються з нижнім підкресленням та camelCase
        private int[] _elements;
        protected const int Size = 4; // Константи PascalCase

        public Vector4()
        {
            _elements = new int[Size];
        }

        // Метод 1: Завдання елементів вектора (для прикладу заповнюємо випадковими числами)
        // Використовуємо virtual, щоб дозволити перезапис (перевантаження) у спадкоємця
        public virtual void SetElements()
        {
            Random rnd = new Random();
            Console.WriteLine("Generating Vector elements...");
            for (int i = 0; i < Size; i++)
            {
                _elements[i] = rnd.Next(1, 100);
            }
        }

        // Метод 2: Виведення вектора на екран
        public virtual void Print()
        {
            Console.WriteLine("Vector (1x4):");
            Console.WriteLine("[ " + string.Join(", ", _elements) + " ]");
            Console.WriteLine();
        }

        // Метод 3: Знаходження максимального елемента
        public virtual int GetMaxElement()
        {
            // Використовуємо LINQ для знаходження максимуму або звичайний цикл
            int max = _elements[0];
            foreach (var item in _elements)
            {
                if (item > max) max = item;
            }
            return max;
        }
    }

    // Завдання: Описати похідний клас "матриця" розмірності 4x4
    public class Matrix4x4 : Vector4
    {
        // Інкапсуляція: окреме сховище для матриці
        private int[,] _matrixElements;

        public Matrix4x4()
        {
            _matrixElements = new int[Size, Size];
        }

        // Перевантаження (override) методу завдання елементів
        public override void SetElements()
        {
            Random rnd = new Random();
            Console.WriteLine("Generating Matrix elements...");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _matrixElements[i, j] = rnd.Next(1, 100);
                }
            }
        }

        // Перевантаження методу виведення на екран
        public override void Print()
        {
            Console.WriteLine("Matrix (4x4):");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"{_matrixElements[i, j],4} "); // форматування виводу
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Перевантаження (override) методу пошуку максимуму
        public override int GetMaxElement()
        {
            int max = _matrixElements[0, 0];
            foreach (var item in _matrixElements)
            {
                if (item > max) max = item;
            }
            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Встановлення кодування для коректного відображення кирилиці (якщо потрібно)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Робота з класом Вектор ===");
            // Створити об'єкт класу "одновимірний вектор"
            Vector4 myVector = new Vector4();
            myVector.SetElements();
            myVector.Print();

            int maxVector = myVector.GetMaxElement();
            Console.WriteLine($"Максимальний елемент вектора: {maxVector}");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("\n=== Робота з класом Матриця ===");
            // Створити об'єкт класу "матриця"
            Matrix4x4 myMatrix = new Matrix4x4();
            myMatrix.SetElements();
            myMatrix.Print();

            int maxMatrix = myMatrix.GetMaxElement();
            Console.WriteLine($"Максимальний елемент матриці: {maxMatrix}");

            Console.ReadLine(); // Щоб консоль не закрилась одразу
        }
    }
}