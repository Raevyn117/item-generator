using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endoskeleton_Item_Generator
{
    public class Item
    {
        // Different kinds of items
        public enum Quality { FAIL=0, SUPER_COMMON, COMMON, UNCOMMON, RARE, LEGENDARY, MYTHIC };

        private string m_Name;     // Item name
        private Quality m_Rarity;    // How hard an item is to find
        private int m_NumFound;    // How many have been found so far, -1 means "doesn't matter"

        // Properties
        public string Name { get { return m_Name; } }
        public Quality Rarity { get { return m_Rarity; } }
        public int Found { get { return m_NumFound; } set { m_NumFound = value; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ItemName">New item name</param>
        /// <param name="ItemRarity"> New item rarity</param>
        /// <param name="TimesFound"> New item type</param>
        public Item(string ItemName, Quality ItemRarity, int TimesFound)
        {
            m_Name = ItemName;
            m_Rarity = ItemRarity;
            m_NumFound = TimesFound;
        } // Item

        /// <summary>
        /// Returns the Quality (enumerable) that matches the passed string, or FAIL if none match.
        /// </summary>
        /// <param name="sQuality">String to convert</param>
        /// <returns>Matching Quality or FAIL if none match</returns>
        public static Quality ToQualityType(string sQuality)
        {
            if (sQuality == Quality.SUPER_COMMON.ToString())
                return Quality.SUPER_COMMON;
            else if (sQuality == Quality.COMMON.ToString())
                return Quality.COMMON;
            else if (sQuality == Quality.UNCOMMON.ToString())
                return Quality.UNCOMMON;
            else if (sQuality == Quality.RARE.ToString())
                return Quality.RARE;
            else if (sQuality == Quality.LEGENDARY.ToString())
                return Quality.LEGENDARY;
            else if (sQuality == Quality.MYTHIC.ToString())
                return Quality.MYTHIC;
            else
                return Quality.FAIL;
        } // ToItemType

        /// <summary>
        /// Overrides the ToString function to write the item name.
        /// </summary>
        /// <returns>Item name as a string</returns>
        public override string ToString()
        {
            return this.m_Name;
        } // ToString

        /// <summary>
        /// Gets the full string for the item as it was read from the database.
        /// </summary>
        /// <returns>Full info for the item</returns>
        public string FullInfo()
        {
            return this.m_Name + "," + this.m_Rarity + "," + this.m_NumFound;
        } // FullInfo
    } // Item (class)
}
