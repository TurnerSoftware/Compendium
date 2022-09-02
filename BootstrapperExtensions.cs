namespace TurnerSoftware.Compendium;

public static class BootstrapperExtensions
{
	public static TBootstrapper UseCompendiumTheme<TBootstrapper>(this TBootstrapper bootstrapper)
		where TBootstrapper : IBootstrapper => bootstrapper
			.ConfigureSettings()
			.AddPipelines();
	private static TBootstrapper AddPipelines<TBootstrapper>(this TBootstrapper bootstrapper)
		where TBootstrapper : IBootstrapper => bootstrapper
			.AddPipeline(typeof(Tailwind))
			.AddPipeline(typeof(ApiExtensions));

	private static TBootstrapper ConfigureSettings<TBootstrapper>(this TBootstrapper bootstrapper) 
		where TBootstrapper : IBootstrapper => bootstrapper.AddSettings(new Dictionary<string, object>
		{
			{ DocsKeys.ApiLayout, "Api/_ApiLayout" },
			//{ DocsKeys.OutputApiDocuments, false }
		});
}
