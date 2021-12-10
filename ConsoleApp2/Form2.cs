using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using static ILNumerics.ILMath;
using static ILNumerics.Globals;

namespace ConsoleApp2 {
	public partial class Form2 : Form {
		public Form2() {
			InitializeComponent();
		}
        ILNumerics.Drawing.Panel panel;
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
            Test();
            //panel = new ILNumerics.Drawing.Panel();
            //panel.Dock = DockStyle.Fill;
            //panel.Load += Panel_Load;
            //Controls.Add(panel);
        }

        private void Test() {
            List<float> f = Enumerable.Range(0, 5).Select(p => (float)p).ToList();
            f.AddRange(ILMath.linspace<float>(10, 0,10));
            ILNumerics.Drawing.Panel pn = new ILNumerics.Drawing.Panel();
            PlotCube plotCube = new PlotCube();
            panel1.Scene.Add(plotCube);


            var l = new LinePlot(f.ToArray());
            l.ColorOverride = Color.Black;
            l.Line.DashStyle = DashStyle.Dotted;
            l.Line.EmissionColor = Color.Blue;
            plotCube.Add(l);
		}

        private void Panel_Load(object sender, EventArgs e) {
            
            Array<float> A = tosingle(SpecialData.terrain["0:100;0:140"]);
            panel.Scene.Add(
                new PlotCube(twoDMode: false) {
                    new Surface(A, colormap: Colormaps.Hot) {
                        new Colorbar()
                    }
                });
            panel.Scene.First<PlotCube>().Rotation = Matrix4.Rotation(new Vector3(1, .1, .2), 1);
        }
    }
}
