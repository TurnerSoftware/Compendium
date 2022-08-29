namespace TurnerSoftware.Compendium;

public class Tailwind : Pipeline
{
	private const bool MinifyOutput = true;

	private static string MinifyOutputArgument => MinifyOutput ? "--minify" : string.Empty;

	public Tailwind()
	{
		InputModules = new ModuleList
		{
			new ReadFiles("**/*.tailwind.css")
		};

		ProcessModules = new ModuleList
		{
			new StartProcess("dotnet", Config.FromDocument(d => $"tailwindcss -c theme/tailwind.config.js -i {d.Source} {MinifyOutputArgument}"))
				.ContinueOnError(Config.FromValue(true))
				.LogErrors(Config.FromValue(false)),
			new ReplaceDocuments(Config.FromDocument(d => d.Clone(d.Destination.ChangeExtension("min.css")).Yield()))
		};

		OutputModules = new ModuleList
		{
			new WriteFiles()
		};
	}
}
