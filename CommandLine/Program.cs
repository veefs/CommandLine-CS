using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;

namespace CommandLine
{
    internal class Program
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);



        private static string LSdir = "C:/";
        private static string hostName = Dns.GetHostName();
        private static string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
        private static string HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
        static void Main(string[] args)
        {


            Console.ForegroundColor = Color.FromArgb(73,147,230);
            Console.Title = "Command List";
            Commands();
        }

        static void ListProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                Console.WriteLine(p.ProcessName);
            }
        }

        static void Commands()
        {
            //1st line
            Console.Write("-", Color.FromArgb(94,189,171));
            Console.Write("[(", Color.FromArgb(94, 189, 171));
            Console.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name, Color.FromArgb(39, 127, 255));
            Console.Write(")]", Color.FromArgb(94, 189, 171));
            Console.Write("-", Color.FromArgb(94, 189, 171));
            Console.Write("[", Color.FromArgb(94, 189, 171));
            Console.Write(LSdir);
            Console.Write("]", Color.FromArgb(94, 189, 171));

            //2nd line
            Console.Write("\r\n|", Color.FromArgb(94, 189, 171));

            //3rd line
            Console.Write("\r\n-", Color.FromArgb(94, 189, 171));
            Console.Write("$", Color.FromArgb(39, 127, 255));

            string CommandInput = Console.ReadLine();

            switch (CommandInput)
            {
                case "commands":




                    Console.WriteLine("clear - clears text");
                    Console.WriteLine("proc list - lists all processes");
                    Console.WriteLine("ls - lists all files in your directory");
                    Console.WriteLine("cd - changes your directory");
                    Console.WriteLine("open - say directory then open it");
                    Console.WriteLine("my ip - shows your ip");
                    Console.WriteLine("my hwid - shows your hwid");
                    Console.WriteLine("my hostname - shows your hwid");
                    Commands();
                    break;

                case "clear":
                    Console.Clear();
                    Commands();
                    break;

                case "proc list":
                    ListProcesses();
                    Commands();
                    break;

                case "my ip":
                    Console.WriteLine($"{myIP}");
                    Commands();
                    break;

                case "my hwid":
                    Console.WriteLine($"{HWID}");
                    Commands();
                    break;

                case "my hostname":
                    Console.WriteLine($"{hostName}");
                    Commands();
                    break;

                case "cd":
                    Console.WriteLine("what directory");
                    LSdir = Console.ReadLine();
                    Commands();

                    break;
                case "ls":
                    string rootdir = $@"{LSdir}";

                    // get the list of files
                    string[] files = Directory.GetFiles(rootdir);
                    Console.WriteLine(String.Join(Environment.NewLine, files));

                    // get the list of directories
                    string[] dirs = Directory.GetDirectories(rootdir);
                    Console.WriteLine(String.Join(Environment.NewLine, dirs));
                    Commands();
                    break;

                case "open":
                    Console.WriteLine("file path (include exact file path");
                    string FilePath = Console.ReadLine();
                    Process.Start(FilePath);
                    Commands();
                    break;


                default:
                    Console.WriteLine("please put a valid input", Color.Firebrick);
                    Commands();
                    break;
            }
        }
    }
}
