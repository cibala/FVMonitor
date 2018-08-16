/*
 * Created by SharpDevelop.
 * User: dwang21
 * Date: 7/31/2018
 * Time: 9:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System; 

namespace FVMonitor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Drawing.Bitmap bmp;
		private System.Drawing.Bitmap bmpPreview;
		private System.Drawing.Graphics gr;
		private System.Drawing.Graphics grPreview;
		private System.Windows.Forms.Button btn_setROI;
		private System.Drawing.Point startROI;
		private float[,] kernel_v;
		private float[,] kernel_h;
		private int[,] kernel_int_v;
		private int[,] kernel_int_h;
		private System.Windows.Forms.Label label1;
		private double MaxFV;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private int ROIW, ROIH;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.btn_setROI = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(300, 300);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1ProgressChanged);
			// 
			// btn_setROI
			// 
			this.btn_setROI.Location = new System.Drawing.Point(329, 12);
			this.btn_setROI.Name = "btn_setROI";
			this.btn_setROI.Size = new System.Drawing.Size(75, 23);
			this.btn_setROI.TabIndex = 2;
			this.btn_setROI.Text = "Set Center";
			this.btn_setROI.UseVisualStyleBackColor = true;
			this.btn_setROI.Click += new System.EventHandler(this.Btn_setROIClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(329, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(329, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "label2";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(329, 122);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Reset Max";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 327);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_setROI);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "FVMonitor";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
