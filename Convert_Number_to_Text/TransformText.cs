using System;
using System.Collections;

namespace Convert_Number_to_Text
{
    class Numbers
    {
        public string[] ones_digit = { "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
        public string[] tens_digit = { "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };
        public string hundred = "yüz";
        public string[] hundreds_digit = { "", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
        public string[] steps = { "bin", "milyon", "bilyar", "trilyon" };
    }

    class TransformText
    {
        public int digit_place;
        public string text;

        public TransformText(int x)
        {
            digit_place = DigitPlace(x);
            text = ConvertText(places(x));
        }

        // Parametre olarak places metodundan dönen değeri ve DigitPlace metodundan dönen değeri alır.
        // Gelen ArrayList nesnesinden verileri Numbers sınıfındaki dizilere göre düzenli bir şekilde işler.
        // Birler basamağından başlayarak ters bir şekilde ArrayList nesnesine aktarır. Değeri döndürmeden önce ters çevirir ve doğru sonucu döndürür.
        string ConvertText(ArrayList arraylist)
        {
            Numbers number = new Numbers();
            ArrayList text = new ArrayList(); // Döndürlecek olan ArrayList nesnesi.
            int h = 0, step_control = 0, zero_control = 0;
            
            foreach (int item in arraylist)
            {
                if (item == 0) //Veri 0 olunca dizilerde "-1" konumuna bakıldığından özel durum oluşmasını engelliyor.
                {
                    zero_control++;
                    if (zero_control == 3)  // Üst üste 3 tane sıfır girilirse "bin", "milyon" gibi ifadeleri silen koşul ifadesi.
                    {
                        Console.WriteLine("Berkay");
                        if (text.Count > 0)
                            text.RemoveAt(text.Count - 1);
                    }
                    else
                    {
                        if (h % 3 == 0 && h != 0)
                            text.Add(number.steps[step_control - 1]);
                    }


                    if (h % 3 == 2) // Döngünün sayılmaya devam edilmesini sağlar.
                    {
                        zero_control = 0;
                        step_control++;
                    }
                }
                else
                {
                    zero_control = 0;
                    if (h % 3 == 0 && h != 0) // Bin, milyon gibi ifadelerin eklenmesini sağlar. İkinci döngüden itibaren çalışır.
                        text.Add(number.steps[step_control - 1]);

                    if ((h % 3 == 0 || h == 0) && (item != 1 || step_control != 1)) // Birler basamağını ekler. Eğer binler basamağında 1 bulunan bir sayı girilirse "bir" yazısının eklenmesini engeller.
                        text.Add(number.ones_digit[item - 1]);
                    else if (h % 3 == 1) // Onlar basamağını Eklenir.. Tabii varsa.
                        text.Add(number.tens_digit[item - 1]);
                    else if (h % 3 == 2) // Döngünün kaç kez tekrarlandığı tutulur. Yüzler basamağı eklenir.
                    {
                        text.Add(number.hundred);
                        text.Add(number.hundreds_digit[item - 1]);
                        step_control++;
                    }
                }
                h++;
            }
            text.Reverse();
            return string.Join(" ", text.ToArray());
        }

        // Parametre olarak alınan sayıyı basamaklarına ayırır
        // Alınan sayıları önce ters bir şekilde kaydeder.
        ArrayList places(int number)
        {
            ArrayList arraylist = new ArrayList();
            int digit_place = DigitPlace(number);

            for (int i = 0; i < digit_place; i++)
            {
                arraylist.Add(number % 10);
                number /= 10;
            }

            return arraylist;
        }

        // Parametre olarak alınan sayıyı basamaklarına ayırır.
        int DigitPlace(int number)
        {
            int x = number;
            int h = 1;

            while (x >= 10)
            {
                x /= 10;
                h++;
            }

            return h;
        }
    }
}