using System;
using System.IO;
using System.Text;

namespace HomeworkWithFiles
{
    public class Program1
    {
        static void Main(string[] args)
        {
            /*Создать 2 файла. Внести в один из них информацию. Во второй файл занести информацию в обратном порядке.
            Попытаться использовать MemoryStream как буфер обмена между 2 файлами.*/
            //1 способ
            #region Создание директории
            DirectoryInfo directory1 = new DirectoryInfo(@"D:\Homework"); //создается виртуальная директория
            if (directory1.Exists)
            {
                Console.WriteLine($"FullName      : {directory1.FullName}");              // Полное Имя директории, (включая путь).
                Console.WriteLine($"Name          : {directory1.Name}");                  // Имя директории, (НЕ включая путь).
                Console.WriteLine($"Parent        : {directory1.Parent}");                // Родительская директория. 
                Console.WriteLine($"CreationTime  : {directory1.CreationTime}");          // Время создания директории.
                Console.WriteLine($"Attributes    : {directory1.Attributes.ToString()}"); // Аттрибуты.
                Console.WriteLine($"Root          : {directory1.Root}");                  // Корневой диск, на котором находится директория.
                Console.WriteLine($"LastAccessTime: {directory1.LastAccessTime}");        // Время последнего доступа к директории.
                Console.WriteLine($"LastWriteTime : {directory1.LastWriteTime}");         // Время последнего изменения файлов в директории.       
            }
            else
            {
                Console.WriteLine("Такой директории не существует, но сейчас будет создана.");
                directory1.CreateSubdirectory("Homework");
            }
            #endregion
            #region Создание файла №1, создание потока данного файла, внос данных в прямом порядке в данный файл, закрытие потока файла
            FileInfo fileOne = new FileInfo(@"D:\Homework\TextFile1.txt");
            FileStream streamOfFileOne = new FileStream(@"D:\Homework\TextFile1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 0; i < 10; i++)
            {
                streamOfFileOne.WriteByte((byte)i);
                Console.Write(' ');
            }
            streamOfFileOne.Close();
            #endregion
            #region Создание файла №2, создание потока данного файла, внос данных в прямом порядке в данный файл, закрытие потока файла
            FileInfo fileTwo = new FileInfo(@"D:\Homework\TextFile2.txt");
            FileStream streamOfFileTwo = new FileStream(@"D:\Homework\TextFile2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 9; i >= 0; i--)
            {
                streamOfFileTwo.WriteByte((byte)i);
                Console.Write(' ');
            }
            streamOfFileOne.Close();
            #endregion
            //2способ
            //директорию создавать не надо
            #region Запись данных в RAM
            MemoryStream memoryOfRAM = new MemoryStream(); //запись данных в RAM
            for (byte i = 0; i < 10; i++)
            {
                memoryOfRAM.WriteByte((byte)i);
                Console.Write(' ');
            }
            #endregion
            #region Установка стартовой точки из RAM. Создание файлов №3, №4, создание потоков данных файлов, внос данных в прямом порядке в данные файлы, закрытие потоков файлов
            memoryOfRAM.Position = 0;
            FileStream txtFile3 = new FileStream(@"D:\Homework\TextFile3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//создание виртульного файла в открытом потоке
            //FileStream stream = file.Create();//доступ к реальной файловой системе открыт
            StreamWriter writerOfTxtFile3 = new StreamWriter(txtFile3, Encoding.UTF8);//декодирование
            memoryOfRAM.WriteTo(txtFile3);
            txtFile3.Position = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(txtFile3.ReadByte());
            }
            txtFile3.Close();
            Console.WriteLine(new string('-', 10));
            FileStream txtFile4 = new FileStream(@"D:\Homework\TextFile4.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//создание виртульного файла в открытом потоке
            StreamWriter writerOfTxtFile4 = new StreamWriter(txtFile4, Encoding.UTF8);//декодирование
            memoryOfRAM.WriteTo(txtFile4);
            txtFile4.Position = 9;
            for (int i = 9; i >= 0; i--)
            {
                txtFile4.Position = i;
                Console.WriteLine(txtFile4.ReadByte());
            }
            txtFile4.Close();
            #endregion
            Console.ReadKey();
        }
    }
}
