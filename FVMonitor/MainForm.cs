/*
 * Created by SharpDevelop.
 * User: dwang21
 * Date: 7/31/2018
 * Time: 9:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FVMonitor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			backgroundWorker1.WorkerReportsProgress = true;
			// Parameters
			ROIW = 300;
			ROIH = 300;
			kernel_v = new float[,] { {-1,0,1}, {-2,0,2}, {-1,0,1} };
			kernel_h = new float[,] { {1,2,1}, {0,0,0}, {-1,-2,-1} };
			kernel_int_v = new int[,] { {-1,0,1}, {-2,0,2}, {-1,0,1} };
			kernel_int_h = new int[,] { {1,2,1}, {0,0,0}, {-1,-2,-1} };
			// End Parameters
			bmp = new Bitmap(ROIW, ROIH, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
			gr = Graphics.FromImage(bmp);
			bmpPreview = new Bitmap(ROIW, ROIH, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
			grPreview = Graphics.FromImage(bmpPreview);
			startROI = new System.Drawing.Point(12,12);
			startROI = PointToScreen(startROI);			
			MaxFV = 0;

			if (backgroundWorker1.IsBusy != true)
            {
				backgroundWorker1.RunWorkerAsync();		
			}
		}
		
		int [,] bmp2Gray(Bitmap inBmp){
			Color gotPixel;
			int[,] gray = new int[inBmp.Height, inBmp.Width];
			for(int y=0; y<inBmp.Height; y++){
				for(int x=0; x<inBmp.Width; x++){
					gotPixel = inBmp.GetPixel(x,y);
					gray[y,x] = (int)(0.299*gotPixel.R + 0.587*gotPixel.G + 0.114*gotPixel.B);
				}
			}
			return gray;
		}	
		
		int [] convKernel(int [,] img, int [,] kernel){
			int height = img.GetLength(0);
			int width = img.GetLength(1);
			int k_height = kernel.GetLength(0);
			int k_width = kernel.GetLength(1);
			int pad_x = (k_width-1)/2;
			int pad_y = (k_height-1)/2;
			int [] array = new int[ (height-2*pad_y)*(width-2*pad_x) ];
			int count = 0;
			for(int y=pad_y; y<height-pad_y; y++){
				for(int x=pad_x; x<width-pad_x; x++){
					for(int ky=0; ky< k_height; ky++){
						for(int kx=0; kx< k_width; kx++){
							array[count] += kernel[ky,kx]*img[y-pad_y+ky, x-pad_x+kx];
						}
					}
					count = count+1;
				}
			}
			return array;
		}
		
		double GetFV(Bitmap inBmp, int [,] kernel_int_v, int [,] kernel_int_h){
			double sum = 0;
			int [,] grayMatrix = bmp2Gray(inBmp);
			int [] vArray = convKernel(grayMatrix, kernel_int_v);
			int [] hArray = convKernel(grayMatrix, kernel_int_h);
			for(int i=0; i<vArray.GetLength(0); i++){
				sum += Math.Sqrt( Math.Pow(vArray[i],2) + Math.Pow(hArray[i],2) );
			}
			sum /= ROIW*ROIH;
			return sum;
		}

		void BackgroundWorker1DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			System.ComponentModel.BackgroundWorker worker = sender as System.ComponentModel.BackgroundWorker;
			double currFV = 0;	
			while(true){			
				if(startROI.X != 0 || startROI.Y != 0){
					gr.CopyFromScreen(startROI.X, startROI.Y, 0, 0, bmp.Size);												  
					currFV = GetFV(bmp, kernel_int_v, kernel_int_h); 	        		
				}
				worker.ReportProgress((int)(currFV*100));
			}
		}
		void BackgroundWorker1ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			grPreview.CopyFromScreen(startROI.X, startROI.Y, 0, 0, bmpPreview.Size);		
            pictureBox1.Image = bmpPreview;
			if((float)e.ProgressPercentage/100 > MaxFV){
				MaxFV = (float)e.ProgressPercentage/100;
			}
			label1.Text = ((float)e.ProgressPercentage/100).ToString();
			label2.Text = "Max: " + MaxFV.ToString();
		}
		void Btn_setROIClick(object sender, EventArgs e)
		{
			var form = new Monitered();
			DialogResult result = form.ShowDialog();
			if(result == DialogResult.OK){
				startROI.X = form.startROI.X - ROIH/2;
				startROI.Y = form.startROI.Y - ROIH/2;
				MaxFV = 0;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			MaxFV = 0;
			label2.Text = "Max: " + MaxFV.ToString();
		}
	}
}
