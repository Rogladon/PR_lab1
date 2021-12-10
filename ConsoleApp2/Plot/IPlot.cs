using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;
using ILNumerics.Drawing;

namespace Plot {
	public interface IPlot {
		IPlot SetConfig(IConfigPlot config);
		IPlot SetName(string name);
		IPlot Add(InArray<float> Y, IConfigPlot config = null);
		IPlot Add(InArray<double> X, Func<InArray<double>, InArray<double>> func, IConfigPlot config = null);
		IPlot Add(Node node, IConfigPlot config = null);
		//IPlot Add(InArray<double> X, InArray<double> Y, InArray<double> Z, IConfigPlot config = null);
		void Draw();
	}
}
