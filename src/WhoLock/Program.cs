using System;
using System.IO;

namespace WhoLock {

    class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Invalid arguments");
                Console.WriteLine("Usage: wk-who-lock <FilePath>");
            }

            var file = args[0];
            if (!File.Exists(file)) {
                Console.WriteLine("Invalid arguments");
                Console.WriteLine("File not exist {0}", file);
            }

            var process = FileUtil.WhoIsLocking(file);
            var index = 1;

            foreach (var item in process) {
                Console.WriteLine("{0,5} {1, 100}", index++, item.ProcessName);
            }
        }
    }
}
