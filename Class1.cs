using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2_csharp
{
    internal class Money
    {
        //поля
        private uint rubles;
        private byte kopeks;

        //конструктор
        public Money(uint rubles, byte kopeks)
        {
            this.rubles = rubles;
            this.kopeks = kopeks;
        }

        //метод для добавления копеек
        public Money AddKopeks(uint addKopeks)
        {
            uint totalKopeks = this.kopeks + addKopeks;
            uint newRubles = this.rubles + totalKopeks / 100;
            byte newKopeks = (byte)(totalKopeks % 100);
            return new Money(newRubles, newKopeks);
        }




        // Метод вычитания двух денежных величин
        public Money Subtract(Money other)
        {
            // Сначала вычислим общую сумму копеек обеих величин
            int totalKopeks = (int)this.rubles * 100 + this.kopeks;
            int otherTotalKopeks = (int)other.rubles * 100 + other.kopeks;

            // Вычисляем разницу
            int differenceInKopeks = totalKopeks - otherTotalKopeks;

            // Если разница отрицательная, выбрасываем исключение
            if (differenceInKopeks <= 0)
            {
                return new Money(0, 0);
            }

            // Переводим разницу обратно в рубли и копейки
            uint resultRubles = (uint)(differenceInKopeks / 100);
            byte resultKopeks = (byte)(differenceInKopeks % 100);

            return new Money(resultRubles, resultKopeks);
        }



        //перегрузка метода ToString()
        public override string ToString()
        {
            return $"{rubles} руб. {kopeks} коп.";
        }



        //задание 3
        // унарная операция уменьшения на 1 копейку
        public static Money operator --(Money money)
        {
            Money oneKopeck = new Money(0, 2);

            return money.Subtract(oneKopeck);
        }

        // унарная операция увеличения на 1 копейку
        public static Money operator ++(Money money)
        {
            // Увеличиваем копейки на 1
            byte newKopeks = (byte)(money.kopeks + 1);

            // Проверяем, не превысили ли мы максимальное значение для байтов (255)
            if (newKopeks == 0)  // Переполнение произошло, нужно увеличить рубли
            {
                return new Money(money.rubles + 1, 0);
            }
            else
            {
                return new Money(money.rubles, newKopeks);
            }
        }
        //операции приведения типа
        public static explicit operator uint(Money m)
        {
            return m.rubles;
        }

        public static implicit operator double(Money m)
        {
            return m.kopeks / 100.0;
        }


        // Бинарные операции с беззнаковыми целыми числами (вычитание)
        public static Money operator -(Money m, uint subKopeks)
        {
            // Преобразуем сумму копеек, которую хотим вычесть, в Money объект
            Money subAmount = new Money(0, (byte)subKopeks);

            // Возвращаем результат вычитания
            return m.Subtract(subAmount);
        }

        public static Money operator -(uint subKopeks, Money m)
        {
            // Аналогично первому случаю, но вычитаемое идет слева
            Money subAmount = new Money(0, (byte)subKopeks);

            // Возвращаем результат вычитания
            return m.Subtract(subAmount);
        }
        public static Money operator -(Money left, Money right)
        {
            // Сначала вычислим общую сумму копеек обеих величин
            int totalLeftKopeks = (int)left.rubles * 100 + left.kopeks;
            int totalRightKopeks = (int)right.rubles * 100 + right.kopeks;

            // Вычисляем разницу
            int differenceInKopeks = totalLeftKopeks - totalRightKopeks;

            // Если разница отрицательная, возвращаем нули
            if (differenceInKopeks < 0)
            {
                return new Money(0, 0);
            }

            // Переводим разницу обратно в рубли и копейки
            uint resultRubles = (uint)(differenceInKopeks / 100);
            byte resultKopeks = (byte)(differenceInKopeks % 100);

            return new Money(resultRubles, resultKopeks);
        }
    }
}