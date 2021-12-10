using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace TextParser {
	public interface ITextParser<T> {
		InArray<T> ParseIOToArray(string filePatch);
	}
}
