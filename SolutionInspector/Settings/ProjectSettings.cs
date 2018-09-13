using System.Collections.Generic;

using SolutionInspector.Contracts;

namespace SolutionInspector.Settings
{
    internal class ProjectSettings : IProjectSettings
    {
        public ProjectSettings()
        {
            DetectMissingFiles = true;
            DetectDuplicateFiles = true;
            AllowBuildEvents = true;
            AssemblyNameIsProjectName = true;
            RootNamespaceIsAssemblyName = false;
            RequiredImports = new List<string>();
            IgnoredDuplicateFiles = new List<string>();
            Properties = new List<IProjectProperty>();
        }

        public ProjectSettings(
            bool? detectMissingFiles,
            bool? detectDuplicateFiles,
            bool? allowBuildEvents,
            bool? assemblyNameIsProjectName,
            bool? rootNamespaceIsAssemblyName,
            IEnumerable<string> requiredImports,
            IEnumerable<string> ignoredDuplicateFiles,
            IEnumerable<IProjectProperty> properties)
        {
            DetectMissingFiles = detectMissingFiles;
            DetectMissingFiles = detectDuplicateFiles;
            AllowBuildEvents = allowBuildEvents;
            AssemblyNameIsProjectName = assemblyNameIsProjectName;
            RootNamespaceIsAssemblyName = rootNamespaceIsAssemblyName;
            RequiredImports = requiredImports;
            IgnoredDuplicateFiles = ignoredDuplicateFiles;
            Properties = properties;
        }

        public bool? DetectMissingFiles { get; private set; }

        public bool? DetectDuplicateFiles { get; private set; }

        public bool? AllowBuildEvents { get; private set; }

        public bool? AssemblyNameIsProjectName { get; private set; }

        public bool? RootNamespaceIsAssemblyName { get; private set; }

        public IEnumerable<string> RequiredImports { get; private set; }

        public IEnumerable<string> IgnoredDuplicateFiles { get; private set; }

        public IEnumerable<IProjectProperty> Properties { get; private set; }
    }
}