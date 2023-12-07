using System;
using System.Diagnostics;
using System.Reflection;

if (args.Length == 0)
{
    var versionString = Assembly.GetEntryAssembly()?
                                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                                .InformationalVersion
                                .ToString();
    Console.WriteLine($"Fon Version: {versionString}");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Usage: fon <command> [options]");
    return;
}

var command = args[0];
var arguments = string.Join(" ", args[1..]);

var process = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "--version", //$"./fon.dll {command} {arguments}",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        // UseShellExecute = false,
        CreateNoWindow = true
    }
};

process.Start();
ArgumentNullException.ThrowIfNull(process);
string output = process.StandardOutput.ReadToEnd();
await process.WaitForExitAsync();
     