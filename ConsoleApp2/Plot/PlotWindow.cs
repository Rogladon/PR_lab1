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

namespace Plot {
	public partial class PlotWindow : Form {
		private PlotCube plotCube;
		public PlotWindow(PlotCube plotCube, string name) {
			InitializeComponent();
			this.plotCube = plotCube;
			Text = name;
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			panel.Scene.Add(plotCube);
		}
		public void UpdatePlot(PlotCube plotCube) {
			this.plotCube = plotCube;
			panel.Scene.Children[0] = plotCube;
			panel.Update();
		}
	}
}
