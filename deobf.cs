using System;
using System.IO;

// The LL namespace comes from the Salt assembly, need to add a reference to Salt when building.
using LL;

public class ALScriptDeobfuscator {
    private static void deobfuscateScripts(string obfuscatedScriptsPath, string deobfuscatedScriptsPath) {
	byte[] obfuscatedBytes = File.ReadAllBytes(obfuscatedScriptsPath);

	// API exposed by the Salt assembly to deobfuscate files.
	byte[] deobfuscatedBytes = LL.Salt.Make(obfuscatedBytes, false);
	
	File.WriteAllBytes(deobfuscatedScriptsPath, deobfuscatedBytes);
    }
    
    static public void Main(string[] args) {
	if (args.Length != 2) {
	    Console.WriteLine("Usage: deobf <obfuscated scripts bundle path> <deobfuscated scripts bundle path>");
	    return;
	}
	
	string obfuscatedScriptsPath = args[0];
	string deobfuscatedScriptsPath = args[1];
	Console.WriteLine("Obfuscated scripts path: {0}", obfuscatedScriptsPath);
	Console.WriteLine("Deobfuscated scripts path: {0}", deobfuscatedScriptsPath);

	deobfuscateScripts(obfuscatedScriptsPath, deobfuscatedScriptsPath);
    }    
}
