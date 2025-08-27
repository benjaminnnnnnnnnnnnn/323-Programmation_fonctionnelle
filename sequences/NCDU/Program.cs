namespace NCDU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string directory = "C:\\";

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
        }
    }
}
