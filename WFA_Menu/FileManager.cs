using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.XPath;
using System.Windows.Forms;

namespace WFA_Menu
{
    class FileManager
    {
        static string path = @"C:\Users\ihorz\Desktop";

        public static void SaveFile(string str, string fname, bool test)
        {

            FileMode mode;
            if (test)
                mode = FileMode.Truncate;
            else
                mode = FileMode.OpenOrCreate;


            var rez = MessageBox.Show("Enter file name", "Filename", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            using (FileStream fs =  new FileStream(path + @"\" + fname, FileMode.OpenOrCreate, FileAccess.Write) )
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(str);
                }
            }
        }


        public static FileInfo[] GetFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            var files = directory.GetFiles();
            return files;
        }

        public static string OpenFile(string str)
        {
            string buff;
            using (FileStream fs = new FileStream(path + @"\" + str, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    buff = sr.ReadToEnd();
                }
            }

            return buff;
        }
    }
}
