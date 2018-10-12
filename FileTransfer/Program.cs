using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace FileTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;
            string destFile = string.Empty;
            string errorPath = string.Empty;
            string sourcePath = ConfigurationManager.AppSettings["SourcePath"];
            string targetPath = ConfigurationManager.AppSettings["TargetPath"];
            string errorLogPath = ConfigurationManager.AppSettings["ErrorLogPath"];

            try
            {
                if (Directory.Exists(sourcePath) && Directory.Exists(targetPath) && Directory.Exists(errorLogPath))
                {
                    string[] files = Directory.GetFiles(sourcePath);
                    foreach (string s in files)
                    {
                        try
                        {

                            fileName = Path.GetFileName(s);
                            destFile = Path.Combine(targetPath, fileName);
                            File.Copy(s, destFile, true);
                            File.Delete(s);
  
                        }
                        catch (Exception ex)
                        {
                            fileName = Path.GetFileName(s);
                            errorPath = Path.Combine(errorLogPath, fileName);
                            File.Copy(s, destFile, true);
                            Console.WriteLine("Error" + ex.ToString());
                        }
                    }
                
                }
                else
                {
                    Console.WriteLine("File path does not exist!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());

            }
        }
    }
}
