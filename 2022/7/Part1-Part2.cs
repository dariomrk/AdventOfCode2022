using static aoc.Data;
using static System.Console;

namespace aoc
{
    public class Dir
    {
        public string DirName { get; set; }
        public List<Dir> Subdris { get; set; }
        public Dictionary<string, int> FolderSizes { get; set; }
        public Dir ParentDir { get; set; }
        public int DirSize { get; set; }

        public Dir(string dirName, Dir parent)
        {
            DirName = dirName;
            ParentDir = parent;
            Subdris = new List<Dir>();
            FolderSizes = new Dictionary<string, int>();
            DirSize = 0;
        }
    }
    public static class Program
    {
        static string[] input = raw.Split(Environment.NewLine);
        static int cutoff = 100000;
        static Dir FileSystem = new Dir("/", null);
        static List<int> dirSizes = new List<int>();
        static int partOne = 0;

        public static int GetDirSize(Dir d)
        {

            if (d.FolderSizes.Count > 0)
            {
                foreach (KeyValuePair<string, int> kvp in d.FolderSizes)
                {
                    d.DirSize += kvp.Value;
                }
            }

            if (d.Subdris.Count > 0)
            {
                foreach (Dir subDir in d.Subdris)
                {
                    d.DirSize += GetDirSize(subDir);
                }
            }

            if (d.DirSize <= cutoff)
            {
                partOne += d.DirSize;
            }

            dirSizes.Add(d.DirSize);

            return d.DirSize;
        }
        static void Main()
        {
            Dir currentDir = null;

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i].Contains("$ cd"))
                {
                    string dirToChangeTo = input[i].Substring(5);
                    switch (dirToChangeTo)
                    {
                        case "/":
                            currentDir = FileSystem;
                            break;
                        case "..":
                            currentDir = currentDir!.ParentDir;
                            break;
                        default:
                            currentDir = currentDir.Subdris.Find(x => x.DirName == dirToChangeTo);
                            break;
                    }
                }

                else if (input[i] == "$ ls")
                {

                    int head = i+1;
                    if ((head <= input.Length - 1))
                    {
                        while (!input[head].Contains("$"))
                        {

                            if (input[head].Contains("dir "))
                            {
                                string dirName = input[head].Substring(4);
                                if (!currentDir.Subdris.Contains(currentDir.Subdris.Find(x => x.DirName == dirName)))
                                {
                                    currentDir.Subdris.Add(new Dir(dirName, currentDir));
                                }
                            }

                            else
                            {
                                string[] file = input[head].Split();
                                currentDir.FolderSizes.Add(file[1], int.Parse(file[0]));
                            }
                            head++;

                            if (head == input.Length)
                            {
                                break;
                            }
                        }
                    }
                    i = head-1;
                }
            }
            GetDirSize(FileSystem);
            WriteLine(partOne);

            int availableDiskSpace = 70000000 - FileSystem.DirSize;
            int neededSpace = 30000000 - availableDiskSpace;

            int dirToDelete = int.MaxValue;

            foreach (int i in dirSizes)
            {
                if (i >= neededSpace && i <= dirToDelete)
                {
                    dirToDelete = i;
                }
            }
            WriteLine(dirToDelete);
        }
    }
}