using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;
using ILNumerics.Toolboxes;

namespace Destribution {
	public class NormalDestribution {
		private double std;
		private double mean;
		private double varience;

		public double Std => std;
		public double Mean => mean;
		public double Var => varience;
		
		public NormalDestribution(double mean, double std) {
			this.mean = mean;
			this.std = std;
			varience = new ILNumerics.Toolboxes.Distributions.NormalDistribution(mean, std).Variance;
		}
		public InArray<double> GetYArray(InArray<double> x) {
			return x.Select(p => GetY(p)).ToArray();
		}
		public InArray<double> GetY(InArray<double> x) {
			return ((1 / (std * ILMath.sqrt(2 * Globals.pi))) 
				* ILMath.exp(-ILMath.pow((x - mean), 2f) / (2 * std * std))).First();
		}
		public static Func<InArray<double>, InArray<double>> GetFuncY(InArray<double> mean, InArray<double> std) {
			return new NormalDestribution(mean.First(), std.First()).GetY;
		}
		public static NormalDestribution Simple(InArray<double> array) {
			return new NormalDestribution(ILMath.mean(array).First(), Statistics.std(array).First());
		}
	}
}
