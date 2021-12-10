using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace TextParser {
	public class ParseIris : ITextParserDouble {
		public enum TypeIris {
			SE = 0,
			VE = 1,
			VI = 2
		}
		private TypeIris type;
		private int x;

		public ParseIris(TypeIris type, int x) {
			this.type = type;
			this.x = x-1;
		}
		public InArray<double> ParseIOToArray(string filePatch) {
			StreamReader stream = new StreamReader(filePatch);
			List<string> strs = stream.ReadToEnd().Split('\n').ToList();
			stream.Close();
			strs.RemoveRange(0, 2);
			List<string> iris = new List<string>();
			foreach(var i in strs) {
				if (i.IndexOf(".") < 0) continue;
				List<string> str = i.Remove(0, i.IndexOf(".") - 1).Replace(".",",")
					.Split(' ').ToList();
				iris.Add(str[(((int)type) * 4)+x]);
			}
			return iris.Select(p => float.Parse(p)).ToArray();
		}
	}
}
