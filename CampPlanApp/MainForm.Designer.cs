namespace CampPlanApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.map = new CampPlanApp.MapPanel();
            this.listViewTents = new System.Windows.Forms.ListView();
            this.columnTent = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(988, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testDataToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // testDataToolStripMenuItem
            // 
            this.testDataToolStripMenuItem.Name = "testDataToolStripMenuItem";
            this.testDataToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.testDataToolStripMenuItem.Text = "&Test Data";
            this.testDataToolStripMenuItem.Click += new System.EventHandler(this.testDataToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLocation});
            this.statusStrip.Location = new System.Drawing.Point(0, 516);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(988, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLocation
            // 
            this.toolStripStatusLabelLocation.Name = "toolStripStatusLabelLocation";
            this.toolStripStatusLabelLocation.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabelLocation.Text = "-";
            // 
            // map
            // 
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.Location = new System.Drawing.Point(3, 3);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(749, 486);
            this.map.TabIndex = 0;
            this.map.Tents = null;
            this.map.SelectionChanged += new System.Action<CampPlanApp.MapPanel>(this.map_SelectionChanged);
            this.map.ScaledMouseMove += new CampPlanApp.ScaledMouseEvent(this.map_ScaledMouseMove);
            // 
            // listViewTents
            // 
            this.listViewTents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTent});
            this.listViewTents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTents.Location = new System.Drawing.Point(758, 3);
            this.listViewTents.Name = "listViewTents";
            this.listViewTents.Size = new System.Drawing.Size(227, 486);
            this.listViewTents.TabIndex = 0;
            this.listViewTents.UseCompatibleStateImageBehavior = false;
            this.listViewTents.View = System.Windows.Forms.View.Details;
            this.listViewTents.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewTents_ItemSelectionChanged);
            // 
            // columnTent
            // 
            this.columnTent.Text = "Tent";
            this.columnTent.Width = 150;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.47059F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
            this.tableLayoutPanel.Controls.Add(this.listViewTents, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.map, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(988, 492);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 538);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Camp Plan";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem dataToolStripMenuItem;
        private ToolStripMenuItem testDataToolStripMenuItem;
        private StatusStrip statusStrip;
        private ListView listViewTents;
        private MapPanel map;
        private TableLayoutPanel tableLayoutPanel;
        private ToolStripStatusLabel toolStripStatusLabelLocation;
        private ColumnHeader columnTent;
    }
}