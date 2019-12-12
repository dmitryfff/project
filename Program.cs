using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Application2 start");
            string path_directory = "";
            string path_config = "config.ini";
            try
            {
                using (StreamReader sr = File.OpenText(path_config))
                {
                    //string m = " ";
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        path_directory = s;
                        
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
            //Directory for copy file
            string path_directory2 = "";
            //name of second config file
            string path_config2 = "config2.ini";
            //A file that contains the path of the modified file
            string path = "file.dat";
            //string for read data
            string s2;
            //path of the modified file
            string file_path2 = "";
            using (StreamReader sr1 = File.OpenText(path))
            {                
                while ((s2 = sr1.ReadLine()) != null)
                {
                    file_path2 = s2;
                    Console.WriteLine("Modified file: " + file_path2);
                }
            }
            //name of the modified file
            string file_name2 = Path.GetFileName(file_path2);
            try
            {
                using (StreamReader sr3 = File.OpenText(path_config2))
                {
                    string s3 = "";
                    while ((s3 = sr3.ReadLine()) != null)
                    {
                        path_directory2 = s3;
                        Console.WriteLine("Directory for copy file: " + path_directory2);
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }

            string source_file = System.IO.Path.Combine(path_directory, file_path2);
            string taget_file = System.IO.Path.Combine(path_directory2, file_name2);
            File.Copy(source_file, taget_file, true);
                    
            String textFromFile;
            //Read byte from file
            using (FileStream fstream = File.OpenRead(taget_file))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                textFromFile = System.Text.Encoding.Default.GetString(array);
                                                
            }
                        
            //Convert the file to utf-16
            try
            {
                StreamWriter file_Utf16 = new StreamWriter(taget_file, false, Encoding.Unicode);
                file_Utf16.WriteLine(textFromFile);
                //Console.WriteLine($"Text from file: {textFromFile}");
                file_Utf16.Close();
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
                        
        }
    }
}
