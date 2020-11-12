//Олесов Максим

//1.а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;
//б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;

namespace Lesson3Homework
{
    struct ComplexStruct
    {
        public double im;
        public double re;

        public ComplexStruct Plus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public ComplexStruct Minus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public ComplexStruct Multi(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public override string ToString()
        {
            if (im <0)
                return re + "" + im + "i";
            return re + "+" + im + "i";
        }
    }

    class ComplexClass
    {
        public double im { get; set; }
        public double re { get; set; }

        public ComplexClass()
        {
            im = 0;
            re = 0;
        }

        public ComplexClass(double im, double re)
        {
            this.im = im;
            this.re = re;
        }
        public ComplexClass Plus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }

        public ComplexClass Minus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = im - x2.im;
            x3.re = re - x2.re;
            return x3;
        }

        public ComplexClass Multi(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = re * x2.im + im * x2.re;
            x3.re = re * x2.re - im * x2.im;
            return x3;
        }

        public override string ToString()
        {
            if (im < 0)
                return re + "" + im + "i";
            return re + "+" + im + "i";
        }
    }

    class FirstTask
    {
        public void Run()
        {
            View view = new View();
            view.Print("Задача 1. Работа с классом и структурой комплексных чисел\n\nРеализация через структуру\n");
            ComplexStruct comStruct1 = new ComplexStruct();
            comStruct1.re = view.GetDouble("Введите действительную часть первого числа");
            comStruct1.im = view.GetDouble("Введите мнимую часть первого числа");
            ComplexStruct comStruct2 = new ComplexStruct();
            comStruct2.re = view.GetDouble("Введите действительную часть второго числа");
            comStruct2.im = view.GetDouble("Введите мнимую часть второго числа");
            view.Print($"\nКомплексное число 1 = {comStruct1.ToString()}\nКомплексное число 2 = {comStruct2.ToString()}\n");
            view.Print($"({comStruct1.ToString()}) + ({comStruct2.ToString()}) = {comStruct1.Plus(comStruct2).ToString()}");
            view.Print($"({comStruct1.ToString()}) - ({comStruct2.ToString()}) = {comStruct1.Minus(comStruct2).ToString()}");
            view.Print($"({comStruct1.ToString()}) * ({comStruct2.ToString()}) = {comStruct1.Multi(comStruct2).ToString()}");

            view.Print("\n---------------------------------------------------------\n\nРеализация через класс\n");
            ComplexClass comClass1 = new ComplexClass();
            comClass1.re = view.GetDouble("Введите действительную часть первого числа");
            comClass1.im = view.GetDouble("Введите мнимую часть первого числа");
            ComplexClass comClass2 = new ComplexClass();
            comClass2.re = view.GetDouble("Введите действительную часть второго числа");
            comClass2.im = view.GetDouble("Введите мнимую часть второго числа");
            view.Print($"\nКомплексное число 1 = {comClass1.ToString()}\nКомплексное число 2 = {comClass2.ToString()}\n");
            view.Print($"({comClass1.ToString()}) + ({comClass2.ToString()}) = {comClass1.Plus(comClass2).ToString()}");
            view.Print($"({comClass1.ToString()}) - ({comClass2.ToString()}) = {comClass1.Minus(comClass2).ToString()}");
            view.Print($"({comClass1.ToString()}) * ({comClass2.ToString()}) = {comClass1.Multi(comClass2).ToString()}");

            view.Pause();
        }
    }
}
