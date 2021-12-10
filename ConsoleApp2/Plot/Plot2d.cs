using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System.Windows.Forms;

namespace Plot {
	public class Plot2d : APlot {

		public Plot2d() : base() { }

		public override IPlot Add(InArray<float> Y, IConfigPlot config = null) {
			SetPlot(new LinePlot(Y), config);
			return this;
		}

		public override IPlot Add(InArray<double> X, Func<InArray<double>, InArray<double>> func, IConfigPlot config = null) {
			long lenght = func(0).Length;
			Array<float> XY = new float[0, X.Length * 0];
			for (int i = 0; i < X.Length; i++) {
				Array<double> _y = func(X[$":;{i}"]);
				for (int j = 0; j < lenght; j++) {
					long index = j % 2 == 0 ? ((j) * X.Length) + i : ((j + 1) * X.Length) - (i + 1);
					XY[0, index] = (float)X[i];
					XY[1, index] = (float)_y[j];

				}
			}
			SetPlot(new LinePlot(XY), config);
			return this;
		}
		public IPlot Add(InArray<double> X, InArray<double> Y, IConfigPlot config = null) {
			SetPlot(new LinePlot(X, Y), config);
			return this;
		}
	}
}
