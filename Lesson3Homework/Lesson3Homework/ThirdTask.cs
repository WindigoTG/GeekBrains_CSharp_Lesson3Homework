using System;

//Олесов Максим

/*2. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.
Написать программу, демонстрирующую все разработанные элементы класса. Достаточно решить 2 задачи. Все программы сделать в одном решении.
** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
ArgumentException("Знаменатель не может быть равен 0");
Добавить упрощение дробей.*/

namespace Lesson3Homework
{
    class ThirdTask
    {
        public void Run()
        {
            View view = new View();
            view.Print("Задача 3. Работа с дробями");
            view.Print("\nОпределим первую дробь");
            Fraction frac1 = new Fraction();
            frac1.SetFraction();
            view.Print(frac1.ToString());

            view.Print("\nОпределим вторую дробь");
            Fraction frac2 = new Fraction();
            frac2.SetFraction();
            view.Print(frac2.ToString());

            Fraction frac3 = new Fraction();
            frac3.Add(frac1, frac2);
            view.Print($"\n({frac1.ToString()})  +  ({frac2.ToString()})  =  {frac3.ToString()}");
            frac3.Subtract(frac1, frac2);
            view.Print($"\n({frac1.ToString()})  -  ({frac2.ToString()})  =  {frac3.ToString()}");
            frac3.Multiply(frac1, frac2);
            view.Print($"\n({frac1.ToString()})  *  ({frac2.ToString()})  =  {frac3.ToString()}");
            frac3.Divide(frac1, frac2);
            view.Print($"\n({frac1.ToString()})  /  ({frac2.ToString()})  =  {frac3.ToString()}");

            view.Pause();
        }
    }

    class Fraction
    { 
        public int num { get; private set; }
        public int denom { get; private set; }

        public Fraction() { }
        public Fraction(Fraction f)
        {
            num = f.num;
            denom = f.denom;
        }

        public void SetFraction()
        {
            View view = new View();
            view.Print("Введите числитель дроби");
            bool success = false;
            do
            {
                try
                {
                    this.num = int.Parse(Console.ReadLine());
                    success = true;
                }
                catch (FormatException e)
                {
                    view.Print(e.Message);
                }
                catch (OverflowException e)
                {
                    view.Print(e.Message);
                }
            } while (!success);
            success = false;
            view.Print("Введите знаменатель дроби");
            do
            {
                try
                {
                    this.denom = int.Parse(Console.ReadLine());
                    if (this.denom == 0)
                        throw new Exception("Знаменатель не может быть равен 0");
                    success = true;
                }
                catch (FormatException e)
                {
                    view.Print(e.Message);
                }
                catch (OverflowException e)
                {
                    view.Print(e.Message);
                }
                catch (Exception e)
                {
                    view.Print(e.Message);
                }
            } while (!success);

            //Если знаменатель отрицательный, передаем знак - числителю
            if (this.denom < 0)
            {
                this.num = -this.num;
                this.denom = -this.denom;
            }
            Simplify();
        }

        public override string ToString()
        {
            if (this.num == 0)
                return "0";
            else
            {
                //Для сравнения числителя и знаменателя с целью выделения целой части создаем временную переменную, содержащую значение числителя, и выносим знак в отдельную переменную.
                int tempNum;
                int tempSign =1;

                if (this.num < 0)
                {
                    tempNum = -this.num;
                    tempSign = -1;
                }
                else
                    tempNum = this.num;

                if (tempNum > this.denom)
                {

                    return $"{tempNum / this.denom * tempSign} {tempNum % this.denom}/{this.denom}";
                }
                else
                    return $"{tempNum * tempSign}/{this.denom}";
            }
        }

        private void Simplify()
        {
            //Проверяем, деляться ли числитель и знаменатель на 2/3/5/7 без остатка
            //Если да, то разделяем и повторяем до победного
            if (this.num % 2 == 0 && this.denom % 2 == 0)
            {
                this.num /= 2;
                this.denom /= 2;
                Simplify();
            }
            if (this.num % 3 == 0 && this.denom % 3 == 0)
            {
                this.num /= 3;
                this.denom /= 3;
                Simplify();
            }
            if (this.num % 5 == 0 && this.denom % 5 == 0)
            {
                this.num /= 5;
                this.denom /= 5;
                Simplify();
            }
            if (this.num % 7 == 0 && this.denom % 7 == 0)
            {
                this.num /= 7;
                this.denom /= 7;
                Simplify();
            }
        }

        public void Add(Fraction f1, Fraction f2)
        {
            Fraction tempFrac1 = new Fraction(f1);
            Fraction tempFrac2 = new Fraction(f2);
            CompareDenom(tempFrac1,tempFrac2);
            this.num = tempFrac1.num + tempFrac2.num;
            this.denom = tempFrac1.denom;
            Simplify();
        }

        public void Subtract(Fraction f1, Fraction f2)
        {
            Fraction tempFrac1 = new Fraction(f1);
            Fraction tempFrac2 = new Fraction(f2);
            CompareDenom(tempFrac1, tempFrac2);
            this.num = tempFrac1.num - tempFrac2.num;
            this.denom = tempFrac1.denom;
            Simplify();
        }

        public void Multiply(Fraction f1, Fraction f2)
        {
            Fraction tempFrac1 = new Fraction(f1);
            Fraction tempFrac2 = new Fraction(f2);
            this.num = tempFrac1.num * tempFrac2.num;
            this.denom = tempFrac1.denom * tempFrac2.denom;
            Simplify();
        }

        public void Divide(Fraction f1, Fraction f2)
        {
            Fraction tempFrac1 = new Fraction(f1);
            Fraction tempFrac2 = new Fraction(f2);
            this.num = tempFrac1.num * tempFrac2.denom;
            this.denom = tempFrac1.denom * tempFrac2.num;
            Simplify();
        }

        private void CompareDenom(Fraction f1, Fraction f2)
        {
            int temp = f1.denom;
            f1.num *= f2.denom;
            f1.denom *= f2.denom;
            f2.num *= temp;
            f2.denom *= temp;
        }
    }
}
