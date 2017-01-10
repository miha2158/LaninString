using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaninString
{
    class Program
    {
        public static bool IsReversable(string input)
        {
            string output = string.Empty;
            for (int i = 0; i < input.Length; i++)
                switch (input[i])
                {
                    case ' ':
                        input = input.Remove(i--, 1);
                        break;
                    case 'Ё':
                    case 'ё':
                        output = output + "е";
                        break;
                    case 'Й':
                    case 'й':
                        output = output + "й";
                        break;
                    default:
                        output = output + input[i];
                        break;
                }

            output = output.ToLower();



            for(int i = 0; i < output.Length/2; i++)
                if (output[i] != output[output.Length - 1 - i])
                    return false;
            return true;
        }

        public static string FakeSyllableSplit(string input)
        {
            string vowels = "уеыаоэяию";
            //string vowels = "aoeiu";
            string output = string.Empty;
            input = input.ToLower();
            bool meow = true;
            bool over = false;

            //while (!over)
            do
            {
                meow = !meow;
                int i = 0;
                while (i < input.Length)
                    if (vowels.Contains(input[i++]))
                    {
                        if (!meow)
                        {
                            if (i < input.Length)
                                if (vowels.Contains(input[i]))
                                    i++;
                        }
                        else i--;

                        break;
                    }

                if (i >= input.Length)
                    over = true;

                if (!over)
                {
                    if (meow)
                        //i =  i - i / 2;
                        i = i/2;

                    output = output + input.Substring(0, i);
                    input = input.Remove(0, i);

                    if (meow)
                        output = output + " ";
                }
            } while (!over);

            output = output + " ";
            //output = output.Remove(output.Length - 3);
            return output + input;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Введите слово\n");
            string input = Console.ReadLine();
            
            Console.WriteLine("\n Ваше слово разделённое на слоги: {0}", FakeSyllableSplit(input));
            Console.ReadKey(true);
        }
    }
}
