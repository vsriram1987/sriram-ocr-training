using System.IO;

namespace sriram_ocr_training
{
    public static class Properties
    {
        public static string GetProperty(string keyToReturn)
        {
            string propertyValue = "\0";
            foreach (string line in File.ReadAllLines("Properties.txt"))
            {
                if ((!string.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();

                    if (key == keyToReturn)
                    {
                        if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                            (value.StartsWith("'") && value.EndsWith("'")))
                        {
                            value = value.Substring(1, value.Length - 2);
                        }
                        propertyValue = value;
                    }
                }
            }

            return propertyValue;
        }
    }
}