/*
 * Created by SharpDevelop.
 * User: dwang21
 * Date: 7/31/2018
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FVMonitor
{
	/// <summary>
	/// Description of Monitered.
	/// </summary>
	public partial class Monitered : Form
	{
		public Monitered()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			startROI.X = 0; startROI.Y = 0;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MoniteredMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
            startROI = e.Location;
		}
		void MoniteredMouseUp(object sender, MouseEventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
