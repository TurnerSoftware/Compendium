using Statiq.CodeAnalysis;
using Statiq.Docs.Pipelines;
using System.Text;

namespace TurnerSoftware.Compendium;

public class ApiExtensions : Pipeline
{
	public ApiExtensions()
	{
		Dependencies.Add(nameof(Api));

		DependencyOf.Add(nameof(Statiq.Web.Pipelines.Content));

		ProcessModules = new ModuleList(
			new ConcatDocuments(nameof(Api)),
			new ExecuteConfig(Config.FromDocument((doc, ctx) =>
			{
				var coreName = $"{doc.GetString(CodeAnalysisKeys.FullName)} {doc.GetString(CodeAnalysisKeys.SpecificKind)}";
				var title = coreName;
				
				var containingNamespace = doc.GetDocument(CodeAnalysisKeys.ContainingNamespace);
				if (containingNamespace is not null)
				{
					title = $"{coreName} ({containingNamespace.GetString(Keys.Title)})";
				}

				return doc.Clone(new Dictionary<string, object>()
				{
					[Keys.Title] = title
				});
			}))
		);
	}
}
