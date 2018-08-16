/*
 * Created by SharpDevelop.
 * User: dwang21
 * Date: 7/31/2018
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FVMonitor
{
	partial class Monitered
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Drawing.Point startROI;
		
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
			this.SuspendLayout();
			// 
			// Monitered
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Name = "Monitered";
			this.Opacity = 0.01D;
			this.Text = "Monitered";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoniteredMouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoniteredMouseUp);
			this.ResumeLayout(false);

		}
	}
}
