using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using SolutionInspector.Contracts;

namespace SolutionInspector.Settings.Persistence
{
    internal static class ProjectSettingsReader
    {
        public static IProjectSettings Read(string settingsFile, XElement element)
        {
            bool? detectMissingFiles = Utils.ReadOptionalFlag(settingsFile, element, "DetectMissingFiles");
            bool? detectDuplicateFiles = Utils.ReadOptionalFlag(settingsFile, element, "DetectDuplicateFiles");
            bool? allowBuildEvents = Utils.ReadOptionalFlag(settingsFile, element, "AllowBuildEvents");
            bool? assemblyNameIsProjectName = Utils.ReadOptionalFlag(settingsFile, element, "AssemblyNameIsProjectName");
            bool? rootNamespaceIsAssemblyName = Utils.ReadOptionalFlag(settingsFile, element, "RootNamespaceIsAssemblyName");

            IEnumerable<string> ignoredDuplicateFiles = Utils.ReadOptionalList(settingsFile, element, "IgnoredDuplicateFiles");
            IEnumerable<string> requiredImports = Utils.ReadOptionalList(settingsFile, element, "RequiredImports");
            IEnumerable<IProjectProperty> properties = ReadOptionalProperties(settingsFile, element);

            return new ProjectSettings(
                detectMissingFiles,
                detectDuplicateFiles,
                allowBuildEvents,
                assemblyNameIsProjectName,
                rootNamespaceIsAssemblyName,
                requiredImports,
                ignoredDuplicateFiles,
                properties);
        }

        private static IEnumerable<IProjectProperty> ReadOptionalProperties(string settingsFile, XElement root)
        {
            XElement properties = Utils.GetSingleOptionalElement(settingsFile, root, "Properties");
            if (properties == null)
            {
                return Enumerable.Empty<IProjectProperty>();
            }

            return properties.Elements().Select(ProjectPropertyReader.Read);
        }
    }
}
