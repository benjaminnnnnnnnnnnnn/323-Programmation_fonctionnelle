using System.Security.Cryptography.X509Certificates;

namespace NCDU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<files> filess = new List<files>();
            Console.WriteLine("Hello, World!");

            string directory = "H:\\";

            var fileList = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            var fileQuery = from file in fileList
                            let fileLen = new FileInfo(file).Length
                            where fileLen > 0
                            select fileLen;

            // Cache the results to avoid multiple trips to the file system.
            long[] fileLengths = fileQuery.ToArray();

            // Return the size of the largest file
            long largestFile = fileLengths.Max();

            // Return the total number of bytes in all the files under the specified folder.
            long totalBytes = fileLengths.Sum();





            Console.WriteLine($"There are {totalBytes} bytes in {fileList.Count()} files under {directory}");
            Console.WriteLine($"The largest file is {largestFile} bytes.");

            foreach (var file in fileList) 
            {


                

                filess.Add(new files(file.ToString(),new FileInfo(file).Length));
            }

            filess.OrderByDescending(f => f.bytes);

            foreach (files file in filess)
            {
                long bit = new FileInfo(file.name).Length;
                string name = "";

                if (bit >= 1073741824)
                {
                    name = "Gib";
                    bit /= 1073741824;
                }
                else if (bit >= 1048576)
                {
                    name = "Mib";
                    bit /= 1048576;
                }
                else if (bit >= 1024)
                {
                    name = "kib";
                    bit /= 1024;
                }
                Console.WriteLine("\t" + bit + " " + name + "\t [      ] " + file.name);
            }

            Console.ReadKey();
        }

        public class files
        {

            public files(string name, long bytes) 
            {
                this.bytes = bytes;
                this.name = name;
            }

            public string name {  get; set; }
            public long bytes { get; set; }


        }


    }
}
