using Statiq.CodeAnalysis;
using System.Text;

namespace TurnerSoftware.Compendium;

public class ApiDocsHelper
{
	public static bool HasNonNamespaceChildren(IDocument document)
	{
		if (document.GetString(CodeAnalysisKeys.SpecificKind) == "Namespace")
		{
			foreach (var child in document.GetChildren(CodeAnalysisKeys.MemberTypes))
			{
				if (child.GetString(CodeAnalysisKeys.SpecificKind) != "Namespace")
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	public static string GetDisplayName(IDocument document)
	{
		var apiKind = document.GetString(CodeAnalysisKeys.SpecificKind);
		if (apiKind == "Namespace")
		{
			return $"{document.GetString(CodeAnalysisKeys.QualifiedName)} Namespace";
		}
		return $"{document.GetString(CodeAnalysisKeys.FullName)} {apiKind}";
	}

	public static string GetPageTitle(IDocument document)
	{
		var displayName = GetDisplayName(document);
		var specificKind = document.GetString(CodeAnalysisKeys.SpecificKind);
		if (specificKind != "Namespace")
		{
			var containingNamespace = document.GetDocument(CodeAnalysisKeys.ContainingNamespace);
			if (containingNamespace is not null)
			{
				return $"{displayName} ({containingNamespace.GetString(Keys.Title)})";
			}
		}
		return displayName;
	}

	public static string? GetPackageName(IDocument document)
	{
		var containingAssembly = document.GetDocument(CodeAnalysisKeys.ContainingAssembly);
		if (containingAssembly is not null)
		{
			return containingAssembly.GetString(CodeAnalysisKeys.DisplayName).RemoveEnd(".dll");
		}
		return null;
	}
}
