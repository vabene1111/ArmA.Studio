﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Document;

namespace ArmA.Studio.Data.Lint
{
    public sealed class LintInfo : ISegment
    {
        public int Line { get; set; }
        public int LineOffset { get; set; }
        public ESeverity Severity { get; set; }
        public int EndOffset => this.StartOffset + this.Length;
        public int Offset => this.StartOffset;

        public int Length { get; set; }
        public int StartOffset { get; set; }
        public string Message { get; set; }

        public ProjectFile FileReference { get; private set; }
        public string FileName => this.FileReference.FileName;
        public string FilePath => this.FileReference.FilePath;

        public static implicit operator TextSegment(LintInfo sErr)
        {
            return new TextSegment() { StartOffset = sErr.StartOffset, Length = sErr.Length, EndOffset = sErr.EndOffset };
        }

        public LintInfo(ProjectFile pf)
        {
            this.FileReference = pf;
        }
    }
}
