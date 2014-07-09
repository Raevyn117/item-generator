namespace Endoskeleton_Item_Generator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdoEnemy = new System.Windows.Forms.RadioButton();
            this.rdoCache = new System.Windows.Forms.RadioButton();
            this.lbxResults = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnShowDB = new System.Windows.Forms.Button();
            this.cbxEnemyType = new System.Windows.Forms.ComboBox();
            this.lbxFound = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowRemoved = new System.Windows.Forms.Button();
            this.rdoRoll = new System.Windows.Forms.RadioButton();
            this.txtRollValue = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdoEnemy
            // 
            this.rdoEnemy.AutoSize = true;
            this.rdoEnemy.Checked = true;
            this.rdoEnemy.Location = new System.Drawing.Point(12, 12);
            this.rdoEnemy.Name = "rdoEnemy";
            this.rdoEnemy.Size = new System.Drawing.Size(57, 17);
            this.rdoEnemy.TabIndex = 0;
            this.rdoEnemy.TabStop = true;
            this.rdoEnemy.Text = "Enemy";
            this.rdoEnemy.UseVisualStyleBackColor = true;
            this.rdoEnemy.CheckedChanged += new System.EventHandler(this.rdoCache_CheckedChanged);
            // 
            // rdoCache
            // 
            this.rdoCache.AutoSize = true;
            this.rdoCache.Location = new System.Drawing.Point(15, 62);
            this.rdoCache.Name = "rdoCache";
            this.rdoCache.Size = new System.Drawing.Size(56, 17);
            this.rdoCache.TabIndex = 1;
            this.rdoCache.TabStop = true;
            this.rdoCache.Text = "Cache";
            this.rdoCache.UseVisualStyleBackColor = true;
            // 
            // lbxResults
            // 
            this.lbxResults.FormattingEnabled = true;
            this.lbxResults.Items.AddRange(new object[] {
            "(none)"});
            this.lbxResults.Location = new System.Drawing.Point(12, 155);
            this.lbxResults.Name = "lbxResults";
            this.lbxResults.Size = new System.Drawing.Size(213, 69);
            this.lbxResults.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(150, 126);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Get Items";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnShowDB
            // 
            this.btnShowDB.Location = new System.Drawing.Point(150, 79);
            this.btnShowDB.Name = "btnShowDB";
            this.btnShowDB.Size = new System.Drawing.Size(75, 23);
            this.btnShowDB.TabIndex = 6;
            this.btnShowDB.Text = "Database";
            this.btnShowDB.UseVisualStyleBackColor = true;
            this.btnShowDB.Click += new System.EventHandler(this.btnShowDB_Click);
            // 
            // cbxEnemyType
            // 
            this.cbxEnemyType.FormattingEnabled = true;
            this.cbxEnemyType.Items.AddRange(new object[] {
            "Rahma Soldier",
            "Rahma Engineer",
            "AA Turret",
            "Servator",
            "Drone",
            "Enforcer",
            "Deceiver",
            "Strider",
            "Obelisk",
            "Legate",
            "Monolith"});
            this.cbxEnemyType.Location = new System.Drawing.Point(28, 35);
            this.cbxEnemyType.Name = "cbxEnemyType";
            this.cbxEnemyType.Size = new System.Drawing.Size(110, 21);
            this.cbxEnemyType.TabIndex = 9;
            // 
            // lbxFound
            // 
            this.lbxFound.FormattingEnabled = true;
            this.lbxFound.Items.AddRange(new object[] {
            "(none)"});
            this.lbxFound.Location = new System.Drawing.Point(12, 264);
            this.lbxFound.Name = "lbxFound";
            this.lbxFound.Size = new System.Drawing.Size(213, 121);
            this.lbxFound.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Found This Combat";
            // 
            // btnShowRemoved
            // 
            this.btnShowRemoved.Location = new System.Drawing.Point(150, 103);
            this.btnShowRemoved.Name = "btnShowRemoved";
            this.btnShowRemoved.Size = new System.Drawing.Size(75, 23);
            this.btnShowRemoved.TabIndex = 7;
            this.btnShowRemoved.Text = "History";
            this.btnShowRemoved.UseVisualStyleBackColor = true;
            this.btnShowRemoved.Click += new System.EventHandler(this.btnShowRemoved_Click);
            // 
            // rdoRoll
            // 
            this.rdoRoll.AutoSize = true;
            this.rdoRoll.Location = new System.Drawing.Point(15, 85);
            this.rdoRoll.Name = "rdoRoll";
            this.rdoRoll.Size = new System.Drawing.Size(43, 17);
            this.rdoRoll.TabIndex = 12;
            this.rdoRoll.TabStop = true;
            this.rdoRoll.Text = "Roll";
            this.rdoRoll.UseVisualStyleBackColor = true;
            // 
            // txtRollValue
            // 
            this.txtRollValue.Location = new System.Drawing.Point(28, 105);
            this.txtRollValue.Name = "txtRollValue";
            this.txtRollValue.Size = new System.Drawing.Size(46, 20);
            this.txtRollValue.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(150, 235);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 413);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtRollValue);
            this.Controls.Add(this.rdoRoll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxFound);
            this.Controls.Add(this.cbxEnemyType);
            this.Controls.Add(this.btnShowRemoved);
            this.Controls.Add(this.btnShowDB);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxResults);
            this.Controls.Add(this.rdoCache);
            this.Controls.Add(this.rdoEnemy);
            this.Name = "Form1";
            this.Text = "Item Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoEnemy;
        private System.Windows.Forms.RadioButton rdoCache;
        private System.Windows.Forms.ListBox lbxResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnShowDB;
        private System.Windows.Forms.ComboBox cbxEnemyType;
        private System.Windows.Forms.ListBox lbxFound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowRemoved;
        private System.Windows.Forms.RadioButton rdoRoll;
        private System.Windows.Forms.TextBox txtRollValue;
        private System.Windows.Forms.Button btnClear;
    }
}

