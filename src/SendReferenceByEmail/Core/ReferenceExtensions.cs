﻿using SwissAcademic.Addons.SendReferenceByEmail.Properties;
using SwissAcademic.Citavi;
using SwissAcademic.Citavi.DataExchange;
using SwissAcademic.Citavi.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissAcademic.Addons.SendReferenceByEmail
{
    static class CitaviExtensions
    {
        public static async Task SendByEMailAsync(this Reference reference, MainForm mainForm)
        {
            var mailTemplate = new MailTemplate();
            var attachmentFileNames = new StringBuilder();

            foreach (var location in reference.Locations.GetAvailable())
            {
                var fileInfo = new FileInfo(location.Address.Resolve().GetLocalPathSafe());
                mailTemplate.Attachments.Add(fileInfo.FullName);
                attachmentFileNames.AppendLine(fileInfo.Name);
            }

            var shortTitle = (string.IsNullOrEmpty(reference.ShortTitle)
                             ? SendReferenceByEmailResources.ShortTitleMissing
                             : reference.ShortTitle).UnciodeToLatin();

            mailTemplate.Subject = "Citavi: " + shortTitle;

            var stringBuilder = new StringBuilder();
            foreach (var c in shortTitle)
            {
                if (c < 32 || c > 254) continue;
                stringBuilder.Append(c);
                if (stringBuilder.Length > 50) break;
            }
            shortTitle = Path2.GetValidFileName(stringBuilder.ToString());
            var risTempFileName = Path.Combine(Path.GetTempPath(), shortTitle + ".ris");
            var risExportDataExchangeProptery = new FileExportDataExchangeProperty
            {
                FileName = risTempFileName,
                ExportReferences = new List<Reference>() { reference },
                Transformer = Program.Engine.TransformerManager.GetById(Transformer.RISTransformerId)
            };
            var exporter = new Exporter();
            var success = false;
            using (var fs = File.OpenWrite(risTempFileName))
            {
                success = await exporter.RunAsync(risExportDataExchangeProptery, fs, CancellationToken.None, null);
            }
            if (!success) return;

            mailTemplate.Attachments.Add(risTempFileName);
            attachmentFileNames.AppendLine(Path.GetFileName(risTempFileName));

            mailTemplate.Body = mailTemplate.Attachments.Count > 0
                        ? string.Format(SendReferenceByEmailResources.SendReferenceByEMailBodyText_WithAttachments, reference.Project.Name, reference.ToString(TextFormat.Text), attachmentFileNames.ToString())
                        : string.Format(SendReferenceByEmailResources.SendReferenceByEMailBodyText, reference.Project.Name, reference.ToString(TextFormat.Text));

            try
            {
                Outlook.Send(mailTemplate);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show(mainForm, SendReferenceByEmailResources.OutlookRightsMessage, mainForm.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static IEnumerable<Location> GetAvailable(this ReferenceLocationCollection locations)
        {
            return (from location in locations
                    where
                       location.LocationType == LocationType.ElectronicAddress &&
                       ((location.Address.LinkedResourceType == LinkedResourceType.AttachmentRemote &&
                       location.Address.CachingStatus == CachingStatus.Available) ||
                       (
                           location.Address.LinkedResourceType == LinkedResourceType.AttachmentFile ||
                           location.Address.LinkedResourceType == LinkedResourceType.AbsoluteFileUri ||
                           location.Address.LinkedResourceType == LinkedResourceType.RelativeFileUri
                       )) &&
                       File.Exists(location.Address.Resolve().GetLocalPathSafe())
                    select location).ToList();
        }

    }
}
