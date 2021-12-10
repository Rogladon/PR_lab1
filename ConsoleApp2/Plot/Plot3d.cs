using ILNumerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics.Drawing.Plotting;
using ILNumerics.Drawing;

namespace Plot {
	public class Plot3d : APlot {
		public Plot3d() : base() {
			plotCube.Rotation = Matrix4.Rotation(new Vector3(1, .1, .2), 1);
		}
		public override IPlot Add(InArray<double> X, Func<InArray<double>, InArray<double>> func, IConfigPlot config = null) {

			Func<float, float, float> fn = (x, y) => (float)func(new double[] { x, y }).First();

			InArray<double> xy = X;

			SetPlot(new Surface(ZFunc:fn,
				xmin:(float)xy.GetValue(0,0), xmax: (float)xy.GetValue(0,xy.Length-1),xlen:(int)xy.Length,
				ymin: (float)xy.GetValue(1, 0), ymax: (float)xy.GetValue(1, xy.Length-1), ylen: (int)xy.Length), config);

			return this;
		}
	}
}
