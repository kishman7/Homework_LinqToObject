using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //підключення українських букв
            //створюємо масив City
            var cities = new City[]
            {
                new City {Name = "Rivne", Country="Ukraine", Population = 250000, IsCapital = false },
                new City{ Name = "Warsaw", Country="Poland", Population = 1800000, IsCapital = true },
                new City{ Name = "Lviv", Country="Ukraine", Population = 720000, IsCapital = false },
                new City{ Name = "Krakow", Country="Poland", Population = 780000, IsCapital = false },
                new City{ Name = "Odessa", Country="Ukraine", Population = 1020000, IsCapital = false },
                new City{ Name = "London", Country="Great Britain", Population = 8900000, IsCapital = true },
                new City{ Name = "Paris", Country="France", Population = 2180000, IsCapital = true },
                new City{ Name = "Berlin", Country="Germany", Population = 3600000, IsCapital = true },
                new City{ Name = "Wroclaw", Country="Poland", Population = 640000, IsCapital = false },
                new City{ Name = "Kyiv", Country="Ukraine", Population = 3000000, IsCapital = true },
                new City{ Name = "Munich", Country="Germany", Population = 1480000, IsCapital = false },
                new City{ Name = "Dnipro", Country="Ukraine", Population = 980000, IsCapital = false },
                new City{ Name = "Cologne", Country="Germany", Population = 1000000, IsCapital = false }
            };
            //створюємо масив int
            var numbers = new[] { 2, 9, 47, 69, 20, -1, 13, -26, 37, -40, 18, 70, -31, 7, -47, -7, 1 };

            //Використовуючи синтаксис запитів вивести на екран:
            //> Із "cities"
            //   - інформацію про столиці(назву, країну та населення);
            Console.WriteLine("Інформація про столиці (назва, країна та населення):");
            //Console.ReadKey();
            var capital = from cap in cities
                          select cap ;
            foreach (var item in capital) //результат виводимо на екран
            {
                Console.WriteLine($" {item.Name}, {item.Country}, {item.Population}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //- назви міст, що містять букву "і" у назві міста;
            Console.WriteLine("Назва міст, що містять букву \"і\" у назві міста:");
            //Console.ReadKey();
            var capital1 = from cap in cities
                           where cap.Name.Contains("i")
                           select cap;
            foreach (var item in capital1)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //- назви столиць разом із населенням у порядку спадання населення;
            Console.WriteLine("Назва столиць разом із населенням у порядку спадання населення:");
            //Console.ReadKey();
            capital = from cap in cities
                      orderby cap.Population
                      select cap;
            foreach (var item in capital)
            {
                Console.WriteLine($"{item.Name}, {item.Population}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //- назви країн, що містять міста, назви яких закінчуютсья на букву "w";
            Console.WriteLine("Назва країн, що містять міста, назви яких закінчуютсья на букву \"w\":");
            //Console.ReadKey();
            capital = from cap in cities
                      where cap.Name.EndsWith("w")
                      select cap;
            foreach (var item in capital)
            {
                Console.WriteLine($"{item.Country}, {item.Name}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //- назви міст, де назва країни закінчується на "e", а назви міст починаються на букву "a";
            Console.WriteLine("Назва міст, де назва країни закінчується на \"e\", а назви міст починаються на букву \"R\":");
            //Console.ReadKey();
            capital = from cap in cities
                      where cap.Country.EndsWith("e") && cap.Name.StartsWith("R")
                      select cap;
            foreach (var item in capital)
            {
                Console.WriteLine($"{item.Country}, {item.Name}");

            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //Із "numbers"
            //-всі непарні числа;
            //-додатні числа із "numbers" у порядку зростання;
            //-від'ємні числа із "numbers" у порядку спадання.

            //-всі непарні числа;
            Console.WriteLine("Всі непарні числа:");
            //Console.ReadKey();

            var num = from n in numbers
                      where n % 2 != 0
                      select n;
            foreach (var item in num)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-додатні числа із "numbers" у порядку зростання;
            Console.WriteLine("Додатні числа із \"numbers\" у порядку зростання:");
            //Console.ReadKey();
            num = from n in numbers
                  where n > 0
                  orderby n ascending
                  select n;
            foreach (var item in num)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-від'ємні числа із "numbers" у порядку спадання.
            Console.WriteLine("Від'ємні числа із \"numbers\" у порядку спадання:");
            //Console.ReadKey();
            num = from n in numbers
                  where n < 0
                  orderby n descending
                  select n;
            foreach (var item in num)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //Використовуючи синтаксис методів:
            //> Із "cities"
            //- кількість столиць;
            //-назви країн;
            //-кількість міст із населенням більше  1 000 000;
            //-назви міст із населенням менше  1 000 000;
            //-назви країн, у яких назви міст закінчуютсья на букву "w" у назві міста;
            //-кількість населення в найменш заселеній столиці;
            //-назви міст, крім перших і останніх чотирьох;

            //- кількість столиць;
            Console.WriteLine("Кількість столиць:");
            //Console.ReadKey();
            var capital2 = cities.Count();
            Console.WriteLine(capital2);
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-назви країн;
            Console.WriteLine("Назва країн:");
            //Console.ReadKey();
            foreach (var item in cities)
            {
                Console.WriteLine(item.Country);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-кількість міст із населенням більше  1 000 000;
            Console.WriteLine("Кількість міст із населенням більше  1 000 000:");
            //Console.ReadKey();
            var population = cities.Where(x => x.Population > 1000000).Count();
            Console.WriteLine(population);
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-назви міст із населенням менше  1 000 000;
            Console.WriteLine("Назви міст із населенням менше  1 000 000:");
            //Console.ReadKey();
            var city = cities.Where(x => x.Population < 1000000);
            foreach (var item in city)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-назви країн, у яких назви міст закінчуютсья на букву "w" у назві міста;
            Console.WriteLine("Назви країн, у яких назви міст закінчуютсья на букву \"w\" у назві міста:");
            //Console.ReadKey();
            var country = cities.Where(x => x.Name.EndsWith("w"));
            foreach (var item in country)
            {
                Console.WriteLine($"{item.Country}, {item.Name}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-кількість населення в найменш заселеній столиці;
            Console.WriteLine("Kількість населення в найменш заселеній столиці:");
            //Console.ReadKey();
            var population2 = cities.Min(x => x.Population);
            foreach (var item in cities)
            {
                if (item.Population == population2)
                {
                    Console.WriteLine($"{item.Name}, {population2}");
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-назви міст, крім перших і останніх чотирьох;
            Console.WriteLine("Назви міст, крім перших і останніх чотирьох:");
            //Console.ReadKey();
            var city2 = cities.Skip(4).Take(5);

            foreach (var item in city2)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //Із "numbers"
            //-мінімальне, максимальне та середнє значення;
            //-чи містить масив значення "-31";
            //-останнє парне значення.

            //-мінімальне, максимальне та середнє значення;
            Console.WriteLine("Мінімальне, максимальне та середнє значення:");
            Console.ReadKey();
            Console.WriteLine($"Мінімальне: {numbers.Min()}\nМаксимальне: {numbers.Max()}\nСереднє: {Math.Round(numbers.Average(),2)}");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-чи містить масив значення "-31";
            Console.WriteLine("Ваш масив:");
            foreach (var item in numbers)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Введіть потрібне значення: ");
            int temp = int.Parse(Console.ReadLine());
            Console.WriteLine($"Чи містить масив значення \"{temp}\"?:");
            var number = numbers.Contains(temp);
            if (number ==true)
            {
                Console.WriteLine($"Так, число \"{temp}\" міститься в масиві.");
            }
            else
            {
                Console.WriteLine($"Числа \"{temp}\" в масиві немає!");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

            //-останнє парне значення.
            Console.WriteLine("Останнє парне значення: ");
            Console.ReadKey();
            var parnumber = numbers.Where(x => x % 2 == 0).LastOrDefault();
            Console.WriteLine(parnumber);

        }
    }
}
