﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ArmA.Studio.Data;
using ArmA.Studio.Data.IntelliSense;
using ArmA.Studio.Data.Lint;
using ArmA.Studio.Data.UI;
using ArmA.Studio.UI;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace ArmA.Studio.DefaultPlugin
{
    public class ConfigDocument : CodeEditorBaseDataContext, ILinterHost
    {
        public ConfigDocument() : this(null) { }
        public ConfigDocument(ProjectFile fileRef) : base(fileRef)
        {
            using (var memstream = new MemoryStream())
            using (var reader = HighlightingHelper.GetConfigXml(memstream))
                this.SyntaxHighlightingDefinition = HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }

        public bool IsDisplayed { get; set; }

        public IEnumerable<LintInfo> LinterInfo { get; set; }

        public IEnumerable<LintInfo> Lint(Stream stream, ProjectFile f)
        {
            var lintHelper = new ConfigLintHelper();
            return lintHelper.Lint(stream, f);
        }

        public void LintWriteCache(Stream stream, ProjectFile f)
        {
            var lintHelper = new ConfigLintHelper();
            this.LinterInfo = lintHelper.Lint(stream, f);
        }

        protected override void OnEditorInitialized(TextEditor editor)
        {
            base.OnEditorInitialized(editor);
            this.EditorInstance.TextArea.TextView.BackgroundRenderers.Add(new UnderlineBackgroundRenderer(this));
        }
    }
}
