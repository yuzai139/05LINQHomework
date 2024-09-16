namespace Starter
{
    partial class FrmHelloLinq
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnQArray = new System.Windows.Forms.Button();
            this.btnQString = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.btnArray = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.productsTableAdapter1 = new LinqLabs.Dataset.NWDataSetTableAdapters.ProductsTableAdapter();
            this.nWthDataSet11 = new LinqLabs.Dataset.NWDataSet();
            this.button2 = new System.Windows.Forms.Button();
            this.ordersTableAdapter1 = new LinqLabs.Dataset.NWDataSetTableAdapters.OrdersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWthDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQArray
            // 
            this.btnQArray.BackColor = System.Drawing.SystemColors.Control;
            this.btnQArray.ForeColor = System.Drawing.Color.Black;
            this.btnQArray.Location = new System.Drawing.Point(169, 237);
            this.btnQArray.Margin = new System.Windows.Forms.Padding(5);
            this.btnQArray.Name = "btnQArray";
            this.btnQArray.Size = new System.Drawing.Size(362, 59);
            this.btnQArray.TabIndex = 25;
            this.btnQArray.Text = "a taste of Linq - int[]";
            this.btnQArray.UseVisualStyleBackColor = false;
            this.btnQArray.Click += new System.EventHandler(this.btnQArray_Click);
            // 
            // btnQString
            // 
            this.btnQString.BackColor = System.Drawing.SystemColors.Control;
            this.btnQString.ForeColor = System.Drawing.Color.Black;
            this.btnQString.Location = new System.Drawing.Point(169, 316);
            this.btnQString.Margin = new System.Windows.Forms.Padding(5);
            this.btnQString.Name = "btnQString";
            this.btnQString.Size = new System.Drawing.Size(362, 59);
            this.btnQString.TabIndex = 24;
            this.btnQString.Text = "a taste of Linq - string[]";
            this.btnQString.UseVisualStyleBackColor = false;
            this.btnQString.Click += new System.EventHandler(this.btnQString_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(165, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 100);
            this.label1.TabIndex = 23;
            this.label1.Text = "What is Linq \r\n\r\n統一資料存取 - 徹底融入語言";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(926, 14);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(456, 256);
            this.listBox1.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(166, 549);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 18);
            this.label9.TabIndex = 59;
            this.label9.Text = "Demo :";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Blue;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(171, 601);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(313, 56);
            this.button3.TabIndex = 60;
            this.button3.Text = "Advanced";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button49
            // 
            this.button49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button49.Location = new System.Drawing.Point(171, 44);
            this.button49.Margin = new System.Windows.Forms.Padding(5);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(159, 42);
            this.button49.TabIndex = 61;
            this.button49.Text = "參考 / 匯入";
            this.button49.UseVisualStyleBackColor = false;
            // 
            // btnArray
            // 
            this.btnArray.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArray.Location = new System.Drawing.Point(488, 22);
            this.btnArray.Name = "btnArray";
            this.btnArray.Size = new System.Drawing.Size(119, 44);
            this.btnArray.TabIndex = 62;
            this.btnArray.Text = "int [ ]";
            this.btnArray.UseVisualStyleBackColor = true;
            this.btnArray.Click += new System.EventHandler(this.btnArray_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(488, 81);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(291, 44);
            this.btnList.TabIndex = 63;
            this.btnList.Text = "List< >- IEnumerable<T>";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(928, 286);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(456, 281);
            this.dataGridView1.TabIndex = 64;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(578, 237);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(321, 345);
            this.chart1.TabIndex = 65;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(169, 404);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(362, 59);
            this.button1.TabIndex = 66;
            this.button1.Text = "LINQ to NW Dataset - Products";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // nWthDataSet11
            // 
            this.nWthDataSet11.DataSetName = "NWthDataSet1";
            this.nWthDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(169, 473);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(362, 59);
            this.button2.TabIndex = 67;
            this.button2.Text = "1997 orders";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ordersTableAdapter1
            // 
            this.ordersTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmHelloLinq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 743);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnArray);
            this.Controls.Add(this.button49);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnQArray);
            this.Controls.Add(this.btnQString);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmHelloLinq";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWthDataSet11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQArray;
        private System.Windows.Forms.Button btnQString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button49;
        private System.Windows.Forms.Button btnArray;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private LinqLabs.Dataset.NWDataSetTableAdapters.ProductsTableAdapter productsTableAdapter1;
        private System.Windows.Forms.Button button1;
        private LinqLabs.Dataset.NWDataSet nWthDataSet11;
        private System.Windows.Forms.Button button2;
        private LinqLabs.Dataset.NWDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter1;
    }
}

