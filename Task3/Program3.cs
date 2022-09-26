using System;
using System.IO;
using System.Text;
namespace Task3
{

    public class Program3
    {
        static string CreationOfHiddenFile(string enteredDirectoryPath)
        {
            Console.Write("Enter a name of creating file: ");
            string nameOfFile = Console.ReadLine();
            string pathOfCreatingFile = String.Concat(enteredDirectoryPath, "\\", nameOfFile, ".txt");
            FileStream streamOfTextFile = new FileStream(pathOfCreatingFile, FileMode.CreateNew, FileAccess.ReadWrite);
            File.SetAttributes(pathOfCreatingFile, FileAttributes.Hidden);
            streamOfTextFile.Close();
            Console.WriteLine($"File {pathOfCreatingFile} was created");
            return pathOfCreatingFile;
        }
        static void RepairFile(string enteredPathOfCreatingFile)
        {

            File.SetAttributes(enteredPathOfCreatingFile, FileAttributes.Normal);
            Console.WriteLine($"File {enteredPathOfCreatingFile} has normal attribute.");
        }
        static void Main(string[] args)
        {
            //надо переделать эту задачу
            /*Напишите два  приложения, своего рода приложение-вредитель и приложение-помощник. 
             * Вредитель будет делать все файлы формата Word в какой-нибудь директории (простой вариант), либо на всем локальном диске (вариант посложнее) скрытыми.  
             * А помощник будет исправлять ситуацию. Т.е. у Вас будет ключ (в виде приложения-помощника) к исправлению ситуации на чьем-нибудь компьютере. 
             * P.S. При написании приложения рекомендуется тестировать его на специально созданной для тестирования папке, заполненной документами! :-)*/
            //https://learn.microsoft.com/ru-ru/dotnet/standard/io/
            //https://www.cyberforum.ru/csharp-beginners/thread92858.html
            //https://stackoverflow.com/questions/52162689/set-file-attributes-on-a-file-to-readonly-in-c-sharp
            #region Создание директории папки
            string directoryPath = @"D:\TestDirectory";
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Console.WriteLine($"Directory \"{directoryPath}\" has already created");
                }
                else
                {
                    DirectoryInfo directory = Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Directory \"{directoryPath}\" has been created");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Creation of directory has failed. Exception: {ex}");
            }
            #endregion
            
            CreationOfHiddenFile(directoryPath); //создаем скрытый файл
            RepairFile(CreationOfHiddenFile(directoryPath)); //создаем скрытый файл и делаем его видимым

            Console.ReadKey();
        }

    }
}
