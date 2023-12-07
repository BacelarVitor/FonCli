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

