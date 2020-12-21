using System;
using System.IO;

namespace WhoLock {

    class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Invalid arguments");
                Console.WriteLine("Usage: wk-who-lock <FilePath>");
                return;
            }

            var file = args[0];
            if (!File.Exists(file)) {
                Console.WriteLine("Invalid arguments");
                Console.WriteLine("File not exist {0}", file);
                return;
            }

            var process = FileUtil.WhoIsLocking(file);

            if (process.Count == 0) {
                Console.WriteLine("No process is locking {0}", file);
                return;
            }

            var index = 1;
            Console.WriteLine("{0,3} {1, 20} {2, 80}", "#", "[Process]", "[Path]");
            foreach (var item in process) {
                Console.WriteLine("{0,3} {1, 20} {2, 80}", index++, item.ProcessName, item.MainModule.FileName);
            }
        }
    }
}
