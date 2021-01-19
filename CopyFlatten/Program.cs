using System.IO;

namespace CopyFlatten
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = args[0];
            string dest = args[1];
            string pattern = args[2];

            foreach (string filename in Directory.GetFiles(source, pattern, SearchOption.AllDirectories))
            {
                string filenameOnly = Path.GetFileName(filename);
                File.Copy(filename, Path.Combine(dest, filenameOnly), true);
            }
        }
    }
}
