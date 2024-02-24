using System;

namespace Convert_Number_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoşgeldiniz..\nSayı giriniz: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            TransformText tt = new TransformText(number);
            Console.WriteLine("Basamak sayısı:\t" + tt.digit_place);
            Console.WriteLine("Yazı ile:\t" + tt.text);

            Console.ReadKey();
        }
    }
}
