using System;
using System.IO;
using System.Collections.Generic;

namespace macro
{
    class FileService : IFile
    {
        public List<string> findFile(string directory, string ext)
        {
            List<string> filesPath = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (file.Extension.ToLower().CompareTo("." + ext) == 0)
                {
                    filesPath.Add(file.FullName);
                }
            }

            return filesPath;
        }

        public string logMsg(string msg)
        {
            string str;
            str = string.Format("[{0}] {1}\n", DateTime.Now, msg);
            return str;
        }

        public void logSave(string msg)
        {
            string dirPath = Environment.CurrentDirectory + @"\Log";
            string filePath = dirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";

            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            FileInfo fileInfo = new FileInfo(filePath);

            try
            {
                if (!directoryInfo.Exists) Directory.CreateDirectory(dirPath);
                if (!fileInfo.Exists)
                {
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.WriteLine(msg);
                        streamWriter.Close();
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = File.AppendText(filePath))
                    {
                        streamWriter.WriteLine(msg);
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("log save fail : " + e);
            }
        }

        public void userSave(string msg)
        {
            string dirPath = Environment.CurrentDirectory + @"\Log";
            string filePath = dirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + "_usersave.log";

            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            FileInfo fileInfo = new FileInfo(filePath);

            try
            {
                if (!directoryInfo.Exists) Directory.CreateDirectory(dirPath);
                if (!fileInfo.Exists)
                {
                    using (StreamWriter streamWriter = new StreamWriter(filePath))
                    {
                        streamWriter.WriteLine(msg);
                        streamWriter.Close();
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = File.AppendText(filePath))
                    {
                        streamWriter.WriteLine(msg);
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("log save fail : " + e);
            }
        }
    }
}
