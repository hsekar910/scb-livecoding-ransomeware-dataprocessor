using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ransomware_dataprocessor.Data
{
    public class Ransomware
    {
        public List<string> Name { get; set; } = new List<string>();
        public string Extensions { get; set; } = string.Empty;
        public string ExtensionPattern { get; set; } = string.Empty;
        public string RansomNoteFilenames { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string EncryptionAlgorithm { get; set; } = string.Empty;
        public string Decryptor { get; set; } = string.Empty;
        public List<string> Resources { get; set; } = new List<string>();
        public string Screenshots { get; set; } = string.Empty;
        public string MicrosoftDetectionName { get; set; } = string.Empty;
        public string MicrosoftInfo { get; set; } = string.Empty;
        public string Sandbox { get; set; } = string.Empty;
        public string Icos { get; set; } = string.Empty;
        public string Snort { get; set; } = string.Empty;

        public override string ToString()
        {
            return @"""name""" + ": \"" + string.Join(", ", Name) + "\"," + Environment.NewLine +
                   @"""Extensions""" + ": \"" + @"" + Extensions + "\"," + Environment.NewLine +
                   @"""ExtensionPattern""" + ": \"" + @"" + ExtensionPattern + "\"," + Environment.NewLine +
                   @"""RansomNoteFilenames""" + ": \"" + @"" + RansomNoteFilenames + "\"," + Environment.NewLine +
                   @"""Comment""" + ": \"" + @"" + Comment + "\"," + Environment.NewLine +
                   @"""EncryptionAlgorithm""" + ": \"" + @"" + EncryptionAlgorithm + "\"," + Environment.NewLine +
                   @"""Decryptor""" + ": \"" + @"" + Decryptor + "\"," + Environment.NewLine +
                   @"""Resources""" + ": \"" + @"" + string.Join(", ", Resources) + "\"," + Environment.NewLine +
                   @"""Screenshots""" + ": \"" + @"" + Screenshots + "\"," + Environment.NewLine +
                   @"""MicrosoftDetectionName""" + ": \"" + @"" + MicrosoftDetectionName + "\"," + Environment.NewLine +
                   @"""MicrosoftInfo""" + ": \"" + @"" + MicrosoftInfo + "\"," + Environment.NewLine +
                   @"""Sandbox""" + ": \"" + @"" + Sandbox + "\"," + Environment.NewLine +
                   @"""Icos""" + ": \"" + @"" + Icos + "\"," + Environment.NewLine +
                   @"""Snort""" + ": \"" + @"" + Snort + "\"";
        }
    }
}
