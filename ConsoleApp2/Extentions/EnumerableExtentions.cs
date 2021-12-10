using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace Extentions {
	public static class EnumerableExtentions {
		public static void WriteConsole<T>(this IEnumerable<T> e, string split = "\n") {
			foreach(var i in e) {
				Console.Write($"{i}{split}");
			}
		}
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> e, Action<T> action) {
			foreach(var i in e) {
				action(i);
			}
			return e;
		}
		//public static Array<T> Concat<T>(Array<>)
	}
}
