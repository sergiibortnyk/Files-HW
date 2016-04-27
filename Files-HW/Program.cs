using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files_HW
{
    class Program
    {
        static void Main()
        {
            HashSet<string> inputList = ReadFile("input.txt");
            HashSet<string> whiteList = ReadFile("whitelist.txt");
            HashSet<string> blackList = ReadFile("blacklist.txt");           
           
            var outputWhiteList = inputList.Intersect(whiteList);
            var outputBlackList = inputList.Except(blackList);
            var outputBlackWhiteList = outputWhiteList.Except(blackList);
            File.WriteAllLines("output_whitelist.txt", outputWhiteList);
            File.WriteAllLines("output_blacklist.txt", outputBlackList);
            File.WriteAllLines("output_black_and_white_list.txt", outputBlackWhiteList);                                                
        }

        public static HashSet<string> ReadFile (string fileName)
        {
            HashSet<string> readToList = new HashSet<string>();
            using (StreamReader ReaderFile = new StreamReader(fileName))
            {
                string listLine;
                while ((listLine = ReaderFile.ReadLine()) != null)
                {
                    readToList.Add(listLine);
                }
            }
            return readToList;
        }
    }
}
