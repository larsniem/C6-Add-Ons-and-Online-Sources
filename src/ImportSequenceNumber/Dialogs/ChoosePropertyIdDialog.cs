﻿using SwissAcademic.Addons.ImportSequenceNumber.Properties;
using SwissAcademic.Citavi;
using SwissAcademic.Citavi.Metadata;
using SwissAcademic.Resources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SwissAcademic.Addons.ImportSequenceNumber
{
    public partial class ChoosePropertyIdDialog : Form
    {
        #region Fields

        Project _project;
        List<SequenceNumberImportInfo> _sequenceNumberImportInfos;

        #endregion

        #region Constructors
        public ChoosePropertyIdDialog(Project project, List<SequenceNumberImportInfo> sequenceNumberImportInfos)
        {
            InitializeComponent();
            _project = project;
            _sequenceNumberImportInfos = sequenceNumberImportInfos;
            Initialize();
        }

        #endregion

        #region Properties

        public ReferencePropertyId SelectedPropertyId => ConvertIndexToPropertyId(cboTargets.SelectedIndex);

        #endregion

        #region Methods

        ReferencePropertyId ConvertIndexToPropertyId(int index)
        {
            switch (cboTargets.SelectedIndex)
            {
                case 0:
                    return ReferencePropertyId.CustomField1;
                case 1:
                    return ReferencePropertyId.CustomField2;
                case 2:
                    return ReferencePropertyId.CustomField3;
                case 3:
                    return ReferencePropertyId.CustomField4;
                case 4:
                    return ReferencePropertyId.CustomField5;
                case 5:
                    return ReferencePropertyId.CustomField6;
                case 6:
                    return ReferencePropertyId.CustomField7;
                case 7:
                    return ReferencePropertyId.CustomField8;
                case 8:
                    return ReferencePropertyId.CustomField9;
                default:
                    throw new NotSupportedException();
            }
        }

        void Initialize()
        {
            btnOk.Text = ControlTexts.okButton;
            btnCancel.Text = ControlTexts.CancelButton;
            lblDescription.Text = ImportSequenceNumberResources.ChooseFieldMessage;

            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField1].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField2].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField3].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField4].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField5].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField6].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField7].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField8].LabelText);
            cboTargets.Items.Add(_project.ProjectSettings.CustomFields[ReferencePropertyDescriptor.CustomField9].LabelText);
            cboTargets.SelectedIndex = 0;
        }

        #endregion

        #region Eventhandler

        void BtnOk_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        void BtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        #endregion
    }
}
