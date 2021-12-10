using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace TextParser {
	public class ParseIrises : ITextParserDouble {
		public class IrisDim {
			private ParseIris.TypeIris type;
			private int x;
			private bool reverse;
			public ParseIris.TypeIris Type => type;
			public int X => x;
			public bool Reverse => reverse;
			public IrisDim(ParseIris.TypeIris type, int x, bool reverse = false) {
				this.type = type;
				this.x = x;
				this.reverse = reverse;
			}
		}
		private InArray<IrisDim> dims;
		public ParseIrises(InArray<IrisDim> dims) {
			this.dims = dims; 
		}
		public InArray<double> ParseIOToArray(string filePatch) {
			Array<double> iris = new double[0];
			foreach(var i in dims) {
				Array<double> iris1 = new ParseIris(i.Type, i.X).ParseIOToArray("iris.txt").ToArray();
				if (i.Reverse) iris1 = iris1.Reverse().ToArray();
				iris = iris.Concat(iris1).ToArray();
			}
			iris = iris.Reshape(iris.Length / dims.Length, dims.Length);
			return iris;
		}
	}
}
