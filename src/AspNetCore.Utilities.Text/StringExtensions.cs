using System;
using System.Linq;
using System.Xml;

namespace AspNetCore.Utilities.Text
{
    public static class StringExtensions
    {
        public static string SubstringAfter(this string text, string afterText = "@")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int textPosition = text.LastIndexOf(afterText, StringComparison.Ordinal);
                if (textPosition > 0)
                {
                    return text[(textPosition + 1)..];
                }

                return text;
            }

            return string.Empty;
        }

        public static string SubstringBefore(this string text, string beforeText = "@")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int textPosition = text.IndexOf(beforeText, StringComparison.Ordinal);
                if (textPosition > 0)
                {
                    return text.Substring(0, textPosition);
                }

                return text;
            }

            return string.Empty;
        }

        public static string Base64Encode(this string text)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }

        public static string RemoveInvalidXmlChars(this string text)
        {
            var validXmlChars = text.Where(XmlConvert.IsXmlChar).ToArray();
            return XmlConvert.EncodeName(new string(validXmlChars));
        }
    }
}
