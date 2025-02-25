using System;

internal class Genetic
{
    private char gen_1;
    private char gen_2;

    // Конструктор
    public Genetic(char a, char b)
    {
        gen_1 = a;
        gen_2 = b;
    }

    // Конструктор копирования
    public Genetic(Genetic genetic)
    {
        gen_1 = genetic.gen_1;
        gen_2 = genetic.gen_2;
    }

    // Метод, создающий строку из полей
    public string CreateString()
    {
        return $"{gen_1}{gen_2}";
    }

    // Переопределение ToString()
    public override string ToString()
    {
        return $"Первый ген - {gen_1}, второй ген - {gen_2}";
    }

    // Свойства для доступа к приватным полям
    public char Gen_1 => gen_1;
    public char Gen_2 => gen_2;
}

// Дочерний класс
internal class GeneticDetails : Genetic
{
    public GeneticDetails(char a, char b) : base(a, b) { }

    // Метод для проверки доминирования гена
    public static void DomRec(char c)
    {
        if (char.IsUpper(c))
        {
            Console.WriteLine($"Ген {c} доминантный");
        }
        else 
        {
            Console.WriteLine($"Ген {c} рецессивный");
        }
        
    }

    // Новый метод для определения гомо- или гетерозиготы
    public static void HomozygousOrHeterozygous(char gen1, char gen2)
    {
        bool bothUpper = char.IsUpper(gen1) && char.IsUpper(gen2);
        bool bothLower = char.IsLower(gen1) && char.IsLower(gen2);

        if (bothUpper || bothLower)
        {
            Console.WriteLine($"Гены {gen1}{gen2} являются гомозиготой");
        }
        else
        {
            Console.WriteLine($"Гены {gen1}{gen2} являются гетерозиготой");
        }
    }
}

class Program
{
    static void Main()
    {
        char gen1, gen2;

        // Циклы для проверки правильности ввода генов
        while (true)
        {
            Console.Write("Введите первый ген (одну букву): ");
            string input = Console.ReadLine().Trim();

            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                gen1 = input[0];
                break;
            }
            else
            {
                Console.WriteLine("Ошибка: введён неправильный символ. Пожалуйста, введите одну букву.");
            }
        }

        while (true)
        {
            Console.Write("Введите второй ген (одну букву): ");
            string input = Console.ReadLine().Trim();

            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                gen2 = input[0];
                break;
            }
            else
            {
                Console.WriteLine("Ошибка: введён неправильный символ. Пожалуйста, введите одну букву.");
            }
        }

        // Остальная часть программы остаётся такой же
        Genetic genetic = new Genetic(gen1, gen2);

        Console.WriteLine("\nИнформация о генах:");
        Console.WriteLine(genetic.ToString());
        Console.WriteLine($"Строка из генов: {genetic.CreateString()}");

        GeneticDetails.DomRec(gen1);
        GeneticDetails.DomRec(gen2);

        GeneticDetails.HomozygousOrHeterozygous(gen1, gen2);

        Genetic copyGenetic = new Genetic(genetic);
        Console.WriteLine($"\nКопия объекта: {copyGenetic.ToString()}");

        Console.WriteLine($"Свойства копии: Первый ген - {copyGenetic.Gen_1}, Второй ген - {copyGenetic.Gen_2}");

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}