using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics.Drawing.Plotting;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Drawing;

namespace Plot {
	public class APlot : IPlot {
		protected PlotCube plotCube;
		protected PlotWindow plotWindow = null;
		protected string name = "Plot";

		public APlot() {
			plotCube = new PlotCube();
		}

		public IPlot SetConfig(IConfigPlot config) {
			config.SetConfig(plotCube);
			return this;
		}
		public void Draw() {
			if (plotWindow == null) plotWindow = new PlotWindow(plotCube, name);
			Task.Factory.StartNew(() => Application.Run(plotWindow));
		}

		public virtual IPlot Add(InArray<float> Y, IConfigPlot config = null) {
			return this;
		}

		public virtual IPlot Add(InArray<double> X, Func<InArray<double>, InArray<double>> func, IConfigPlot config = null) {
			return this;
		}
		public virtual IPlot Add(Node node, IConfigPlot config = null) {
			SetPlot(node, config);
			return this;
		}
		
		protected void SetPlot(Node node, IConfigPlot config) {
			if (config != null) plotCube.Add(config.SetConfig(node));
			else plotCube.Add(node);
			if (plotWindow != null) plotWindow.UpdatePlot(plotCube);
		}

		public IPlot SetName(string name) {
			this.name = name;
			return this;
		}
	}
}
