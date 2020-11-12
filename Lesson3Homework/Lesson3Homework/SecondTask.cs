using System;

//Олесов Максим

//а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;
//б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;

namespace Lesson3Homework
{
    class SecondTask
    {
        public void Run()
        {
            View view = new View();
            view.Print("Задача 2. Подсчет суммы нечетных положительных чисел среди введённых\nПоследовательно вводите числа по одному. Для завершения ввода введите 0");
            int sum = 0;
            int inputResult;
            bool stop = false;
            string numbers = "";

            do
            {
                try
                {
                    inputResult = int.Parse(Console.ReadLine());
                    if (inputResult != 0)
                        numbers += $"{inputResult}, ";
                    if (inputResult > 0 && inputResult % 2 != 0)
                        sum += inputResult;
                    if (inputResult == 0)
                        stop = true;
                }
                catch (FormatException e)
                {
                    view.Print(e.Message);
                }
                catch (OverflowException e)
                {
                    view.Print(e.Message);
                }
            } while (!stop);
            view.Print($"\nВы ввели последовательность чисел:\n{numbers.TrimEnd(',',' ')}");
            view.Print($"\nСумма нечетных положительных чисел равна {sum}");

            view.Pause();
        }
    }
}
