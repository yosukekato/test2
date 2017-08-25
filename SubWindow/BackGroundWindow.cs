using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BTWrapper
{
	using System;
	using System.Windows.Forms;

	using OxyPlot;
	using OxyPlot.Series;
	using OxyPlot.Axes;

	public partial class BackGroundWindow : Form
	{
		string savefilename = "";
		public string SaveFile
		{
			get { return savefilename; }
			set { savefilename = value; }
		}
		string openfilename;
		double pos_left_x = -1;
		double pos_left_y = -1;
		double pos_right_x = -1;
		double pos_right_y = -1;
		double defxmax;
		//Axis axisX, axisY;
		List<double> energy = new List<double>();
		List<double> absorption = new List<double>();

		LinearAxis axisX = new LinearAxis { Title = "energy(eV)", Position = AxisPosition.Bottom };
		LinearAxis axisY = new LinearAxis { Title = "mu", Position = AxisPosition.Left };
		PlotModel myModel = new PlotModel { Title = "Example 1" };
		ScatterSeries scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

		public BackGroundWindow(string filename)
		{
			this.InitializeComponent();
			openfilename = filename;
			this.ClientSize = new Size(500, 500);
			LoadFileAndDisplayToChart();
			defxmax = axisX.Maximum;
			//var myModel = new PlotModel { Title = "Example 1" };
			//var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
			//var myModel = new PlotModel { Title = "Example 1" };
			//myModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
			//this.chart_exp.Model = myModel;
		}
		private void LoadFileAndDisplayToChart()
		{
			//var myModel = new PlotModel { Title = "Example 1" };
			//var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

			foreach (string line in File.ReadLines(openfilename, BTMainForm.CharEncode))
			{
				if (line.StartsWith("#"))
					continue;
				string[] values = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				try
				{
					energy.Add(DoubleParse(values[0]));
					absorption.Add(DoubleParse(values[1]));
				}
				catch
				{
					MessageBox.Show("parse function failed");
				}
			}
			for (int i = 0; i < energy.Count; i++)
			{
				ScatterPoint dp = new ScatterPoint(energy[i], absorption[i], 3, 0);
				scatterSeries.Points.Add(dp);
			}

			myModel.Axes.Add(axisX);
			myModel.Axes.Add(axisY);

			myModel.Series.Add(scatterSeries);
			this.chart_exp.Model = myModel;


		}
		private void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}
		//.44のようなものも読み込めるように
		private double DoubleParse(string s)
		{
			if (s.StartsWith("."))
			{
				s = "0" + s;
			}
			try
			{
				return double.Parse(s);
			}
			catch
			{
				throw new Exception();
			}
		}

		private void txt_rightvalue_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int rval = int.Parse(txt_rightvalue.Text);
				if (rval > energy[0])
					axisX.Maximum = rval;
				myModel.InvalidatePlot(true);
				if (rval < -1)
					axisX.Maximum = defxmax;
			}
			catch { }
		}

		private void bt_decide_Click(object sender, EventArgs e)
		{
			savefilename = Directory.GetCurrentDirectory() + "/" + Path.GetFileNameWithoutExtension(openfilename) + ".nor";
			using (StreamWriter sw = new StreamWriter(savefilename, false, Encoding.ASCII))
			{
				sw.Write("#experimentdata without background\n");
				sw.Write("#energy xmu(nor)\n");
				for (int i = 0; i < energy.Count; i++)
				{
					sw.Write(energy[i] + " " + (absorption[i] - bgline(i)) + "\n");
				}
			}

			//chart_exp.Invalidate();
			//myModel.Axes.Clear();
			//axisX.Maximum = 10000;
			//myModel.InvalidatePlot(true);

			this.Close();
		}
		private void BackGroundWindow_SizeChanged(object sender, EventArgs e)
		{
			label1.Location = new Point(0, 5);
			txt_rightvalue.Location = new Point(label1.Width + 10, 5);
			chart_exp.Size = new Size(this.ClientSize.Width - 100, this.ClientSize.Height - 50);
			bt_decide.Location = new Point(0, this.ClientSize.Height - 25);
			bt_decide.Size = new Size(this.ClientSize.Width, 25);
		}
		private void chart_exp_Paint(object sender, PaintEventArgs e)
		{
			if (pos_left_x >= 0)
			{
				double x = axisX.Transform(pos_left_x);
				double y = axisY.Transform(pos_left_y);
				Rectangle r = new Rectangle((int)x - 5, (int)y - 5, 10, 10);
				e.Graphics.DrawEllipse(Pens.Red, r);
			}
			if (pos_right_x >= 0)
			{
				double x = axisX.Transform(pos_right_x);
				double y = axisY.Transform(pos_right_y);
				Rectangle r = new Rectangle((int)x - 5, (int)y - 5, 10, 10);
				e.Graphics.DrawEllipse(Pens.Red, r);
			}
			//直線引きます
			if (pos_left_x >= 0 && pos_right_x >= 0)
			{
				if (pos_left_x > pos_right_x)
				{
					Swap(ref pos_left_x, ref pos_right_x);
					Swap(ref pos_left_y, ref pos_right_y);
				}
				double a = (pos_right_y - pos_left_y) / (pos_right_x - pos_left_x);
				double b = pos_left_y - a * pos_left_x;
				double x1 = axisX.ActualMinimum;
				//double x1 = 8800;
				//double y1 = axisX.Minimum * a + b;
				double y1 = x1 * a + b;
				//double y1 = 8800 * a + b;
				double x2 = axisX.ActualMaximum;
				//double x2 = 13000;
				//double y2 = axisX.Maximum * a + b;
				//double y2 = 13000 * a + b;
				double y2 = x2 * a + b;
				//e.Graphics.DrawLine(Pens.Green,new Point((int)axisX.Transform(9000), (int)axisY.Transform(0)),new Point((int)axisX.Transform(10000),(int)axisY.Transform(-2)));
				axisY.Minimum = y2;
				myModel.InvalidatePlot(true);
				e.Graphics.DrawLine(Pens.Blue
				 , new Point((int)axisX.Transform(x1), (int)axisY.Transform(y1))
				, new Point((int)axisX.Transform(x2), (int)axisY.Transform(y2)));
			}
		}
		private void chart_exp_MouseDown(object sender, MouseEventArgs e)
		{

			//if (e.Button == MouseButtons.Left)
			//{
			scatterSeries.MouseDown += (s, e1) =>
			{
				if (e1.ChangedButton == OxyMouseButton.Left)
				{
					pos_left_x = (s as ScatterSeries).InverseTransform(e1.Position).X;
						//pos_left_x = axisX.PixelPositionToValue(e.X);
						//マウスX座標との差が最低になるエネルギーを探す
						double minv = energy.Min(x => Math.Abs(x - pos_left_x));
						//そのときのデータのインデックスを得る
						int k = energy.FindIndex(x => Math.Abs(x - pos_left_x) == minv);
						//セット
						pos_left_x = energy[k];
					pos_left_y = absorption[k];
					chart_exp.Invalidate();
						//};
						//}
						//if (e.Button == MouseButtons.Right)
						//{
						//scatterSeries.MouseDown += (s, e1) =>
						//{
					}
				if (e1.ChangedButton == OxyMouseButton.Right)
				{
					pos_right_x = (s as ScatterSeries).InverseTransform(e1.Position).X;

						//pos_right_x = axisX.PixelPositionToValue(e.X);
						double minv = energy.Min(x => Math.Abs(x - pos_right_x));
					int k = energy.FindIndex(x => Math.Abs(x - pos_right_x) == minv);
					pos_right_x = energy[k];
					pos_right_y = absorption[k];
					chart_exp.Invalidate();
				}
			};
			//}

		}
		private double bgline(int enindex)
		{
			//ax+b
			double a = (pos_right_y - pos_left_y) / (pos_right_x - pos_left_x);
			double b = pos_left_y - a * pos_left_x;
			return a * energy[enindex] + b;
		}
	}
}
