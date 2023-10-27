namespace ClipSync.Logic
{
    public enum ClipboardFormat : byte
    {
        /// <summary>Specifies the standard ANSI text format. This static field is read-only.
        /// </summary>
        Text,

        /// <summary>Specifies the standard Windows Unicode text format. This static field
        /// is read-only.</summary>
        UnicodeText,

        /// <summary>Specifies the Windows device-independent bitmap (DIB) format. This static
        /// field is read-only.</summary>
        Dib,

        /// <summary>Specifies a Windows bitmap format. This static field is read-only.</summary>
        Bitmap,

        /// <summary>Specifies the Windows enhanced metafile format. This static field is
        /// read-only.</summary>
        EnhancedMetafile,

        /// <summary>Specifies the Windows metafile format, which Windows Forms does not
        /// directly use. This static field is read-only.</summary>
        MetafilePict,

        /// <summary>Specifies the Windows symbolic link format, which Windows Forms does
        /// not directly use. This static field is read-only.</summary>
        SymbolicLink,

        /// <summary>Specifies the Windows Data Interchange Format (DIF), which Windows Forms
        /// does not directly use. This static field is read-only.</summary>
        Dif,

        /// <summary>Specifies the Tagged Image File Format (TIFF), which Windows Forms does
        /// not directly use. This static field is read-only.</summary>
        Tiff,

        /// <summary>Specifies the standard Windows original equipment manufacturer (OEM)
        /// text format. This static field is read-only.</summary>
        OemText,

        /// <summary>Specifies the Windows palette format. This static field is read-only.
        /// </summary>
        Palette,

        /// <summary>Specifies the Windows pen data format, which consists of pen strokes
        /// for handwriting software, Windows Forms does not use this format. This static
        /// field is read-only.</summary>
        PenData,

        /// <summary>Specifies the Resource Interchange File Format (RIFF) audio format,
        /// which Windows Forms does not directly use. This static field is read-only.</summary>
        Riff,

        /// <summary>Specifies the wave audio format, which Windows Forms does not directly
        /// use. This static field is read-only.</summary>
        WaveAudio,

        /// <summary>Specifies the Windows file drop format, which Windows Forms does not
        /// directly use. This static field is read-only.</summary>
        FileDrop,

        /// <summary>Specifies the Windows culture format, which Windows Forms does not directly
        /// use. This static field is read-only.</summary>
        Locale,

        /// <summary>Specifies text consisting of HTML data. This static field is read-only.
        /// </summary>
        Html,

        /// <summary>Specifies text consisting of Rich Text Format (RTF) data. This static
        /// field is read-only.</summary>
        Rtf,

        /// <summary>Specifies a comma-separated value (CSV) format, which is a common interchange
        /// format used by spreadsheets. This format is not used directly by Windows Forms.
        /// This static field is read-only.</summary>
        CommaSeparatedValue,

        /// <summary>Specifies the Windows Forms string class format, which Windows Forms
        /// uses to store string objects. This static field is read-only.</summary>
        StringFormat,

        /// <summary>Specifies a format that encapsulates any type of Windows Forms object.
        /// This static field is read-only.</summary>
        Serializable,
    }
}