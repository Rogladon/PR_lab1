using ILNumerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics.Drawing.Plotting;
using ILNumerics.Drawing;

namespace Plot {
	public class FreePlot : APlot {
		public FreePlot(Node node) : base() {
			this.plotCube.Add(node);
		}
	}
}
