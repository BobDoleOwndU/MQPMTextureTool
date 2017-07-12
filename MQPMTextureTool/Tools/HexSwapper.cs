using System;
using System.IO;
using System.Linq;

namespace MQPMTextureTool
{
    public static class HexSwapper
    {
        /*
         * Swap
         * Reads a file, converts the file to a string, replaces the old hex string with the newhex string then writes the edited hex string back to the file.
         */
        public static void Swap(string filepath, string oldHex, string newHex)
        {
            var file = File.ReadAllBytes(filepath);

            string hex = BitConverter.ToString(file).Replace("-", String.Empty);

            hex = hex.Replace(oldHex, newHex);

            File.WriteAllBytes(filepath, StringToByteArray(hex));
        } //method swap ends

        /*
         * ContainsHex
         * Checks if a file contains a specified hex pattern.
         */
        public static bool ContainsHex(string filepath, string hexPattern)
        {
            var file = File.ReadAllBytes(filepath);

            string hex = BitConverter.ToString(file).Replace("-", String.Empty);

            if (hex.Contains(hexPattern))
                return true;
            return false;
        } //method ContainsHex ends

        /*
         * StringToByteArray
         * Converts a hex string to an array of bytes.
         */
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        } //StringToByteArray ends
    } //class HexSwapper ends
} //namespace MQPMTool2 ends
