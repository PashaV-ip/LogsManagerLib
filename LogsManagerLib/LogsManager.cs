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
            var filePath = _path + @"\" + name + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    await streamWriter.WriteLineAsync($"_____________________________________________________________________________________\n" +
                              $"####                Дата создания файла:       {DateTime.Now.ToString("HH:mm | dd.MM.yyyy")}                ####\n" +
                              $"####_____________________________________________________________________________####");
                }
            }
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                if (textString.Length == 53)
                    await streamWriter.WriteLineAsync($"#### {dateTime.ToString("HH:mm | dd.MM.yyyy")} || {textString} ####");
                else if (textString.Length < 53)
                {
                    while (textString.Length != 53)
                    {
                        textString += " ";
                    }
                    await streamWriter.WriteLineAsync($"#### {dateTime.ToString("HH:mm | dd.MM.yyyy")} || {textString} ####");
                }
                else if (textString.Length > 53)
                {
                    int index = 0;
                    string tmpText = "";
                    string[] tmpTextArray = textString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    textString = "";
                    while (index < tmpTextArray.Length)
                    {
                        if ((tmpText + tmpTextArray[index]).Length < 53)
                        {
                            tmpText += tmpTextArray[index] + " ";
                            index++;
                        }
                        else
                        {
                            while (tmpText.Length != 53)
                            {
                                tmpText += " ";
                            }
                            textString += tmpText + " ####\n####                    || ";
                            tmpText = "";
                        }
                    }
                    while (tmpText.Length != 53)
                    {
                        tmpText += " ";
                    }
                    textString += tmpText;
                    await streamWriter.WriteLineAsync($"#### {dateTime.ToString("HH:mm | dd.MM.yyyy")} || {textString} ####");
                }
                await streamWriter.WriteLineAsync($"####_____________________________________________________________________________####");
            }
        }
    }
}
