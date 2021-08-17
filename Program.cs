using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;


namespace SlipstreamCheatDetector
{
    class Program
    {
        static string datapath = Path.Combine(Directory.GetCurrentDirectory(), @"database.txt");
        static string currentUser = Environment.UserName;
        static string versionspath = @"C:\Users\" + currentUser + @"\AppData\Roaming\.minecraft\versions";
        static string gamePath = @"C:\Users\" + currentUser + @"\AppData\Roaming\.minecraft";

        static string[] database = File.ReadAllLines(datapath);
        static void Main(string[] args)
        {
            RunSlipstream();
        }

        public static void RunSlipstream()
        {
            #region mainmenu

            Console.Clear();
            Console.WriteLine("Slipstream Cheat Detection Tool");
            Console.WriteLine("");
            Console.WriteLine("By anonfoxer");
            Console.WriteLine("If you did not obtain this tool from the GitHub page just leave the screenshare and take the ban.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. .minecraft Quick Scan (Finds most blatant cheats as well as mods such as Baritone. Will only scan the C: install.)");
            Console.WriteLine("2. .minecraft/versions scan. (Finds older, 1.8 tuned clients.");
            Console.WriteLine("3. Check database");
            Console.WriteLine("4. Check Slipstream settings");
            Console.WriteLine("");

            #endregion

            #region choicehandle

            var choice = Console.ReadLine();
            int choiceSwitch = Convert.ToInt32(choice);
            switch (choiceSwitch)
            {
                case 1:
                    quickScan();
                    break;
                case 2:
                    versionScan();
                    break;
                case 3:
                    printDatabase();
                    break;
                case 4:
                    checkSettings();
                    break;
            }

            #endregion
        }
        #region cheatDetection

        public static void printDatabase() {

            Console.Clear();
            Console.WriteLine("Slipstream - Currently loaded database...");
            Console.WriteLine("");
            foreach (var item in database)
            { 
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            RunSlipstream();
        }

        public static void versionScan()
        {
            Console.Clear();
            Console.WriteLine("Slipstream - versions scan...");
            Console.WriteLine("");
            int matchFound = 0;
            System.IO.DirectoryInfo di = new DirectoryInfo(versionspath);
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                    foreach (string name in database)
                    {
                        if (dir.Name == name)
                        {
                            matchFound++;
                            Console.WriteLine(dir.Name + " was found.");
                        }
                    }
            }
            Console.WriteLine("");
            Console.WriteLine(matchFound + " matches.");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            RunSlipstream();
        }

        public static void quickScan()
        {
            Console.Clear();
            Console.WriteLine("Slipstream - .minecraft scan...");
            Console.WriteLine("");
            int matchFound = 0;
            System.IO.DirectoryInfo di = new DirectoryInfo(gamePath);
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                foreach (string name in database)
                {
                    if (dir.Name == name)
                    {
                        matchFound++;
                        Console.WriteLine(dir.Name + " was found.");
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine(matchFound + " matches.");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            RunSlipstream();
        }
        #endregion

        public static void checkSettings()
        {
            Console.WriteLine("Current game path: " + gamePath);
            Console.WriteLine("Current /versions path: " + versionspath);
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            RunSlipstream();
        }
    }
}
