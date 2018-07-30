using System.Collections.Generic;
using System.IO;
using System.Linq;

using SolutionInspector.Contracts;
using System.Runtime.InteropServices;

namespace SolutionInspector.Rules
{
    internal class DetectDuplicateFilesRule : IRule
    {
        public static string ignoredDuplicates { get; set; }
          
        public IEnumerable<IIssue> Apply(ISolution solution)
        {
            if (solution.Settings.IgnoredDuplicateFiles != null)
            {
                foreach (string file in solution.Settings.IgnoredDuplicateFiles)
                {
                    ignoredDuplicates += file;
                    System.Console.WriteLine("Ignored duplicate files from SolutionInspector.xml are: " + ignoredDuplicates);
                }
            }
            else
            {
                ignoredDuplicates = "";
            }

            if (solution.Settings.DetectDuplicateFiles ?? false)
            {
                    string directory = Path.GetDirectoryName(solution.File);
                    foreach (var duplicateName in CheckDuplicates(directory, solution.Files))
                    {
                        yield return Issue.Create(Issue.DuplicateFileDetected, solution, "Solution references Duplicate file: {0}", duplicateName.FirstOrDefault());
                    }
            }

            foreach (IProject project in solution.Projects)
            {
                if (project.Settings.DetectDuplicateFiles ?? false)
                {
                    string directory = Path.GetDirectoryName(project.File);
                    foreach (var duplicateName in CheckDuplicates(directory, project.Files))
                    {
                           yield return Issue.Create(Issue.DuplicateFileDetected, project, "Project references Duplicate file: {0}", duplicateName.FirstOrDefault());
                    }
                }
            }
        }

        private static IEnumerable<System.Linq.IGrouping<string, string>> CheckDuplicates(string directory, IEnumerable<string> files)
        {
            try
            {
                var duplicateNames = from filePath in files
                                     let fileName = Path.GetFileName(filePath)
                                     group filePath by fileName into filesFound
                                     where filesFound.Count() > 1 && !ignoredDuplicates.Contains(filesFound.Key)
                                     select filesFound;
                return duplicateNames;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("IOException", e);
                return null;
            }
        } 
     }
}

