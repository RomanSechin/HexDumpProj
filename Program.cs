using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        var position = 0;
        //using (var reader = new StreamReader("textdata.txt"))
        //using (var reader = new StreamReader("binarydata.dat"))
        //using (Stream input = File.OpenRead("binarydata.dat"))
        using (Stream input = File.OpenRead(args[0]))
        {
            //while (reader.EndOfStream == false)
            while(position < input.Length) 
            {
                //Прочитать следующие 16 байтов из файла в массив байтов
                //var buffer = new char[16];
                var buffer = new byte[16];
                //var bytesRead = reader.ReadBlock(buffer, 0, buffer.Length);
                var bytesRead = input.Read(buffer, 0, buffer.Length);

                //Записать шестнадцатеричную позицию (или смещение), затем двоеточие и пробел
                Console.Write("{0:x4}: ", position);
                position += bytesRead;

                //Записать шестнадцатеричное значение каждого символа в массив байтов
                for (var i = 0; i < buffer.Length; i++)
                {
                    if (i < bytesRead)
                    {
                        Console.Write("{0:x2} ", (byte)buffer[i]);
                    }
                    else
                        Console.Write("   ");
                    if (i == 7)
                        Console.Write("-- ");
                    if (buffer[i] < 0x20 || buffer[i] > 0x7f) buffer[i] = (byte)'.';
                }
                //Записать символы в массив байтов
                //var bufferContents = new string(buffer);
                var bufferContents = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("    {0}", bufferContents.Substring(0, bytesRead));
            }
        }
    }
}