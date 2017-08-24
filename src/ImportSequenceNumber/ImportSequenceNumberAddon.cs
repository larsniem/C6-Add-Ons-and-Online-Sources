﻿using System;
using System.Windows.Forms;
using SwissAcademic.Citavi.Shell;
using SwissAcademic.Controls;
using ImportSequenceNumberAddon.Properties;
using SwissAcademic.Resources;
using SwissAcademic.Citavi;

namespace ImportSequenceNumberAddon
{
    public class ImportSequenceNumberAddon : CitaviAddOn
    {
        #region Fields

        CommandbarButton _button;

        #endregion

        #region Properties

        public override AddOnHostingForm HostingForm
        {
            get { return AddOnHostingForm.MainForm; }
        }

        #endregion

        #region Eventhandler

        protected override void OnHostingFormLoaded(Form hostingForm)
        {
            if (hostingForm is MainForm mainForm)
            {
                _button = mainForm.GetMainCommandbarManager().GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu).GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.FileThisProject).AddCommandbarButton(AddonKeys.MenuCommand, ImportSequenceNumberStrings.MenuCaption);
                if (_button != null) _button.HasSeparator = true;
            }

            base.OnHostingFormLoaded(hostingForm);
        }

        async protected override void OnBeforePerformingCommand(BeforePerformingCommandEventArgs e)
        {

            if (e.Form is MainForm mainForm && e.Key.Equals(AddonKeys.MenuCommand, StringComparison.OrdinalIgnoreCase))
            {
                if (mainForm.Project.ProjectType == ProjectType.DesktopSQLite)
                {
                    using (var openFileDialog = new OpenFileDialog()
                    {
                        Title = ImportSequenceNumberStrings.OpenFileDialogTitle,
                        Filter = ImportSequenceNumberStrings.OpenFileDialogFilters,
                        CheckFileExists = true,
                        CheckPathExists = true,
                        Multiselect = false
                    })

                        if (openFileDialog.ShowDialog(e.Form) == DialogResult.OK)
                        {
                            try
                            {
                                var projectConfiguration = await SwissAcademic.Citavi.DesktopProjectConfiguration.OpenAsync(SwissAcademic.Citavi.Shell.Program.Engine, openFileDialog.FileName);

                                if (projectConfiguration.SQLiteProjectInfo.IsProtected.GetValueOrDefault(false) == false)
                                {
                                    var sequenceNumbers = SequenceNumberImportInfoUtilities.Load(openFileDialog.FileName);
                                    sequenceNumbers.LoadTargetReferences(mainForm.Project.References);

                                    if (sequenceNumbers.Count != 0)
                                    {
                                        using (var chooseTargetFieldDialog = new ChoosePropertyIdDialog(mainForm.Project, sequenceNumbers) { Icon = e.Form.Icon })
                                        {
                                            if (chooseTargetFieldDialog.ShowDialog(e.Form) == DialogResult.OK)
                                            {
                                                sequenceNumbers.StoreTargetReferences(chooseTargetFieldDialog.SelectedPropertyId);

                                                var successCount = sequenceNumbers.GetSuccesImportCount();
                                                switch (successCount)
                                                {
                                                    case 0:
                                                        MessageBox.Show(e.Form, ImportSequenceNumberStrings.CompleteZeroResultMessage, ImportSequenceNumberStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        break;
                                                    case 1:
                                                        MessageBox.Show(e.Form, ImportSequenceNumberStrings.CompleteSingleResultMessage, ImportSequenceNumberStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        break;
                                                    default:
                                                        MessageBox.Show(e.Form, ImportSequenceNumberStrings.CompleteMultipleResultsMessage.FormatString(successCount), ImportSequenceNumberStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(e.Form, ImportSequenceNumberStrings.FoundReferenceCountNull, ImportSequenceNumberStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(e.Form, ImportSequenceNumberStrings.OpenProtectedProjectMessage, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(e.Form, ImportSequenceNumberStrings.OpenProjectConfigurationException, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
                else
                {
                    MessageBox.Show(e.Form, ImportSequenceNumberStrings.OnlyDesktopProjectsSupport, ImportSequenceNumberStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                e.Handled = true;
            }
        }

        protected override void OnLocalizing(Form hostingForm)
        {
            if (_button != null)
            {
                _button.Text = ImportSequenceNumberStrings.MenuCaption;
            }

            base.OnLocalizing(hostingForm);
        }

        #endregion
    }
}
