using ILNumerics.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics.Drawing.Plotting;
using System.Drawing;

namespace Plot {
	public class ConfigMarked : IConfigPlot {
		Color color;
		public ConfigMarked(Color color) {
			this.color = color;
		}
		public Node SetConfig(Node plot) {
			LinePlot line = plot as LinePlot;
			line.Marker.Style = MarkerStyle.Circle;
			line.Marker.ColorOverride = color;
			line.Marker.Size = 2;
			line.Line.Color = Color.White;
			line.Line.Width = 0;
			return line;
		}
	}
}
