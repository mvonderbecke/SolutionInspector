using System;
using System.Collections.Generic;

using SolutionInspector.Contracts;

namespace SolutionInspector.Settings
{
    internal class SolutionSettings : ISolutionSettings
    {
        public SolutionSettings(
            Version maxSolutionFormatVersion,
            Version minSolutionFormatVersion,
            bool? detectMissingFiles,
            bool? detectDuplicateFiles,
            string projectNamePrefix,
            bool? projectNameIsFileName,
            IEnumerable<string> ignoredProjects,
            IEnumerable<string> ignoredDuplicateFiles
            )
        {
            MaxSolutionFormatVersion = maxSolutionFormatVersion;
            MinSolutionFormatVersion = minSolutionFormatVersion;
            DetectMissingFiles = detectMissingFiles;
            DetectDuplicateFiles = detectDuplicateFiles;
            ProjectNamePrefix = projectNamePrefix;
            ProjectNameIsFileName = projectNameIsFileName;
            IgnoredProjects = ignoredProjects;
            IgnoredDuplicateFiles = ignoredDuplicateFiles;
        }

        public SolutionSettings()
        {
        }

        public Version MaxSolutionFormatVersion { get; private set; }

        public Version MinSolutionFormatVersion { get; private set; }

        public bool? DetectMissingFiles { get; private set; }

        public bool? DetectDuplicateFiles { get; private set; }

        public string ProjectNamePrefix { get; private set; }

        public bool? ProjectNameIsFileName { get; private set; }

        public IEnumerable<string> IgnoredProjects { get; private set; }

        public IEnumerable<string> IgnoredDuplicateFiles { get; private set; }

    }
}