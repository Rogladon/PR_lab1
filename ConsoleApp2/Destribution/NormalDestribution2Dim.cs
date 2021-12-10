using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;
using ILNumerics.Toolboxes;

namespace Destribution {
	public class NormalDestribution2Dim {
		private InArray<double> std;
		private InArray<double> mean;
		private InArray<double> cov;

		public InArray<double> Std => std;
		public InArray<double> Mean => mean;
		public InArray<double> Cov => cov;
		
		public NormalDestribution2Dim(Array<double> mean, Array<double> cov) {
			this.mean = mean;
			this.cov = cov;
		}
		public InArray<double> GetZArray(InArray<double> x) {
			return x.Select(p => GetZ(p)).ToArray();
		}
		public InArray<double> GetZ(InArray<double> x) {
			InArray<double> c = ILMath.exp(ILMath.multiply((-0.5) 
				* (x - mean).transpose(), ILMath.pinv(cov), (x - mean)));
			return c.First();
		}
		public static Func<InArray<double>, InArray<double>> GetFuncZ(InArray<double> mean, InArray<double> cov) {
			return new NormalDestribution2Dim(mean, cov).GetZ;
		}
		public static NormalDestribution2Dim Simple(Array<double> array1, Array<double> array2) {
			Array<double> array = array1.Concat(array2).ToArray();
			array = array.Reshape(array.Length / 2, 2);
			return new NormalDestribution2Dim(ILMath.mean(array), Statistics.cov(array.transpose()));
		}
		public static NormalDestribution2Dim Simple(Array<double> array) {
			return new NormalDestribution2Dim(ILMath.mean(array), Statistics.cov(array.transpose()));
		}
	}
}
