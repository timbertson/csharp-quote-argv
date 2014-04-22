using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
 
public class TestMain
{
	static void Main(string[] initialArgs)
	{
		string cmd = initialArgs[0];
		ArrayList args = new ArrayList(initialArgs);
		args.RemoveAt(0);
		string argstr = QuoteArguments.Quote(args);

		// System.Console.Error.WriteLine(argstr); // XXX

		var p = Process.Start(
			new ProcessStartInfo( cmd, argstr)
			{ UseShellExecute = false }
		);

		p.WaitForExit();
		Environment.Exit(p.ExitCode);
	}
}
