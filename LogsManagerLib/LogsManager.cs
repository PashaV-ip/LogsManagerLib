using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsManagerLib
{
    public class LogsManager : ILogsManager
    {
        private readonly string _path = @"C://LogsApplication";
        public LogsManager()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        public async Task WriteLog(string textString, string name, DateTime dateTime)
        {

            /*var filePath = _path + @"\" + name + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    await streamWriter.WriteLineAsync($"_______________________________________________________________\n" +
                              $"####     Дата создания файла:       {DateTime.Now.ToString("hh:mm | dd.MM.yyyy")}     ####\n" +
                              $"_______________________________________________________________");
                }
            }
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                await streamWriter.WriteLineAsync($"_______________________________________________________________\n" +
                    $"#### {text} ####");
            }*/





            //using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            //{
            var filePath = _path + @"\" + name + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    Console.WriteLine($"_____________________________________________________________________________________\n" +
                              $"####                Дата создания файла:       {DateTime.Now.ToString("hh:mm | dd.MM.yyyy")}                ####\n" +
                              $"####_____________________________________________________________________________####");
                }
            }
                if (textString.Length == 53)
                    Console.WriteLine($"#### {dateTime.ToString("hh:mm | dd.MM.yyyy")} || {textString} ####");
                else if (textString.Length < 53)
                {
                    while (textString.Length != 53)
                    {
                        textString += " ";
                    }
                    Console.WriteLine($"#### {dateTime.ToString("hh:mm | dd.MM.yyyy")} || {textString} ####");
                }
                else if (textString.Length > 53)
                {
                    int index = 0;
                    string tmpTextOne = "";
                    string tmpTextTwo = "";
                    string[] tmpTextArray = textString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    textString = "";
                    while (index < tmpTextArray.Length)
                    {
                        if ((tmpTextOne + tmpTextArray[index]).Length < 53)
                        {
                            tmpTextOne += tmpTextArray[index] + " ";
                            index++;
                        }
                        else
                        {
                            while (tmpTextOne.Length != 53)
                            {
                                tmpTextOne += " ";
                            }
                            textString += tmpTextOne + " ####\n####                    || ";
                            tmpTextOne = "";
                        }
                    }
                    while (tmpTextOne.Length != 53)
                    {
                        tmpTextOne += " ";
                    }
                    textString += tmpTextOne;
                    Console.WriteLine($"#### {dateTime.ToString("hh:mm | dd.MM.yyyy")} || {textString} ####");
                }
                Console.WriteLine($"####_____________________________________________________________________________####");
            //}
        }
    }
}
