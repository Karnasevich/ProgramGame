using System;
using System.Diagnostics;

class Program
{
    static string UnsafeCalculator(string expression)
    {
        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + expression; 
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
        catch
        {
            return "Помилка";
        }
    }

    static void Main()
    {
        Console.WriteLine("Нормальне використання:");
        Console.WriteLine(UnsafeCalculator("echo 2 + 2"));

        Console.WriteLine("\nRCE атака:");
        Console.WriteLine(UnsafeCalculator("dir"));
    }
}