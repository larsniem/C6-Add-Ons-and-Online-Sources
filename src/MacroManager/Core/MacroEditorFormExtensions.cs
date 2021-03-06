﻿using SwissAcademic.Citavi.Shell;
using SwissAcademic.Citavi.Shell.Controls.Editors;
using System;
using System.Linq;

namespace SwissAcademic.Addons.MacroManager
{
    internal static class MacroEditorFormExtensions
    {
        public static void Run(this MacroEditorForm macroEditorForm)
        {
            var method = macroEditorForm.GetType()
                                        .GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                                        .FirstOrDefault(mth => mth.Name.Equals("PerformCommand", StringComparison.OrdinalIgnoreCase));

            if (method != null)
            {
                method.Invoke(macroEditorForm, new object[] { "Run", null, null, null });
            }
        }

        public static void SetFilePath(this MacroEditorForm macroEditorForm, string filePath)
        {
            var field = macroEditorForm.GetType()
                                            .GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                                            .FirstOrDefault(f => f.Name.Equals("_fileName", StringComparison.OrdinalIgnoreCase));

            if (field != null) field.SetValue(macroEditorForm, filePath);
        }

        public static bool IsDirty(this MacroEditorForm macroEditorForm)
        {
            var field = macroEditorForm.GetType()
                                            .GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                                            .FirstOrDefault(f => f.Name.Equals("macroEditor", StringComparison.OrdinalIgnoreCase));

            var editor = field.GetValue(macroEditorForm) as MacroEditorControl;

            if (editor == null) return false;

            return editor.Dirty;
        }

        public static void Save(this MacroEditorForm macroEditorForm)
        {
            var method = macroEditorForm.GetType()
                                        .GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                                        .FirstOrDefault(mth => mth.Name.Equals("PerformCommand", StringComparison.OrdinalIgnoreCase));

            if (method != null)
            {
                method.Invoke(macroEditorForm, new object[] { "Save", null, null, null });
            }
        }
    }
}
