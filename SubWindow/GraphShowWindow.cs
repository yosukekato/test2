using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Windows.Forms.DataVisualization.Charting;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace BTWrapper
{
    //グラフウインドウ雛形
    public partial class GraphShowWindow : Form
    {
        protected SelectedArea SelArea = new SelectedArea();
        double DefXMin, DefXMax, DefYMin, DefYMax;
        protected LinearAxis AxisX, AxisY;
        protected bool EnableExtension = true;
        protected bool MousePressed = false;
        protected bool EnableAddGraph
        {
            get { return addGraphToolStripMenuItem.Enabled; }
            set { addGraphToolStripMenuItem.Enabled = deleteGraphToolStripMenuItem.Enabled = value; }
        }
        public string WindowText
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string XLabel
        {
            get { return AxisX.Title; }
            set { AxisX.Title = value; }
        }
        public string YLabel
        {
            get { return AxisY.Title; }
            set { AxisY.Title = value; }
        }

        public GraphShowWindow()
        {
            InitializeComponent();

            chart.Location = new Point(0, menuStrip1.Height);
            chart.Size = new Size(this.Width, this.Height - menuStrip1.Height*2);

            AxisX = chart.ChartAreas["ChartArea1"].AxisX;
            AxisY = chart.ChartAreas["ChartArea1"].AxisY;

            DefXMin = AxisX.Minimum;
            DefXMax = AxisX.Maximum;
            DefYMin = AxisY.Minimum;
            DefYMax = AxisY.Maximum;
            EnableAddGraph = false;
        }
        //サイズ変更
        private void GraphShowWindow_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                chart.Location = new Point(0, menuStrip1.Height);
                chart.Size = new Size(this.Width, this.Height - menuStrip1.Height * 2);
            }
        }
        //描画拡大系。後回し
        //表示範囲の変更
        public virtual void ChangeDrawArea()
        {
            SelArea.SetChartDrawArea(AxisX, AxisY);
        }
        public virtual void chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableExtension)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SelArea.SetLT(e.X, e.Y);
                    MousePressed = true;
                }
                if (e.Button == MouseButtons.Right)
                {
                    SelArea.CheckValue();
                    if (SelArea.CheckAreaInGraph(chart))
                        ChangeDrawArea();
                    chart.Invalidate();
                }
            }
        }
        public virtual void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (EnableExtension)
            {
                if (e.Button == MouseButtons.Left)
                {
                    MousePressed = false;
                    SelArea.SetRB(e.X, e.Y);
                    chart.Invalidate();
                }
            }
        }
        public virtual void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                SelArea.SetRB(e.X, e.Y);
                chart.Invalidate();
            }
        }
        private void chart_Paint(object sender, PaintEventArgs e)
        {
            //選択範囲の描画
            SelArea.Draw(e.Graphics);
        }

        //表示範囲変更処理
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AxisX.Minimum = DefXMin;
            AxisX.Maximum = DefXMax;
            AxisY.Minimum = DefYMin;
            AxisY.Maximum = DefYMax;
        }
        private void XYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xy = ((ToolStripMenuItem)sender).Text;
            MinMaxWindow mmw = new MinMaxWindow( xy );
            if (mmw.ShowDialog() == DialogResult.OK)
            {
                if (xy == "X")
                {
                    AxisX.Minimum = mmw.Min;
                    AxisX.Maximum = mmw.Max;
                }
                else
                {
                    AxisY.Minimum = mmw.Min;
                    AxisY.Maximum = mmw.Max;
                }
                chart.Invalidate();
            }
        }

        //表示されているグラフを保存
        private void saveGraphToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Graph.png";
            sfd.Filter = "png|*.png|jpg|*.jpg|bmp|*.bmp|tiff|*.tiff";
            var dic = new Dictionary<string,ChartImageFormat>();
            dic.Add( ".png" , ChartImageFormat.Png );
            dic.Add( ".jpg" , ChartImageFormat.Jpeg );
            dic.Add( ".bmp" , ChartImageFormat.Bmp );
            dic.Add( ".gif" , ChartImageFormat.Gif );
            dic.Add( ".tiff", ChartImageFormat.Tiff );
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                chart.SaveImage(sfd.FileName, dic[Path.GetExtension(sfd.FileName)]);
            }
        }
        //表示されているグラフをテキストに保存
        private void saveGraphToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Graph.txt";
            sfd.Filter = ".txt|*.txt|*.*|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.ASCII))
                {
                    SaveGraphToText(sw);
                }
            }
        }
        //グラフをテキストに保存(それぞれ形式が違うのでそれぞれで定義
        protected virtual void SaveGraphToText(StreamWriter sw)
        {
            throw new Exception("未実装");
 	        //グラフのテキストへの保存(各ウインドウで処理
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public virtual void addGraphToolStripMenuItem_Click(object sender, EventArgs e) { }
        public virtual void deleteGraphToolStripMenuItem_Click(object sender, EventArgs e) { }

    }
    public class SelectedArea
    {
        int x0, y0, x1, y1;

        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }
        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        public int Y0
        {
            get { return y0; }
            set { y0 = value; }
        }
        public int X0
        {
            get { return x0; }
            set { x0 = value; }
        }
        public void SetLT(int x0, int y0)
        {
            this.x0 = x0;
            this.y0 = y0;
        }
        public void SetRB(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public bool IsInArea(int x, int y)
        {
            return x0 < x && x < x1 && y0 < y && y < y1;
        }
        public void Reset()
        {
            x0 = y0 = x1 = y1 = -1;
        }
        public SelectedArea() { Reset(); }
        public void CheckValue()
        {
            int tmp;
            if (x0 > x1)
            {
                tmp = x0; x0 = x1; x1 = tmp;
            }
            if (y0 < y1)
            {
                tmp = y0; y0 = y1; y1 = tmp;
            }
        }
        public bool CheckAreaInGraph(PlotModel a)
        {
            if (x0 < 0 || y0 < 0 || x1 < 0 || x0 < 0 ||
                x0 > a.Location.X + a.Size.Width ||
                x1 > a.Location.X + a.Size.Width ||
                y0 > a.Location.X + a.Size.Height ||
                y1 > a.Location.X + a.Size.Height)
                return false;
            return true;
        }
        public void SetChartDrawArea(LinearAxis AxisX, LinearAxis AxisY)
        {
            AxisX.Minimum = AxisX.PixelPositionToValue(x0);
            AxisX.Maximum = AxisX.PixelPositionToValue(x1);
            AxisY.Minimum = AxisY.PixelPositionToValue(y0);
            AxisY.Maximum = AxisY.PixelPositionToValue(y1);
            //X軸の表示を調整
            SetAxisLimits(AxisX, AxisY);
            Reset();
        }
        public void SetAxisLimits(LinearAxis AxisX, LinearAxis AxisY)
        {
            AxisX.Interval = Math.Round(AxisX.Interval, 2);
            AxisX.Minimum = Math.Round(AxisX.Minimum, 2);
            AxisX.Maximum = Math.Round(AxisX.Maximum, 2);
            AxisY.Interval = Math.Round(AxisY.Interval, 2);
            AxisY.Minimum = Math.Round(AxisY.Minimum, 2);
            AxisY.Maximum = Math.Round(AxisY.Maximum, 2);
        }
        public void SetChartDrawAreaLimitedY(LinearAxis AxisX, LinearAxis AxisY, double[] x, params object[] ys)
        {
            double ymax = -1;
            AxisX.Minimum = AxisX.PixelPositionToValue(x0);
            AxisX.Maximum = AxisX.PixelPositionToValue(x1);
            for (int i = 0; i < x.Length && x[i] < AxisX.Maximum; i++)
            {
                if (x[i] < AxisX.Minimum) continue;

                foreach (object ar in ys)
                {
                    if (ymax < 0)
                    {
                        ymax = Math.Abs(((double[])ar)[i]);
                    }
                    else
                    {
                        ymax = Math.Max(ymax, Math.Abs(((double[])ar)[i]));
                    }
                }
            }
            AxisY.Minimum = -ymax;
            AxisY.Maximum = ymax;
            Reset();

            SetAxisLimits(AxisX, AxisY);
        }
        public void SetChartDrawAreaLimitedY(LinearAxis AxisX, LinearAxis AxisY, double ymax)
        {
            AxisX.Minimum = AxisX.PixelPositionToValue(x0);
            AxisX.Maximum = AxisX.PixelPositionToValue(x1);
            AxisY.Minimum = -ymax;
            AxisY.Maximum = ymax;
            Reset();

            SetAxisLimits(AxisX, AxisY);
        }
        public void Draw(Graphics g)
        {
            if (!(x0 >= 0 && y0 >= 0 && x1 >= 0 && y1 >= 0))
                return;
            Point[] p = new Point[]{
                new Point(X0,Y0),
                new Point(X1,Y0),
                new Point(X1,Y1),
                new Point(X0,Y1),
                new Point(X0,Y0),
            };
            g.DrawLines(Pens.Black, p);
        }
    }
    //初期状態chi
    public class InitDataGraphWindow : GraphShowWindow
    {
        List<double> k_X = new List<double>();
        List<double> exp_Y = new List<double>();
        List<double> fit_Y = new List<double>();
        List<double> exp_err = new List<double>();
        public InitDataGraphWindow():base()
        {
            bool readstart = false;
            foreach (string line in File.ReadLines("feffdat/BTdat.dat", BTMainForm.CharEncode))
            {
                if (line.IndexOf("Eexp_0") > 0 && !readstart)
                {
                    readstart = true;
                    continue;
                }
                if (readstart)
                {
                    string[] d = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //読み込み終わり
                    if (d.Count() < 5)
                        break;
                    //それぞれ読み込む
                    k_X.Add(double.Parse(d[1]));
                    exp_Y.Add(double.Parse(d[2]));
                    exp_err.Add(double.Parse(d[4]));
                    fit_Y.Add(double.Parse(d[3]));
                }
            }
                Series temp = new Series();
                temp.ChartArea = "ChartArea1";
                temp.ChartType = SeriesChartType.ErrorBar;
                temp.Name = "Exp_Err";
                chart.Series.Add(temp);

                Series temp2 = new Series();
                temp2.ChartArea = "ChartArea1";
                temp2.ChartType = SeriesChartType.Line;
                temp2.Name = "Fit";
                chart.Series.Add(temp2);

                for (int i = 0; i < k_X.Count; i++)
                {
                    chart.Series[0].Points.Add(new DataPoint(k_X[i], exp_Y[i]));   //グラフにデータ追加
                    chart.Series[1].Points.Add(new DataPoint(k_X[i], new double[] { exp_Y[i], exp_Y[i] - exp_err[i], exp_Y[i] + exp_err[i] }));   //グラフにデータ追加
                    chart.Series[1].Points.Last()["ErrorBarCenterMarkerStyle"] = "Circle";
                    chart.Series[1].Points.Last()["ErrorBarSeries"] = "Exp";
                    chart.Series[2].Points.Add(new DataPoint(k_X[i], fit_Y[i]));   //グラフにデータ追加
                }
//            }
        }
        protected override void SaveGraphToText(StreamWriter sw)
        {
            sw.Write("#k fit exp exp_err\n");
            for (int i = 0; i < k_X.Count; i++)
            {
                sw.Write(k_X[i] + " " + fit_Y[i] + " " + exp_Y[i] + " " + exp_err[i] + "\n");
            }
        }
        public override void ChangeDrawArea()
        {
            if (autoYToolStripMenuItem.Checked)
                SelArea.SetChartDrawAreaLimitedY(AxisX, AxisY, k_X.ToArray(), exp_Y.ToArray(), fit_Y.ToArray());
            else
                base.ChangeDrawArea();
         
        }
    }
    //終了状態chi
    public class ResultDataGraphWindow : GraphShowWindow
    {
        List<double> k_X = new List<double>();
        List<double> exp_Y = new List<double>();
        List<double> fit_Y = new List<double>();
        List<double> exp_err = new List<double>();
        public ResultDataGraphWindow()
            : base()
        {
            bool readstart = false;
            foreach (string line in File.ReadLines("feffdat/BTdat.dat", BTMainForm.CharEncode))
            {
                if (line.IndexOf("Eexp_1") > 0 && !readstart)
                {
                    readstart = true;
                    continue;
                }
                if (readstart)
                {
                    string[] d = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //読み込み終わり
                    if (d.Count() < 5)
                        break;
                    //それぞれ読み込む
                    k_X.Add(double.Parse(d[1]));
                    exp_Y.Add(double.Parse(d[2]));
                    exp_err.Add(double.Parse(d[4]));
                    fit_Y.Add(double.Parse(d[3]));
                }
            }    
                
                Series temp = new Series();
                temp.ChartArea = "ChartArea1";
                temp.ChartType = SeriesChartType.ErrorBar;
                temp.Name = "Exp_Err";
                chart.Series.Add(temp);

                Series temp2 = new Series();
                temp2.ChartArea = "ChartArea1";
                temp2.ChartType = SeriesChartType.Line;
                temp2.Name = "Fit";
                chart.Series.Add(temp2);

        
                for (int i = 0; i < k_X.Count; i++)
                {
                    chart.Series[0].Points.Add(new DataPoint(k_X[i], exp_Y[i]));   //グラフにデータ追加
                    chart.Series[1].Points.Add(new DataPoint(k_X[i], new double[] { exp_Y[i], exp_Y[i]-exp_err[i], exp_Y[i]+exp_err[i] }));   //グラフにデータ追加
                    chart.Series[1].Points.Last()["ErrorBarCenterMarkerStyle"] = "Circle";
                    chart.Series[1].Points.Last()["ErrorBarSeries"] = "Exp";                        
                    chart.Series[2].Points.Add(new DataPoint(k_X[i], fit_Y[i]));   //グラフにデータ追加
                }
//            }
        }
        protected override void SaveGraphToText(StreamWriter sw)
        {
            sw.Write("#k fit exp exp_err");
            for (int i = 0; i < k_X.Count; i++)
            {
                sw.Write(k_X[i] + " " + fit_Y[i] + " " + exp_Y[i] + " " + exp_err[i] + "\n");
            }
        }
        public override void ChangeDrawArea()
        {
            if (autoYToolStripMenuItem.Checked)
            {
                SelArea.SetChartDrawAreaLimitedY(AxisX, AxisY, k_X.ToArray(), exp_Y.ToArray(), fit_Y.ToArray());
            }
            else
                base.ChangeDrawArea();

        }
    }
    //行列
    public class MatrixDataGraphWindow : GraphShowWindow
    {
        List<double>    X = new List<double>(), 
                        Y = new List<double>(), 
                        Z = new List<double>();
        Point mpos;
        Point rot;
        int pers;
        //ChartArea3DStyle Area3DStyle;

        public MatrixDataGraphWindow()
            : base()
        {
            EnableExtension = false;
            int ylinenum = 0;
            int readstart = 0;

            int xelementnum = 1;
            int yelementnum = 1;
            Area3DStyle = chart.ChartAreas["ChartArea1"].Area3DStyle;

            foreach (string line in File.ReadLines("feffdat/BTmat.dat", BTMainForm.CharEncode))
            {
                if (line.IndexOf("----") > 0 && readstart == 0)
                {
                    readstart = 1;
                    continue;
                }
                if (readstart == 1)
                {
                    string[] s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    xelementnum = int.Parse(s[0]);
                    yelementnum = int.Parse(s[1]);

                    readstart++;
                    continue;
                }
                if (readstart == 2)
                {
                    string[] d = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (d.Count() < 5)
                        break;
                    else
                    {
                        for (int i = 0; i < d.Count(); i++)
                        {
                            if (i == ylinenum)
                                Z.Add(0);
                            else
                                Z.Add(double.Parse(d[i]));
                        }
                        ylinenum++;
                    }
                }

            }
                chart.Series.Clear();
                chart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                

                for (int y = 0; y < yelementnum; y++)
                {
                    Series temp = new Series();
                    temp.ChartArea = "ChartArea1";
                    temp.ChartType = SeriesChartType.Column;
                    chart.Series.Add(temp);
                    Area3DStyle.Inclination = 30;
                    Area3DStyle.Rotation = 30;
                    Area3DStyle.WallWidth = 5;
                    Area3DStyle.PointGapDepth = 10;
                    AxisX.Interval = 1;

                    for (int x = 0; x < xelementnum; x++)
                    {
                        DataPoint dp = new DataPoint(x, Math.Abs(Z[x + y * xelementnum]));
                        if (Z[x + y * xelementnum] >= 0)
                            dp.Color = Color.FromArgb(255 , 255, 0, 0);
                        else
                            dp.Color = Color.FromArgb(255 , 0, 0, 255);
                        chart.Series.Last().Points.Add(dp);
                    }
                }
//            }
            chart.Legends.Clear();  //凡例を非表示に
        }
        protected override void SaveGraphToText(StreamWriter sw)
        {
            sw.Write("# matrix:"+ X.Count + "*" + Y.Count);
            for (int y = 0; y < Y.Count; y++)
            {
                for (int x = 0; x < X.Count; x++)
                {
                    sw.Write(Z[x+y*X.Count]+" ");
                }
                sw.Write("\n");
            }
        }
        public override void chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                MousePressed = true;
                mpos.X = e.X;
                mpos.Y = e.Y;
                rot.X = Area3DStyle.Rotation;
                rot.Y = Area3DStyle.Inclination;
                pers  = Area3DStyle.Perspective;
            }
        }
        public override void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if ( (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
               && !(e.Button == (MouseButtons.Left|MouseButtons.Right)))
            {
                MousePressed = false;
            }
        }
        public override void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                Point dif = new Point(e.X - mpos.X, e.Y - mpos.Y);

                if (e.Button == (MouseButtons.Left | MouseButtons.Right))
                {
                    if (Math.Abs(dif.Y + rot.Y) <= 100)
                        Area3DStyle.Perspective = Math.Abs(dif.Y + rot.Y);

                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (Math.Abs(dif.Y + rot.Y) <= 255)
                    {
                        foreach (Series s in chart.Series)
                        {
                            foreach (var p in s.Points)
                                p.Color = Color.FromArgb(Math.Abs(dif.Y + rot.Y), p.Color.R, p.Color.G, p.Color.B);
                        }
                    }
                }
                else
                {
                    if (Math.Abs(dif.Y + rot.Y) <= 90)
                        Area3DStyle.Inclination = dif.Y + rot.Y;

                    if (Math.Abs(dif.X + rot.X) <= 180)
                        Area3DStyle.Rotation = dif.X + rot.X;
                }
            }
        }
    }
    //Sn2
    public class Sn2DataGraphWindow : GraphShowWindow
    {
        List<double> param_i = new List<double>();
        List<string> param_name = new List<string>();
        List<double> Sn2 = new List<double>();
        enum ReadMode
        {
            FINDLINE,
            SKIPONESENTENCE,
            READSN2,
            FINDFITPARAM,
            READFITPARAM,
            ENDREAD
        }
        public Color GetRGB(float h, float s, float v)
        {
            float r = 0, g = 0, b = 0;
            float f, p, q, t;
            int hi = ((int)h / 60) % 6;
            f = h / 60.0f - (hi);
            p = v * (1 - s);
            q = v * (1 - f * s);
            t = v * (1 - (1 - f) * s);
            switch (hi)
            {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = v;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;
                case 5:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }
            return Color.FromArgb(255, (int)(200 * r), (int)(200 * g), (int)(200 * b));
        }
        public Sn2DataGraphWindow(): base()
        {
            EnableExtension = false;
            ReadMode readstart = ReadMode.FINDLINE;

            //Sn2の読み込み
            foreach( string line in File.ReadLines( "feffdat/BTout.dat", BTMainForm.CharEncode ) )
            {
                if( readstart == ReadMode.ENDREAD )
                    break;

                switch (readstart)
                {
                    case ReadMode.SKIPONESENTENCE:
                        readstart = ReadMode.READSN2;
                        continue;
                    case ReadMode.FINDLINE:
                        if (line.IndexOf("----------") > 0)
                        {
                            readstart = ReadMode.SKIPONESENTENCE;
                            continue;
                        }
                        break;
                    case ReadMode.READSN2:
                        {
                            string[] d = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            //読み込み終わり
                            if (d.Count() < 6)
                            {
                                readstart = ReadMode.FINDFITPARAM;
                                break;
                            }
                            //それぞれ読み込む
                            param_i.Add(double.Parse(d[0]));
                            param_name.Add("");
                            Sn2.Add(double.Parse(d[5]));
                        }
                        break;
                    case ReadMode.FINDFITPARAM:
                        if (line.IndexOf("Fit parameters") >= 0)
                            readstart = ReadMode.READFITPARAM;
                        break;
                    case ReadMode.READFITPARAM:
                        {
                            if (line.IndexOf(" Multiple scattering parameters") >= 0)
                                readstart = ReadMode.ENDREAD;
                            string[] s = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (s.Length > 7)
                            {
                                try
                                {
                                    string s2 = s[1];
                                    if (s2.IndexOf("_") >= 0 && s2.IndexOf("str") < 0)
                                        s2 = s2.Substring(0, s2.IndexOf("_"));

                                    param_name[int.Parse(s[0]) - 1] = s2;
                                    if (int.Parse(s[0]) == param_name.Count)
                                        readstart = ReadMode.ENDREAD;
                                }
                                catch { }
                            }

                        }
                        break;
                }

                 chart.Series.Clear();
                 List<string> lbl = new List<string>();
                 Series srs = new Series();
                 srs.ChartArea = "ChartArea1";
                 srs.ChartType = SeriesChartType.Column;
                 srs.Name = "Sn2";
                 srs.SetCustomProperty("PointWidth", "0.6");
                 chart.Series.Add(srs);
                 chart.Legends.Clear();
                 
                AxisY.Maximum = 1.0;
                 Color c = Color.Blue;
                 for (int i = 0 ; i < param_i.Count; i++)
                 {
                     if (lbl.Count == 0 || lbl.FindIndex(s => s == param_name[i]) < 0)
                     {
                         c = GetRGB(lbl.Count*60, 1.0f, 0.6f);
                         lbl.Add(param_name[i]);
                     }
                     chart.Series[0].Points.Add(new DataPoint(param_i[i], Sn2[i]));   //グラフにデータ追加
                     chart.Series[0].Points[i].ToolTip = param_name[i] + " : " + "(" + param_i[i] + "," +Sn2[i]+")";
                     chart.Series[0].Points[i].Color = c;
                     chart.Series[0].Points[i].IsValueShownAsLabel = true;
                 }
                
            }

            AxisX.LabelStyle.Interval = 2;
            AxisX.Maximum = param_i.Last()+1;
            AxisX.MajorTickMark.Interval = 1;
        }
        protected override void SaveGraphToText(StreamWriter sw)
        {
            sw.Write("#Sn2 Data\n");
            sw.Write("#Number Name Sn2\n");
            for (int i = 0; i < param_i.Count; i++)
            {
                sw.Write(param_i[i] + " " + param_name[i] + " " + Sn2[i] + "\n");
            }
        }
    }
    //その他いろいろ(任意
    public class OtherDataGraphWindow : GraphShowWindow
    {
        class GraphData
        {
            public List<double> Xval = new List<double>();
            public List<double> Yval = new List<double>();
            public List<double> Errval = new List<double>();
            public string XName = "";
            public string YName = "";
            public string ErrName = "";
            public override string ToString()
            {
                return XName + " vs " + YName + (Errval.Count != 0 ? "(error" + ErrName + ")" : "");
            }
        }
        class CustomSeries : ScatterSeries
        {
            public bool Error = false;
            public string XName = "";
            public string Parent = "";
            public override string ToString()
            {
                if (Error)
                {
                    return XName + " vs " + Parent;
                }
                return XName + " vs " + Name;
            }
        }
        class SaveTextStruct
        {
            //保存用
            List<List<double>> Data = new List<List<double>>();
            List<string> Name = new List<string>();
            //X読み飛ばし判定用
            List<string> Xname = new List<string>();
            //public class DataPointCollection : System.Collections.ObjectModel.ObservableCollection<DataPoint> {}
            //public void Add(string xname, string yname, bool error, DataPointCollection points)
            //{
                //bool register_x = false;
                //int xindex = -1, yindex;
                //if (Xname.IndexOf(xname) < 0)
                //{
            //        register_x = true;
            //        Xname.Add(xname);
            //        Name.Add(xname);
            //        Data.Add(new List<double>());
            //        xindex = Data.Count - 1;
            //    }
            //    Name.Add(yname);
            //    Data.Add(new List<double>());
            //    yindex = Data.Count - 1;

            //    foreach (DataPoint p in points)
            //    {
            //        if (register_x && xindex >= 0)
            //            Data[xindex].Add(p.XValue);
            //        if (error)
            //        {
            //            Data[yindex].Add(Math.Abs(p.YValues[0] - p.YValues[1]));
            //        }
            //        else
            //        {
            //            Data[yindex].Add(p.YValues[0]);
            //        }
            //    }

            //}
            public void SaveToFile(StreamWriter sw)
            {
                if (Data.Count == 0)
                    return;
                sw.Write("#");
                foreach (string s in Name)
                {
                    sw.Write(s + " ");
                }
                sw.Write("\n");
                for (int i = 0; i < Data[0].Count; i++)
                {
                    foreach (var d in Data)
                    {
                        sw.Write(d[i] + " ");
                    }
                    sw.Write("\n");
                }
            }
        }
        public OtherDataGraphWindow(SelectXYDataWindow sw)
            : base()
        {
            chart.Series.Clear();
            AddGraph(sw);
            EnableAddGraph = true;
        }
        private void AddGraph(SelectXYDataWindow sw)
        {
            bool readstart = false;
            CustomSeries srs = new CustomSeries();
            srs.ChartArea = "ChartArea1";
            srs.ChartType = SeriesChartType.Line;
            srs.Name = sw.ParamName;
            srs.XName = sw.ParamXName;
            chart.Series.Add(srs);

            if (sw.Errorindex >= 0)
            {
                CustomSeries errsrs = new CustomSeries();
                errsrs.ChartArea = "ChartArea1";
                errsrs.ChartType = SeriesChartType.ErrorBar;
                errsrs.Error = true;
                errsrs.Name = sw.ParamErrName;
                errsrs.XName = sw.ParamXName;
                errsrs.Parent = sw.ParamName;
                chart.Series.Add(errsrs);
            }
            foreach( string line in File.ReadLines( "feffdat/BTdat.dat", BTMainForm.CharEncode ) )
            {
                //選択した行を探す
                if (sw.Line == 0)
                {
                    if (!readstart && line.IndexOf("Eexp_0") >= 0)
                    {
                        readstart = true;
                        continue;
                    }
                }
                if (sw.Line == 1)
                {
                    if (!readstart && line.IndexOf("Eexp_1") >= 0)
                    {
                        readstart = true;
                        continue;
                    }
                }
                if (sw.Line == 2)
                {
                    if (!readstart && line.IndexOf("f(R)_SS") >= 0)
                    {
                        readstart = true;
                        continue;
                    }
                }
                if (sw.Line == 3)
                {
                    if (!readstart && line.IndexOf("kbg") >= 0)
                    {
                        readstart = true;
                        continue;
                    }
                }

                if (readstart)
                {
                    string[] d = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    //読み込み終わり
                    if (d.Count() < 5)
                        break;
                    //それぞれ読み込む
                    double x = double.Parse(d[sw.Xindex]);
                    double y = double.Parse(d[sw.Yindex]);
                    if (sw.Errorindex >= 0)
                    {
                        double err = double.Parse(d[sw.Errorindex]);
                        chart.Series[chart.Series.Count - 2].Points.Add(new DataPoint(x, y));   //グラフにデータ追加
                        chart.Series[chart.Series.Count - 1].Points.Add(new DataPoint(x, new double[] { y, y - err, y + err }));   //グラフにデータ追加
                        chart.Series[chart.Series.Count - 1].Points.Last()["ErrorBarCenterMarkerStyle"] = "Circle";
                        chart.Series[chart.Series.Count - 1].Points.Last()["ErrorBarSeries"] = "Exp";
                    }
                    else
                    {
                        chart.Series[chart.Series.Count - 1].Points.Add(new DataPoint(x, y));   //グラフにデータ追加
                    }
                }
            }
        }

        public override void addGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectXYDataWindow sw = new SelectXYDataWindow();
            if (sw.ShowDialog() == DialogResult.OK)
            {
                AddGraph( sw);
            }
        }
        public override void deleteGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> param = new List<string>();
            foreach (var s in chart.Series)
            {
                param.Add(s.ToString());
            }
            SelectDeleteGraph sdgw = new SelectDeleteGraph(param);
            if (sdgw.ShowDialog() == DialogResult.OK)
            {
                List<Series> RemoveList = new List<Series>();
                foreach (var s in chart.Series)
                {
                    if (s.ToString() == sdgw.SelectedIndexText)
                        RemoveList.Add(s);
                }
                foreach (var s in RemoveList)
                {
                    chart.Series.Remove(s);
                }
                chart.Invalidate();
            }
        }

        protected override void SaveGraphToText(StreamWriter sw)
        {
            SaveTextStruct sts = new SaveTextStruct();
            foreach( CustomSeries s in chart.Series )
            {
                //sts.Add( s.XName,s.Name , s.Error , s.Points );
            }
            sts.SaveToFile(sw);
        }
        public override void ChangeDrawArea()
        {
            if (autoYToolStripMenuItem.Checked)
            {
                double ymax = -1;
                double xmin = AxisX.PixelPositionToValue(Math.Min( SelArea.X0 , SelArea.X1 ));
                double xmax = AxisX.PixelPositionToValue(Math.Max( SelArea.X0 , SelArea.X1 ));
                foreach (var s in chart.Series)
                {
                    for(int i=0; i<s.Points.Count;i++ )
                    {
                        //範囲内での絶対値最大の値を探す
                        if( ymax < 0 )
                            ymax = Math.Abs( s.Points[i].YValues[0] );
                        else
                            ymax = Math.Max( ymax , s.Points.Max( 
                                t => ( t.XValue >= xmin && t.XValue <= xmax ) ? Math.Abs( t.YValues[0] ) : 0
                            )  );
                    }
                }
                if (ymax < 0)
                    return;


                SelArea.SetChartDrawAreaLimitedY(AxisX, AxisY,ymax);
            }
            else
                base.ChangeDrawArea();
        }
    }
  
}
