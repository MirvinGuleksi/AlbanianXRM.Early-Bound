﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.IO;

namespace AlbanianXrm.EarlyBound.Helpers
{
    class MemoryStreamEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return GetVersion(value as Version);
        }

        public static Version GetVersion(Version value)
        {
            string dir = Path.GetDirectoryName(typeof(MyPluginControl).Assembly.Location).ToLower();
            string folder = Path.GetFileNameWithoutExtension(typeof(MyPluginControl).Assembly.Location);
            dir = Path.Combine(dir, folder);
            FileInfo crmSvcUtil = new FileInfo(Path.Combine(dir, "Microsoft.IO.RecyclableMemoryStream.dll"));
            if (crmSvcUtil.Exists)
            {
                return new Version(FileVersionInfo.GetVersionInfo(crmSvcUtil.FullName).FileVersion);
            }
            return value;
        }
    }
}
