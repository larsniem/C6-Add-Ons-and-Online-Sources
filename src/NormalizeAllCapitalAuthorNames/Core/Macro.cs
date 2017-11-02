﻿using SwissAcademic.Addons.NormalizeAllCapitalAuthorNames.Properties;
using SwissAcademic.Citavi.Shell;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SwissAcademic.Addons.NormalizeAllCapitalAuthorNames
{
    internal static class Macro
    {
        public static void Run(MainForm mainForm)
        {
            var prefixSuffixFirstCapitalLetter = false;
            var normalizeCapitalLastname = true;
            var counter = 0;
            var project = mainForm.Project;

            var authors = project.Persons.ToArray();
            if (!authors.Any()) return;

            foreach (var author in authors)
            {

                var originalAuthorFullName = author.FullName.ToString();
                var originalAuthorLastName = author.LastName.ToString();

                if (originalAuthorFullName == author.FullName.ToUpper() || (originalAuthorLastName == author.LastName.ToUpper() && normalizeCapitalLastname))
                {
                    counter++;
                    var authorPrefix = author.Prefix.ToString();
                    var authorFirstName = author.FirstName.ToString();
                    var authorMiddleName = author.MiddleName.ToString();
                    var authorLastName = author.LastName.ToString();
                    var authorSuffix = author.Suffix.ToString();

                    var authorFirstNameNormal = authorFirstName.ToLower().ToInitialUpper();
                    var authorMiddleNameNormal = authorMiddleName.ToLower().ToInitialUpper();
                    var authorLastNameNormal = authorLastName.ToLower().ToInitialUpper();

                    string authorPrefixNormal;
                    string authorSuffixNormal;

                    if (prefixSuffixFirstCapitalLetter == true)
                    {
                        authorPrefixNormal = authorPrefix.ToLower().ToInitialUpper();
                        authorSuffixNormal = authorSuffix.ToLower().ToInitialUpper();
                    }
                    else
                    {
                        authorPrefixNormal = authorPrefix.ToLower();
                        authorSuffixNormal = authorSuffix.ToLower();
                    }

                    author.Prefix = authorPrefixNormal;
                    author.FirstName = authorFirstNameNormal;
                    author.MiddleName = authorMiddleNameNormal;
                    author.LastName = authorLastNameNormal;
                    author.Suffix = authorSuffixNormal;
                }
            }

            MessageBox.Show(mainForm, NormalizeAllCapitalAuthorNamesResources.ResultMessage.FormatString(counter), mainForm.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}