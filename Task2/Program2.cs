using System;
using System.IO;
using System.Text;

namespace Task2
{
    public class Program2
    {
        static void Main(string[] args)
        {
            /*Создайте файл, запишите в него произвольные данные и закройте файл. Затем снова откройте этот файл, прочитайте из него данные и выведете их на консоль.*/
            FileInfo textFile = new FileInfo(@"D:\TextFile.txt");

            StreamWriter writerInTextFile = textFile.CreateText();
            //StreamWriter writerInTextFile = new StreamWriter(@"D:\Text.txt", true, Encoding.Default);
            writerInTextFile.WriteLine("Данный текст написан внутри файла.");
            writerInTextFile.Write(writerInTextFile.NewLine);//добавлена пустая строка
            writerInTextFile.WriteLine("Данная строчка напечатана после пустой строки.");
            writerInTextFile.WriteLine("Список чисел:");
            for (int i = 0; i < 10; i++)
            {
                writerInTextFile.Write(i + " ");
            }
            writerInTextFile.Write(writerInTextFile.NewLine);//добавлена пустая строка
            writerInTextFile.Close();//закрытие потока файла D:\\TextFile.txt
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Данный текст напечатан только в консоли.");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Файл TextFile.txt был создан ранее и в него был записан текст.");
            Console.ResetColor();
            FileStream readerInTextFile = textFile.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            Console.WriteLine("Строчки ниже показывают, что файл был открыт для чтения, текст из него выведен на консоль.");
            Console.WriteLine(readerInTextFile);
            readerInTextFile.Close();


            //https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
            Console.WriteLine("Написанный внутри файла текст выглядит так, как показано ниже.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(File.ReadAllText(@"D:\TextFile.txt")); //второй вариант - исп. File.ReadAllText(@"D:\TextFile.txt")
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
