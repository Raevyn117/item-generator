using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Endoskeleton_Item_Generator
{
    public partial class Form1 : Form
    {
        public Database db;
        public enum SelectedRDO { ENEMY = 0, CACHE, ROLL };

        public Form1()
        {
            InitializeComponent();

            db = new Database();
            cbxEnemyType.SelectedIndex = 0;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lbxResults.Items.Clear();
            List<Item> temp;

            if (rdoEnemy.Checked)
                temp = db.GetItems(cbxEnemyType.SelectedIndex, SelectedRDO.ENEMY);
            else if (rdoRoll.Checked)
            {
                int Roll;
                try { Roll = int.Parse(txtRollValue.Text); }
                catch (Exception ex)
                {
                    string strMsg = String.Format("Roll value not a recognized. Please enter an integer. {0}", ex.Message);
                    MessageBox.Show(strMsg, "ItemGenerator - Form1 - Get Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                temp = db.GetItems(Roll, SelectedRDO.ROLL);
            }
            else
                temp = db.GetItems(0, SelectedRDO.CACHE);

            if (temp.Count == 0)
            {
                lbxResults.Items.Add("(none)");
                return;
            }

            foreach (Item i in temp)
            {
                lbxResults.Items.Add(i.ToString());

                if (lbxFound.Items[0].ToString() == "(none)")
                    lbxFound.Items.Clear();
                lbxFound.Items.Add(i.ToString());
            }
        } // btnGo_Click

        private void rdoCache_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEnemy.Checked)
            {
                txtRollValue.Enabled = false;

                cbxEnemyType.Enabled = true;
            }
            else
            {
                txtRollValue.Enabled = true;

                cbxEnemyType.Enabled = false;
            }
        } // rdoCache_CheckedChanged

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.FullWrite();
        } // Form1_FormClosing

        private void btnShowDB_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

            Control[] FoundControl = f2.Controls.Find("lbxOut", false);
            ListBox FoundBox;
            try { FoundBox = (ListBox)FoundControl[0]; }
            catch (Exception f)
            {
                string strMsg = String.Format("Could not find proper control on Database form. {0}", f.Message);
                MessageBox.Show(strMsg, "ItemGenerator - Form1 - ShowDB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            db.DumpAllContent(ref FoundBox);
        } // btnShowDB_Click

        private void btnShowRemoved_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Text = "History";
            f2.Show();

            Control[] FoundControl = f2.Controls.Find("lbxOut", false);
            ListBox FoundBox;
            try { FoundBox = (ListBox)FoundControl[0]; }
            catch (Exception f)
            {
                string strMsg = String.Format("Could not find proper control on Database form. {0}", f.Message);
                MessageBox.Show(strMsg, "ItemGenerator - Form1 - ShowRemoved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            db.DumpAllRemoved(ref FoundBox);
        } // btnShowRemoved_Click

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbxFound.Items.Clear();
            lbxFound.Items.Add("(none)");
        } 
    }
}
