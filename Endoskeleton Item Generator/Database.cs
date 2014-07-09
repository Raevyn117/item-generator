using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Endoskeleton_Item_Generator
{
    public class Database
    {
        private List<Item> m_SuperCommon;
        private List<Item> m_Common;
        private List<Item> m_Uncommon;
        private List<Item> m_Rare;
        private List<Item> m_Legendary;
        private List<Item> m_Mythic;

        private List<Item> m_History;

        public Database()
        {
            FileReader frData = new FileReader("Items.txt");
            if (!frData.m_bFileOpen)
            {
                string strMsg = "File \"Items\" failed to open. Make sure you have the correct file path and that the file is not already open.";
                MessageBox.Show(strMsg, "ItemGenerator - Database - Database Constructor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            m_SuperCommon = new List<Item>();
            m_Common = new List<Item>();
            m_Uncommon = new List<Item>();
            m_Rare = new List<Item>();
            m_Legendary = new List<Item>();
            m_Mythic = new List<Item>();
            m_History = new List<Item>();

            while (frData.m_bFileOpen)
            {
                string NextLine = frData.GetNextLine();
                if (NextLine == "")
                    continue;

                string[] SplitLine = ParseLine(NextLine);
                Item temp = new Item(SplitLine[0], Item.ToQualityType(SplitLine[1]), int.Parse(SplitLine[2]));

                switch (temp.Rarity)
                {
                    case Item.Quality.SUPER_COMMON:
                    {
                        m_SuperCommon.Add(temp);
                        break;
                    }
                    case Item.Quality.COMMON:
                    {
                        m_Common.Add(temp);
                        break;
                    }
                    case Item.Quality.UNCOMMON:
                    {
                        m_Uncommon.Add(temp);
                        break;
                    }
                    case Item.Quality.RARE:
                    {
                        m_Rare.Add(temp);
                        break;
                    }
                    case Item.Quality.LEGENDARY:
                    {
                        m_Legendary.Add(temp);
                        break;
                    }
                    case Item.Quality.MYTHIC:
                    {
                        m_Mythic.Add(temp);
                        break;
                    }
                };
            }
           
            frData = new FileReader("History.txt");
            if (!frData.m_bFileOpen) // if there is no History file, we haven't made one yet
                return;

            while (frData.m_bFileOpen)
            {
                string NextLine = frData.GetNextLine();
                if (NextLine == "")
                    continue;

                string[] SplitLine = ParseLine(NextLine);
                Item temp = new Item(SplitLine[0], Item.ToQualityType(SplitLine[1]), int.Parse(SplitLine[2]));

                m_History.Add(temp);
            }
        } // Database (constructor)

        /// <summary>
        /// Parses out a line from the file for use in the Item constructor
        /// </summary>
        /// <param name="Line">Line read from file</param>
        /// <param name="IsUsable">Indicates if the returned information is usable</param>
        /// <returns>List of usable strings for the Item constructor</returns>
        private string[] ParseLine(string Line)
        {
            char[] del = {','};
            string[] str = Line.Split(del, 3);
            str[2] = str[2].Trim();

            return str;
        } // ParseLine

        /// <summary>
        /// Gets a set of items based on the parameters.
        /// </summary>
        /// <param name="IndexRoll">Contains either the Enemy Index or Roll by which Items must be search</param>
        /// <param name="Selection">Determines whether to treat IndexRoll as an Enemy Index, a Roll, or nothing in the case of a Cache</param>
        /// <returns></returns>
        public List<Item> GetItems(int IndexRoll, Form1.SelectedRDO Selection)
        {
            List<Item> temp = new List<Item>();
            Random rnd = new Random();

            switch (Selection)
            {
                case Form1.SelectedRDO.ROLL:
                {
                    int NumItems = (int)((float)IndexRoll / (float)5);

                    for (int i = 0; i < NumItems; i++)
                    {
                        Item.Quality ToFind = GetShiftedItemRoll(IndexRoll);
                        if (ToFind == Item.Quality.FAIL)
                            continue;
                        Item tempItem = SelectRandomItem(ToFind);

                        if (tempItem.Found != -1)
                        {
                            tempItem.Found++;
                            if (tempItem.Found == 2)
                                RemoveItem(tempItem, ToFind);
                        }

                        temp.Add(tempItem);
                        m_History.Add(tempItem);
                    }
                    break;
                }
                case Form1.SelectedRDO.ENEMY:
                {
                    int Shift;
                    switch (IndexRoll)
                    {
                        case 0: // Rahma Soldier
                        {
                            Shift = 12;
                            break;
                        }
                        case 1: // Rahma Engineer
                        {
                            Shift = 13;
                            break;
                        }
                        case 3: // AA Turret
                        {
                            Shift = 19;
                            break;
                        }
                        case 4: // Servator
                        {
                            Shift = 5;
                            break;
                        }
                        case 5: // Drone
                        {
                            Shift = 10;
                            break;
                        }
                        case 6: // Enforcer
                        {
                            Shift = 16;
                            break;
                        }
                        case 7: // Deceiver
                        {
                            Shift = 18;
                            break;
                        }
                        case 8: // Strider
                        {
                            Shift = 15;
                            break;
                        }
                        case 9: // Obelisk
                        {
                            Shift = 20;
                            break;
                        }
                        case 10: // Legate
                        {
                            Shift = 25;
                            break;
                        }
                        default: // Monolith
                        {
                            Shift = 30;
                            break;
                        }
                    };

                    Item.Quality ToFind = GetShiftedItemRoll(Shift);
                    if (ToFind == Item.Quality.FAIL)
                        break;
                    Item tempItem = SelectRandomItem(ToFind);

                    if (tempItem.Found != -1)
                    {
                        tempItem.Found++;
                        if (tempItem.Found == 2)
                            RemoveItem(tempItem, ToFind);
                    }

                    temp.Add(tempItem);
                    m_History.Add(tempItem);
                    break;
                }
                default:
                {
                    int CacheRoll = rnd.Next(1, 30); // determine quality
                    int NumItems = 1 + (int)((float)CacheRoll / (float)5);

                    for (int i = 0; i > NumItems; i++)
                    {
                        Item.Quality ToFind = GetShiftedItemRoll(CacheRoll);
                        if (ToFind == Item.Quality.FAIL)
                            continue;
                        Item tempItem = SelectRandomItem(ToFind);

                        if (tempItem.Found != -1)
                        {
                            tempItem.Found++;
                            if (tempItem.Found == 2)
                                RemoveItem(tempItem, ToFind);
                        }

                        temp.Add(tempItem);
                        m_History.Add(tempItem);
                    }
                    break;
                }
            };

            return temp;
        } // GetItems

        /// <summary>
        /// Determines Item rarity from a series of shifted rolls, where the shift improves 
        /// the chances of a higher quality Item. If at any point, the Item fails to increase
        /// in quality, it's current quality is returned.
        /// 
        /// Rolls are as follows:
        /// 1. At base, Item quality is "FAIL," or "no Item"
        /// 2. 100-sided die rolled, if shifted value is at or above 30, Item becomes Super Common
        /// 3. 100-sided die rolled, if shifted value is at or above 50, Item becomes Common
        /// 4. 100-sided die rolled, if shifted value is at or above 65, Item becomes Uncommon
        /// 5. 100-sided die rolled, if shifted value is at or above 80, Item becomes Rare
        /// 6. 100-sided die rolled, if shifted value is at or above 90, Item becomes Legendary
        /// 7. 100-sided die rolled, if shifted value is at or above 95, Item becomes Mythic
        /// </summary>
        /// <param name="Shift">Increases or decreases chance for higher quality items</param>
        /// <returns>Quality of item found</returns>
        private Item.Quality GetShiftedItemRoll(int Shift)
        {
            Random rnd = new Random();
            int Roll;
            int QualityIndex = 0;
            
            // Try for Super Common
            Roll = rnd.Next(1, 101);
            if (Roll + Shift >= 30)
                QualityIndex++;
            else
                return (Item.Quality)QualityIndex;

            // Try for Common
            Roll = rnd.Next(1, 101);
            if (Roll + Shift >= 50)
                QualityIndex++;
            else
                return (Item.Quality)QualityIndex;

            // Try for Uncommon
            Roll = rnd.Next(1, 101);
            if (Roll + Shift >= 65)
                QualityIndex++;
            else
                return (Item.Quality)QualityIndex;

            // Try for Rare
            Roll = rnd.Next(1, 101);
            if (Roll + Shift >= 80)
                QualityIndex++;
            else
                return (Item.Quality)QualityIndex;

            // Try for Legendary
            Roll = rnd.Next(1, 101);
            if (Roll + Shift >= 90)
                QualityIndex++;
            else
                return (Item.Quality)QualityIndex;

            // Try for Mythic
            Roll = rnd.Next(1, 101);
            if (Roll + Shift >= 95)
                QualityIndex++;

            return (Item.Quality)QualityIndex;
        } // GetShiftedItemRoll

        /// <summary>
        /// Selects an item at random from a database list determined by ItemQuality. 
        /// Assumes ItemQuality cannot be FAIL.
        /// </summary>
        /// <param name="ItemQuality">Determines which list to select from</param>
        /// <returns></returns>
        private Item SelectRandomItem(Item.Quality ItemQuality)
        {
            Random rnd = new Random();

            switch (ItemQuality)
            {
                case Item.Quality.SUPER_COMMON:
                {
                    return m_SuperCommon[rnd.Next(0, m_SuperCommon.Count)];
                }
                case Item.Quality.COMMON:
                {
                    return m_Common[rnd.Next(0, m_Common.Count)];
                }
                case Item.Quality.UNCOMMON:
                {
                    return m_Uncommon[rnd.Next(0, m_Uncommon.Count)];
                }
                case Item.Quality.RARE:
                {
                    return m_Rare[rnd.Next(0, m_Rare.Count)];
                }
                case Item.Quality.LEGENDARY:
                {
                    return m_Legendary[rnd.Next(0, m_Legendary.Count)];
                }
            };
            
            return m_Mythic[rnd.Next(0, m_Mythic.Count)];
        } // SelectRandomItem

        /// <summary>
        /// Removes item from the database
        /// </summary>
        /// <param name="ToRemove">Item to be removed</param>
        /// <param name="ItemQuality">Quality of the item, for use in determining which list to access</param>
        private void RemoveItem(Item ToRemove, Item.Quality ItemQuality)
        {
            switch (ItemQuality)
            {
                case Item.Quality.SUPER_COMMON:
                {
                    m_SuperCommon.Remove(ToRemove);
                    break;
                }
                case Item.Quality.COMMON:
                {
                    m_Common.Remove(ToRemove);
                    break;
                }
                case Item.Quality.UNCOMMON:
                {
                    m_Uncommon.Remove(ToRemove);
                    break;
                }
                case Item.Quality.RARE:
                {
                    m_Rare.Remove(ToRemove);
                    break;
                }
                case Item.Quality.LEGENDARY:
                {
                    m_Legendary.Remove(ToRemove);
                    break;
                }
            };

            m_Mythic.Remove(ToRemove);
        } // RemoveItem

        /// <summary>
        /// Adds the ToString value of all items in the database to a reference Listbox.
        /// </summary>
        /// <param name="lbx">Ref Listbox to add items to</param>
        public void DumpAllContent(ref ListBox lbx)
        {
            foreach (Item i in m_SuperCommon)
                lbx.Items.Add(i.ToString());
            foreach (Item i in m_Common)
                lbx.Items.Add(i.ToString());
            foreach (Item i in m_Uncommon)
                lbx.Items.Add(i.ToString());
            foreach (Item i in m_Rare)
                lbx.Items.Add(i.ToString());
            foreach (Item i in m_Legendary)
                lbx.Items.Add(i.ToString());
            foreach (Item i in m_Mythic)
                lbx.Items.Add(i.ToString());
        } // DumpAllContent

        /// <summary>
        /// Adds the ToString value of all items that have been removed from the database to a 
        /// reference Listbox.
        /// </summary>
        /// <param name="lbx">Ref Listbox to add items to</param>
        public void DumpAllRemoved(ref ListBox lbx)
        {
            foreach (Item i in m_History)
                lbx.Items.Add(i.ToString());
        } // DumpAllRemoved

        /// <summary>
        /// Commits a full write of all items to file.
        /// </summary>
        public void FullWrite()
        {
            using (StreamWriter strFOut = new StreamWriter("Items.txt"))
            {
                foreach (Item i in m_SuperCommon)
                    strFOut.WriteLine(i.FullInfo());
                foreach (Item i in m_Common)
                    strFOut.WriteLine(i.FullInfo());
                foreach (Item i in m_Uncommon)
                    strFOut.WriteLine(i.FullInfo());
                foreach (Item i in m_Rare)
                    strFOut.WriteLine(i.FullInfo());
                foreach (Item i in m_Legendary)
                    strFOut.WriteLine(i.FullInfo());
                foreach (Item i in m_Mythic)
                    strFOut.WriteLine(i.FullInfo());
                strFOut.Write("END");
            }

            using (StreamWriter strFOut = new StreamWriter("History.txt"))
            {
                foreach (Item i in m_History)
                    strFOut.WriteLine(i.FullInfo());
                strFOut.Write("END");
            }
        } // FullWrite
    } // Database (class)
}
