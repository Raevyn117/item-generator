using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Endoskeleton_Item_Generator
{
    class FileReader
    {
        private Stream m_fin;
        public bool m_bFileOpen = false;

        public FileReader(string sFilePath)
        {
            if (!OpenTheFile(sFilePath)) // try to open file
                return;

            m_bFileOpen = true;
        } // FileReader (constructor)

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Handles opening the file and any related error handling. Taken from IteratorXA, by Casey Dutro.
        /// 
        /// Pre:  sFilePath has been assigned.
        /// Post: the file has been opened and true returned, OR the file has filed to 
        ///       open because either it did not exist or the user selected cancel and 
        ///       false has been returned.
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns>True if file opened, false otherwise</returns>
        public bool OpenTheFile(string sFilePath)
        {
            try // try to open the file
            {
                m_fin = new FileStream(sFilePath, FileMode.Open); // if it works, great!
            }
            catch (Exception e) // otherwise, yell at the user some more
            {
                return false;
            }
            return true;
        } // OpenTheFile

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Closes the open file if there is one.
        /// </summary>
        public void CloseFile()
        {
            m_fin.Close();
        } // CloseFile

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Reads and returns the next line in the file or an empty string if end of file.
        /// </summary>
        /// <returns>Line read from file</returns>
        public string GetNextLine()
        {
            string sCurrentLine = "";
            char cCurrentByte;

            do // read until it has a full line from the file
            {
                cCurrentByte = (char)m_fin.ReadByte();
                if (cCurrentByte == 65535)
                {
                    CloseFile();
                    m_bFileOpen = false;
                    break;
                }
                sCurrentLine += cCurrentByte;
            } while (cCurrentByte != '\n');

            if (sCurrentLine == "END")
                return "";
            else
                return sCurrentLine;
        } // GetNextLine
    } // FileReader (class)
}
