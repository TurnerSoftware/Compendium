using Statiq.CodeAnalysis;
using Statiq.Docs.Pipelines;
using Statiq.Web.Modules;
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
				return doc.Clone(new MetadataItems
				{
					{ Keys.Title, ApiDocsHelper.GetPageTitle(doc) },
					//{ WebKeys.ContentType, ContentType.Content }
				});//, doc.ContentProvider.CloneWithMediaType(MediaTypes.Html));
			}))
		);
	}
}
