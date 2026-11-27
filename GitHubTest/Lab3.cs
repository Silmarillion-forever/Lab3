using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class Lab3
{
    public static void Lab3_6var()
    {
        int[] mass = new int[] { 1,2,3,4};
        int[] arr2 = mass;
        mass[0] = 50;

        Console.WriteLine(String.Join("", mass));
        Console.WriteLine(String.Join("", arr2));


        Console.WriteLine("----------------LAB3-----------------");
        bool shouldClose = false;
        while (!shouldClose)
        {
            int variant = vvod("Выберете вариант действия из меню:\n1.Отгадай ответ\t2.Об авторе\t3.Сортировка массива\t4.Выход\nВаш избранник: ");
            switch (variant)
            {
                case 1: Var1(); break;
                case 2: Var2(); break;
                case 3: Var3(); break;
                case 4: shouldClose = ExitLab(); break;
                default: Console.WriteLine("Нет! Нет! Нет! Ты не сказал волшебное слово!"); break;
            }
        }
        if (!shouldClose) Console.WriteLine("Ну что сломал систему?! Чувствуешь удолетворение?!");
    }
    static void Var1()
    {
        float a = floatVvod("Введите а: ");
        float b = floatVvod("Введите b: ");
        float f; 
        try
        {
            f = funcSixVar(a, b);
            ugadai(f);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Ой! Получилось деление на ноль!");
        }
        finally
        {
            Console.WriteLine("Возвращаемся в меню");
        }
    }
    static void Var2()
    {
        Console.WriteLine("Изготовил: Шагиахметов Амир Маратович\nГруппа: 6105-090301D");
    }
    static void Var3()
    {

        int[] arr = new int[] {1,2,3,4,50 };
        int sum = 0;
        for (int i = 0; i < arr.Length; i++) sum+= arr[i];
        Console.WriteLine(sum / arr.Length);

        Console.WriteLine("То бишь пожелал узреть запретную магию? Приступим:");
        uint len = uvvod("Задай размер массива: ");
        if (len != 0)
        {
            int[] firstMass = createMass(len);
            int[] secondMass = copyMass(firstMass);
            outputMass(1, firstMass);
            outputMass(2, secondMass);
            Stopwatch samer = Stopwatch.StartNew();
            gnomSorted(firstMass);
            samer.Stop(); 
            
            long firstTicks = samer.ElapsedTicks; long firstMs = samer.ElapsedMilliseconds;
            samer.Restart();
            secondMass = shellaSorted(secondMass);
            samer.Stop(); 
            long secongTicks = samer.ElapsedTicks; long secondMs = samer.ElapsedMilliseconds;
            Console.WriteLine($"Гномья сортировка длилась: {firstMs} мс\t{firstTicks} тиков");
            Console.WriteLine($"Сортировка Шелла длилась: {secondMs} мс\t{secongTicks} тиков");
            if (firstTicks > secongTicks) Console.WriteLine("Сортировка Шелла быстрее, чем Гномья сортировка");
            else Console.WriteLine("Гномья сортировка быстрее, чем Сортировка Шелла");
            outputMass(1, firstMass);
            outputMass(2, secondMass);
        }
    }
    static bool ExitLab()
    {
        Console.WriteLine("Неужели решил выйти?\t Вы уверены?\n«д» - выйти из программы\n«н» - остаться в программе");
        Console.Write("Ваш выбор: "); string answer = Console.ReadLine(); bool ret = false;
        while (answer != "д" && answer != "н")
        {
            Console.WriteLine("Ошибка! Я ниче не понимаю, так как ты ввел " + answer);
            Console.Write("Попробуй еще раз: "); answer = Console.ReadLine();
        }
        switch (answer)
        {
            case "д": ret = true; Console.WriteLine("Что-ж прощай"); break;
            case "н": ret = false; Console.WriteLine("Отлично! Остаемся!"); break;
        }
        return ret;
    }
    static float floatVvod(string predlog)
    {
        Console.Write(predlog); string buf = Console.ReadLine();
        float chis;
        while (!float.TryParse(buf, out chis))
        {
            Console.WriteLine("Ая-я-яй! Шалунишка! Попробуй еще раз: ");
            Console.Write(predlog); buf = Console.ReadLine();
        }
        return chis;
    }
    static float funcSixVar(float a,float b)
    {
        double fLong = Math.Sin((Math.Pow(a, 3) + Math.Pow(b, 5)) / (2 * Math.PI)) + Math.Cbrt(Math.Cos(a + b));
        return (float)Math.Round(fLong, 2);
    }
    static void ugadai(float answerRichtig)
    {
        bool isWin = false;
        for (int i = 3; i >= 0 && !isWin; i--)
        {
            float answer = floatVvod("Угадай ответ: ");
            if (Math.Round(answer, 2) == answerRichtig)
            {
                Console.WriteLine("Верно!!!!");
                isWin = true;
            }
            else Console.WriteLine($"Ваше очко уходит в зрительный зал!\t Осталость {i} попыток.");
        }
        if (isWin) Console.WriteLine("Поздравляю! Вы выйграли аааавтомобиль!");
        else Console.WriteLine($"Вы проиграли...\tА ведь правильный ответ: {answerRichtig}");
    }
    static int vvod(string predlog)
    {
        Console.Write(predlog); string buf = Console.ReadLine();
        int lengnt;
        while (!int.TryParse(buf, out lengnt))
        {
            Console.WriteLine("Ая-я-яй! Шалунишка! Попробуй еще раз: ");
            Console.Write(predlog); buf = Console.ReadLine();
        }
        if (lengnt == 0) Console.WriteLine("Массивы не могут быть созданы, так как длина массива 0");
        return lengnt;
    }
    static uint uvvod(string predlog)
    {
        Console.Write(predlog); string buf = Console.ReadLine();
        uint lengnt;
        while (!uint.TryParse(buf, out lengnt))
        {
            Console.WriteLine("Ая-я-яй! Шалунишка! Попробуй еще раз: ");
            Console.Write(predlog); buf = Console.ReadLine();
        }
        if (lengnt == 0) Console.WriteLine("Массивы не могут быть созданы, так как длина массива 0");
        return lengnt;
    }
    static int[] createMass(uint n)
    {
        Random rnd = new Random();
        int[] a = new int[n];
        for (int i = 0; i < n; i++)  a[i] = rnd.Next(-25,24);
        Console.WriteLine("Массивчик создан");
        return a;
    }
    static int[] copyMass(int[] a)
    {
        int len = a.Length;
        int[] aCopy = new int[len];
        for (int i = 0; i < len; i++) aCopy[i] = a[i];
        Console.WriteLine("Массивчик скопирован");
        return aCopy;
    }
    static void outputMass(int number, int[] a)
    {
        if (a.Length > 10)
        {
            Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            return;
        }
        Console.Write($"А вот и твой {number} массивчик: ");
        foreach (int i in a) Console.Write($"{i}\t");
        Console.Write('\n');
    }
    static void gnomSorted(int[] a)
    {
        int i = 0; int len = a.Length;
        while (i < len)
        {
            if (i == 0 || a[i] >= a[i - 1]) i++; 
            else
            {
                int vrem = a[i];
                a[i] = a[i - 1];
                a[--i] = vrem;
            }
        }
    }
    static int[] shellaSorted(int[] a)
    {
        int len = a.Length;
        for (int gap = len / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < len; i++)
            {
                int j = i;
                while (j >= gap && a[j] < a[j - gap])
                {
                    int vrem = a[j];
                    a[j] = a[j - gap];
                    a[j - gap] = vrem;
                    j -= gap;
                }
            }
        }
        return a;
    }
}
