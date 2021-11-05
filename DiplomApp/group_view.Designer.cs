namespace DiplomApp
{
    partial class group_view
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(group_view));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graphicpanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.studentpanel = new System.Windows.Forms.Panel();
            this.panell = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.grouppanel = new System.Windows.Forms.Panel();
            this.gpanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.personalpanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.graphicpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.studentpanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grouppanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.personalpanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphicpanel
            // 
            this.graphicpanel.Controls.Add(this.button4);
            this.graphicpanel.Controls.Add(this.chart1);
            this.graphicpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.graphicpanel.Location = new System.Drawing.Point(0, 451);
            this.graphicpanel.Name = "graphicpanel";
            this.graphicpanel.Size = new System.Drawing.Size(1724, 301);
            this.graphicpanel.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(0, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 69);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1724, 301);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // studentpanel
            // 
            this.studentpanel.BackColor = System.Drawing.Color.White;
            this.studentpanel.Controls.Add(this.panell);
            this.studentpanel.Controls.Add(this.panel3);
            this.studentpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.studentpanel.Location = new System.Drawing.Point(292, 0);
            this.studentpanel.Name = "studentpanel";
            this.studentpanel.Size = new System.Drawing.Size(385, 451);
            this.studentpanel.TabIndex = 19;
            // 
            // panell
            // 
            this.panell.AutoScroll = true;
            this.panell.BackColor = System.Drawing.Color.Lavender;
            this.panell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panell.Location = new System.Drawing.Point(0, 70);
            this.panell.Name = "panell";
            this.panell.Size = new System.Drawing.Size(385, 381);
            this.panell.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 70);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(96)))));
            this.label4.Location = new System.Drawing.Point(85, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Назва дисципліни";
            // 
            // grouppanel
            // 
            this.grouppanel.BackColor = System.Drawing.Color.White;
            this.grouppanel.Controls.Add(this.gpanel);
            this.grouppanel.Controls.Add(this.panel1);
            this.grouppanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.grouppanel.Location = new System.Drawing.Point(0, 0);
            this.grouppanel.Name = "grouppanel";
            this.grouppanel.Size = new System.Drawing.Size(292, 451);
            this.grouppanel.TabIndex = 17;
            // 
            // gpanel
            // 
            this.gpanel.AutoScroll = true;
            this.gpanel.BackColor = System.Drawing.Color.Lavender;
            this.gpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpanel.Location = new System.Drawing.Point(0, 70);
            this.gpanel.Name = "gpanel";
            this.gpanel.Size = new System.Drawing.Size(292, 381);
            this.gpanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 70);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(96)))));
            this.label1.Location = new System.Drawing.Point(52, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер групи";
            // 
            // personalpanel
            // 
            this.personalpanel.BackColor = System.Drawing.Color.White;
            this.personalpanel.Controls.Add(this.panel4);
            this.personalpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personalpanel.Location = new System.Drawing.Point(677, 0);
            this.personalpanel.Name = "personalpanel";
            this.personalpanel.Size = new System.Drawing.Size(1047, 451);
            this.personalpanel.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1047, 451);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(76, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(885, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Для відображення таблиці успішності студентів оберіть номер группи та дисципліну";
            // 
            // group_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1724, 752);
            this.Controls.Add(this.personalpanel);
            this.Controls.Add(this.studentpanel);
            this.Controls.Add(this.grouppanel);
            this.Controls.Add(this.graphicpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1724, 752);
            this.Name = "group_view";
            this.Text = "diplom";
            this.Load += new System.EventHandler(this.diplom_Load);
            this.SizeChanged += new System.EventHandler(this.diplom_SizeChanged);
            this.graphicpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.studentpanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grouppanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.personalpanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel graphicpanel;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.Panel studentpanel;
        public System.Windows.Forms.Panel panell;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel grouppanel;
        public System.Windows.Forms.Panel gpanel;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Panel personalpanel;
        public System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
    }
}